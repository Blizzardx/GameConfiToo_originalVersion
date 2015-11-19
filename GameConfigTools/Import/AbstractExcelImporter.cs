using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using GameConfigTools.Model;
using GameConfigTools.Util;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Web;
using Newtonsoft.Json.Linq;
using Thrift.Protocol;
using Common.Message;
using System.Diagnostics;
using System.Data.OleDb;
using System.Data;

namespace GameConfigTools.Import
{
    public abstract class AbstractExcelImporter : Importer
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AbstractExcelImporter));

        /// <summary>
        /// xml中特殊字符
        /// </summary>
        private ISet<char> xmlWord = new HashSet<char>();

        private string[] sheetNames;

        public AbstractExcelImporter()
        {
            xmlWord.Add('&');
            xmlWord.Add('<');
            xmlWord.Add('>');
            xmlWord.Add('\'');
            xmlWord.Add('"');
        }

        /// <summary>
        /// 判断字符串中有没有xml的特殊字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool IsExistSpecial(string value)
        {
            char[] chs = value.ToCharArray();
            foreach (char c in chs)
            {
                if (xmlWord.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ReadExcel(ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            SysConfig config = Context.instance.GetSysConfig();

            string filePath = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\" + this.GetConfigName() + "." + this.GetExportType();

            int rowCount = 0;
            int columnCount = 0;
            string[] sheetNames = this.GetSheetNames(filePath, ref errMsg, ref rowCount, ref columnCount);
            if (sheetNames == null)
            {
                return false;
            }

            List<List<List<string>>> tempList = new List<List<List<string>>>();

            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + filePath + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);

            try
            {
                conn.Open();
                foreach (string sheetName in sheetNames)
                {
                    //第一个sheet页
                    List<List<string>> sheetList = new List<List<string>>();
                    tempList.Add(sheetList);
                    String sqlGetColumnName = "SELECT * FROM [" + sheetName + "$]";
                    System.Data.OleDb.OleDbDataAdapter odasheet = new System.Data.OleDb.OleDbDataAdapter(sqlGetColumnName, conn);
                    DataSet dsSheet = new DataSet();

                    odasheet.Fill(dsSheet, sheetName);
                    System.Data.DataTable table = dsSheet.Tables[0];

                    foreach (DataRow dataRow in table.AsEnumerable())
                    {
                        //是否被注释掉了
                        bool annotation = false;
                        object firstObj = dataRow.ItemArray.First();
                        if (firstObj != null)
                        {
                            //sheet页的第一个单元格内，是两个"##"表示整个sheet页不读
                            if (firstObj.ToString().Equals("##"))
                            {
                                goto LOOP;
                            }
                            //如果对注释生效，同时第一个字符为"#"，表示注释一行
                            if (this.UseAnnotation() && firstObj.ToString().StartsWith("#"))
                            {
                                annotation = true;
                            }
                        }
                        List<string> columnList = new List<string>();
                        sheetList.Add(columnList);
                        int tempColumnCount = dataRow.ItemArray.Length;
                        for (int i = 0; i < columnCount; i++)
                        {
                            //如果注释了，一整行都为空
                            if (annotation)
                            {
                                columnList.Add(null);
                            }
                            else
                            {
                                if (i < tempColumnCount)
                                {
                                    columnList.Add(dataRow[i] == null ? null : dataRow[i].ToString());
                                }
                                else
                                {
                                    columnList.Add(null);
                                }
                            }
                        }
                    }
                LOOP:
                    continue;
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                logger.Error("import excel:" + this.GetConfigName() + " error.", e);
                return false;
            }
            finally
            {
                conn.Close();
            }

            List<string[][]> sheetValues = new List<string[][]>();
            for (int i = 0; i < tempList.Count; i++)
            {
                List<List<string>> list = tempList[i];
                string[][] values = new string[list.Count][];
                for (int j = 0; j < list.Count; j++)
                {
                    values[j] = list[j].ToArray();
                }
                sheetValues.Add(values);
            }

            this.GenerateConfig(sheetValues, ref errMsg, out root, out tbase);

            //下面生成服务器和客户端的配置
            if (errMsg != "")
            {
                return false;
            }
            if (tbase != null)
            {
                //缓存一下
                ImporterManager.instance.AddCacheConfig(this.GetConfigName(), tbase);
            }
            return true;
        }

        public bool Import(ref string errMsg)
        {
            XElement root;
            TBase tbase;
            if (!this.ReadExcel(ref errMsg, out root, out tbase))
            {
                return false;
            }
            SysConfig config = Context.instance.GetSysConfig();

            string filePath = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\" + this.GetConfigName() + "." + this.GetExportType();
            bool result = false;
            //生成服务器配置
            if (root != null)
            {

                string path = config.ServerConfigPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion();
                string name = path + @"\" + this.GetConfigName() + ".xml";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                LogQueue.instance.Add("正在生成服务器配置:" + name);
                using (FileStream fs = new FileStream(name, FileMode.Create))
                {
                    XmlWriterSettings setting = new XmlWriterSettings();
                    setting.Indent = true;
                    setting.IndentChars = "\t";
                    setting.NewLineChars = "\n";
                    setting.Encoding = Encoding.UTF8;
                    using (XmlWriter xw = XmlWriter.Create(fs, setting))
                    {
                        root.WriteTo(xw);
                    }
                }
                LogQueue.instance.Add("生成服务器配置成功.");
                LogQueue.instance.Add("正在上传服务器配置...");
                string content = HttpUtility.UrlEncode(root.ToString(), Encoding.UTF8).Replace(" ", "%26").Replace("+", "%20");
                string postString = string.Format("game_type={0}&server_version={1}&name={2}&content={3}", Context.instance.GetGame(), Context.instance.GetVersion(), this.GetConfigName(), content);
                string html = HttpUtil.HttpPost(config.ConfigCenterUrl + SysConstant.UPDATE_CONFIG, postString);

                JObject json = JObject.Parse(html);
                int status = int.Parse(json["status"].ToString());
                if (status == -1)
                {
                    errMsg = json["errMsg"].ToString();
                    logger.Error(string.Format("import:{0} fail. result:{1}", this.GetConfigName(), html));
                    return false;
                }
                LogQueue.instance.Add("上传服务器配置成功.");
                result = true;
            }
            //生成客户端配置
            if (tbase != null)
            {
                string path = config.ClientConfigPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion();
                string name = path + @"\" + this.GetConfigName() + "_txtpkg.bytes";
                LogQueue.instance.Add("正在生成客户端配置:" + name);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fs = new FileStream(name, FileMode.Create))
                {
                    byte[] bytes = ThriftSerialize.Serialize(tbase);
                    if (bytes != null && bytes.Length > 0)
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                LogQueue.instance.Add("生成客户端配置成功.");
                LogQueue.instance.Add("正在上传客户端配置...");
                int statusCode = HttpUtil.UploadFile(config.UploadUrl + SysConstant.CLIENT_RESOURCE_UPLOAD, name);
                if (statusCode != 200)
                {
                    if (statusCode == 600)
                    {
                        errMsg = string.Format("客户端资源[{0}]上传冲突，可能多人同时修改同一文件", filePath);
                    }
                    else if (statusCode == 601)
                    {
                        errMsg = string.Format("客户端资源[{0}]上传异常，请联系技术人员", filePath);
                    }
                    else
                    {
                        errMsg = string.Format("客户端资源[{0}]上传失败，ErrorCode:{1}", filePath, statusCode);
                    }
                    return false;
                }
                LogQueue.instance.Add("上传客户端配置成功.");
                result = true;
            }
            if (!result)
            {
                errMsg = "生成的配置是空的";
                return false;
            }
            return true;
        }

        protected string[] GetSheetNames()
        {
            return this.sheetNames;
        }

        public string[] GetSheetNames(string filePath, ref string errMsg, ref int rowCount, ref int columnCount)
        {
            string[] sheetNames;
            Application excel = new Application();
            Workbook workBook = null;
            try
            {
                //设置Excel不可见
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workBook = excel.Workbooks.Open(filePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                sheetNames = new string[workBook.Sheets.Count];
                //计算出数组有多大
                for (int i = 1; i <= workBook.Sheets.Count; i++)
                {
                    Worksheet sheet = workBook.Sheets[i];
                    rowCount += sheet.UsedRange.Rows.Count;
                    if (columnCount == 0)
                    {
                        columnCount = sheet.UsedRange.Columns.Count;
                    }
                    sheetNames[i - 1] = sheet.Name;
                }
                if (sheetNames != null)
                {
                    this.sheetNames = sheetNames;
                }
                return sheetNames;
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                logger.Error("import excel:" + this.GetConfigName() + " error.", e);
                return null;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(Missing.Value, Missing.Value, Missing.Value);
                }
                excel.Workbooks.Close();
                excel.Quit();

                ProcessUtil.KillProcess("Excel");
                excel = null;
                workBook = null;
            }
        }

        /// <summary>
        /// 判断整个数组是不是有值
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected bool IsLineNotNull(string[] line)
        {
            if (line == null)
            {
                return false;
            }
            foreach (string obj in line)
            {
                if (obj != null && obj.ToString().Trim() != "")
                {
                    return true;
                }
            }
            return false;
        }

        public string GetExportType()
        {
            return "xlsx";
        }

        protected abstract void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase);

        protected abstract string GetConfigName();

        /// <summary>
        /// 在excel中是否可以使用"#"进行注释一行
        /// </summary>
        /// <returns></returns>
        protected virtual bool UseAnnotation()
        {
            return true;
        }


        protected List<List<string>> ParseBracket(List<string> strList)
        {
            Stack<string> stack = new Stack<string>();
            int index = 0;
            int beginIndex = 0;
            int endIndex = 0;
            List<List<string>> list = null;
            foreach (string str in strList)
            {
                string s = str;
                index++;
                if (s == null)
                {
                    s = "";
                }
                s = s.Trim();
                if (s == "(")
                {
                    beginIndex = index;
                    stack.Push(str);
                    continue;
                }
                if (s == ")")
                {
                    if (stack.Count == 0)
                    {
                        return null;
                    }
                    //括号没有匹配上
                    if (stack.Pop() != "(")
                    {
                        return null;
                    }
                    endIndex = index - 1;
                    if (list == null)
                    {
                        list = new List<List<string>>();
                    }
                    List<string> result = new List<string>();
                    list.Add(result);
                    for (int i = beginIndex; i < endIndex; i++)
                    {
                        if (strList[i] == null)
                        {
                            continue;
                        }
                        result.Add(strList[i]);
                    }
                }
            }
            //括号不匹配
            if (stack.Count > 0)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        /// 从括号的起始位置，解析到对应匹配的位置
        /// </summary>
        /// <param name="line">一行数据</param>
        /// <param name="startIndex">左括号的起始位置，或左括号前的位置</param>
        /// <param name="lastIndex">返回对应左括号的右括号位置</param>
        /// <returns>返回括号中的数据</returns>
        protected List<string> ParseSingleBracket(string[] line, int startIndex, out int lastIndex)
        {
            List<string> list = new List<string>();
            lastIndex = 0;
            Stack<string> stack = new Stack<string>();
            for (int i = startIndex; i < line.Length; i++)
            {
                string s = line[i];
                if (s == null)
                {
                    s = "";
                }
                s = s.Trim();
                if (s == "(")
                {
                    stack.Push(s);
                    continue;
                }
                if (s == ")")
                {
                    if (stack.Count != 1)
                    {
                        return null;
                    }
                    if (stack.Pop() != "(")
                    {
                        return null;
                    }
                    //右括号的索引
                    lastIndex = i + 1;
                    return list;
                }
                //在括号中的数据
                if (stack.Count == 1)
                {
                    list.Add(s);
                }
            }
            //括号不匹配
            if (stack.Count > 0)
            {
                return null;
            }
            return null;
        }
    }
}
