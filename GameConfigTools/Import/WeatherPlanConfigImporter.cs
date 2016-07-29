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
    class WeatherPlanConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root,
            out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            WeatherPlanConfigTable config = new WeatherPlanConfigTable();
            tbase = config;
            config.WeatherPlanConfigMap = new Dictionary<int, WeatherPlanConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物ID必须为0 - {4}整型",
                            this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<WeatherElement> targetList = new List<WeatherElement>();
                    for (;;)
                    {
                        List<string> group = new List<string>();
                        WeatherElement elem = new WeatherElement();
                        if (index >= values[i].Length || string.IsNullOrEmpty(values[i][index]))
                        {
                            break;
                        }
                        if (!DecodeList(values[i], ref index, group))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误", this.GetConfigName(),
                                sheetName, row, index);
                            return;
                        }
                        else
                        {
                            if (group.Count != 2)
                            {
                                return;
                            }
                            int type;
                            if (!VaildUtil.TryConvertInt(group[0], out type, 0, 2))
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，type必须为0 - {4}整型",
                                    this.GetConfigName(), sheetName, row, index, 2);
                                return;
                            }
                            int elemId;
                            if (!VaildUtil.TryConvertInt(group[1], out elemId))
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，elemId必须为0 - {4}整型",
                                    this.GetConfigName(), sheetName, row, index, int.MaxValue);
                                return;
                            }
                            elem.Id = elemId;
                            elem.Type = type;
                            targetList.Add(elem);
                        }
                    }
                    WeatherPlanConfig line = new WeatherPlanConfig();
                    line.Id = id;
                    line.PlanList = targetList;
                    config.WeatherPlanConfigMap.Add(id, line);
                }
            }
        }

        private bool DecodeList(string[] content, ref int index, List<string> targetList)
        {
            if (content[index++] != "(")
            {
                return false;
            }
            bool isDone = false;
            for (; index < content.Length; ++index)
            {
                string s = content[index];

                if (s == ")")
                {
                    ++index;
                    isDone = true;
                    break;
                }
                else
                {
                    targetList.Add(s);
                }
            }
            if (!isDone)
            {
                return false;
            }
            return true;
        }

        protected override string GetConfigName()
        {
            return SysConstant.WEATHER_PLAN_CONFIG;
        }
    }
}
