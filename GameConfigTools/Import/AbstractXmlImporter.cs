using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Model;
using GameConfigTools.Util;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web;
using GameConfigTools.Constant;
using System.Xml;
using Thrift.Protocol;
using Common.Message;

namespace GameConfigTools.Import
{
    public abstract class AbstractXmlImporter : Importer
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AbstractXmlImporter));
        public bool Import(ref string errMsg)
        {
            string externalBytesName = ImporterManager.instance.GetExternalBytesName(this.GetConfigName());

            SysConfig config = Context.instance.GetSysConfig();

            string path = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion();
            string xmlName = this.GetConfigName() + ".xml";

            bool xmlExist = false;
            if (!File.Exists(path + @"\" + xmlName))
            {
                if (externalBytesName == null)
                {
                    errMsg = path + @"\" + xmlName + " 不存在!";
                    return false;
                }
            }
            else
            {
                xmlExist = true;
            }

            TBase tbase = null;

            if(xmlExist)
            {
                XElement root = XElement.Load(path + @"\" + xmlName);

                if (!this.Valid(root, out tbase, ref errMsg))
                {
                    return false;
                }

                if (root != null)
                {

                    string gameConfigPath = config.ServerConfigPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion();
                    if (!Directory.Exists(gameConfigPath))
                    {
                        Directory.CreateDirectory(gameConfigPath);
                    }
                    LogQueue.instance.Add("正在生成服务器配置:" + gameConfigPath + @"\" + this.GetConfigName() + ".xml");
                    using (FileStream fs = new FileStream(gameConfigPath + @"\" + this.GetConfigName() + ".xml", FileMode.Create))
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
                }
            }
            string clientPath = config.ClientConfigPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion();
            //生成客户端配置
            if (tbase != null)
            {
                string name = clientPath + @"\" + this.GetConfigName() + "_txtpkg.bytes";
                LogQueue.instance.Add("正在生成客户端配置:" + name);
                if (!Directory.Exists(clientPath))
                {
                    Directory.CreateDirectory(clientPath);
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
                UploadClientConfig(name, ref errMsg);
            }
            else
            {
                if (externalBytesName != null)
                {
                    string name = clientPath + @"\" + externalBytesName;
                    LogQueue.instance.Add("寻找外部客户端配置:" + name);
                    if (!File.Exists(name))
                    {
                        errMsg = name + " 不存在!";
                        return false;
                    }

                    UploadClientConfig(name, ref errMsg);
                }
            }

            return true;
        }

        public bool UploadClientConfig(string name, ref string errMsg)
        {
            SysConfig config = Context.instance.GetSysConfig();
            LogQueue.instance.Add("正在上传客户端配置...");
            int statusCode = HttpUtil.UploadFile(config.UploadUrl + SysConstant.CLIENT_RESOURCE_UPLOAD, name);
            if (statusCode != 200)
            {
                if (statusCode == 600)
                {
                    errMsg = string.Format("客户端资源[{0}]上传冲突，可能多人同时修改同一文件", name);
                }
                else if (statusCode == 601)
                {
                    errMsg = string.Format("客户端资源[{0}]上传异常，请联系技术人员", name);
                }
                else
                {
                    errMsg = string.Format("客户端资源[{0}]上传失败，ErrorCode:{1}", name, statusCode);
                }
                return false;
            }
            LogQueue.instance.Add("上传客户端配置成功.");
            return true;
        }

        public string GetExportType()
        {
            return "xml";
        }

        protected virtual bool Valid(XElement root, out TBase tbase, ref string errMsg)
        {
            tbase = null;
            return true;
        }

        protected abstract string GetConfigName();
    }
}
