using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class ShockConfigImporter:AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            //root = new XElement("root");

            ShockConfigTable config = new ShockConfigTable();
            tbase = config;
            config.ShockConfigMap = new Dictionary<int, ShockConfig>();

            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int row = i + 1;
                    int index = 0;

                    int id;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];

                    int begintimemin;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out begintimemin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，开始时间min必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int begintimemax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out begintimemax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，开始时间max必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int randomMin;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out randomMin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，firstTaskFucId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int randomMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out randomMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，positionid必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int funcId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out funcId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，positionid必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<OptionElement> tmpList = new List<OptionElement>();
                    if (!DecodeOptionList(values[i], ref index, tmpList))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，权重列表解析出错", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    ShockConfig c  = new ShockConfig();
                    c.Id = id;
                    c.BeginTimeMin = begintimemin;
                    c.BeginTimeMax = begintimemax;
                    c.RandomCountMin = randomMin;
                    c.RandomCountMax = randomMax;
                    c.BeginFuncId = funcId;
                    c.OptionList = tmpList;
                    config.ShockConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.SHOCK_CONFIG;
        }
        private bool DecodeOptionList(string[] content, ref int index, List<OptionElement> targetList)
        {
            if (content[index++] != "(")
            {
                return false;
            }
            bool isDone = false;
            for (; index < content.Length; ++index)
            {
                string s = content[index];
                if (s == ",")
                {
                    continue;
                }
                if (s == ")")
                {
                    ++index;
                    isDone = true;
                    break;
                }
                else
                {
                    try
                    {
                        OptionElement param = new OptionElement();
                        int tmp;
                        if (!int.TryParse(content[index], out tmp))
                        {
                            break;
                        }
                        param.Id = tmp;
                        if (!int.TryParse(content[index + 1], out tmp))
                        {
                            break;
                        }
                        param.Wigth = tmp;
                        targetList.Add(param);
                        index += 1;
                    }
                    catch (Exception)
                    {
                        isDone = false;
                        break;
                    }
                }
            }
            if (!isDone)
            {
                return false;
            }
            return true;
        }
    }
}
