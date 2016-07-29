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
    class StageLogicPointDescConfigImporter:AbstractExcelImporter
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

            StageLogicPointDescConfigTable config = new StageLogicPointDescConfigTable();
            tbase = config;
            config.LogicPointMap = new Dictionary<int, StageLogicPointDescConfig>();

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

                    
                    List<LogicPointElement> tmpList = new List<LogicPointElement>();
                    if (!DecodeOptionList(values[i], ref index, tmpList))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，权重列表解析出错", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    StageLogicPointDescConfig c = new StageLogicPointDescConfig();
                    c.Id = id;
                    c.PointList = tmpList;
                    config.LogicPointMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.STAGE_LOGIC_POINT_DESC_CONFIG;
        }
        private bool DecodeOptionList(string[] content, ref int index, List<LogicPointElement> targetList)
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
                        LogicPointElement param = new LogicPointElement();
                        int tmp;
                        if (!int.TryParse(content[index], out tmp))
                        {
                            break;
                        }
                        param.Id = tmp;
                        if (!VaildUtil.TryConvertInt(content[index + 1], out tmp,0,1))
                        {
                            break;
                        }
                        param.Type = (LogicPointType)tmp;
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
