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
    class StageWeatherPlanConfigImporter:AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            StageWeatherPlanConfigTable config = new StageWeatherPlanConfigTable();
            tbase = config;
            config.StageWeatherPlanConfigMap = new Dictionary<int, StageWeatherPlanConfig>();

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
                    List<OptionElement> targetList = new List<OptionElement>();
                    for (;;)
                    {
                        List<string> group = new List<string>();
                        OptionElement elem = new OptionElement();
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
                            int elemId;
                            if (!VaildUtil.TryConvertInt(group[0], out elemId))
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，elemId必须为0 - {4}整型",
                                    this.GetConfigName(), sheetName, row, index, int.MaxValue);
                                return;
                            }
                            int wigth;
                            if (!VaildUtil.TryConvertInt(group[1], out wigth))
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，type必须为0 - {4}整型",
                                    this.GetConfigName(), sheetName, row, index, int.MaxValue);
                                return;
                            }
                            elem.Id = elemId;
                            elem.Wigth = wigth;
                            targetList.Add(elem);
                        }
                    }
                    StageWeatherPlanConfig line = new StageWeatherPlanConfig();
                    line.Id = id;
                    line.OptionList = targetList;
                    config.StageWeatherPlanConfigMap.Add(id, line);
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
            return SysConstant.STAGE_WEATHER_PLAN_CONFIG;
        }
    }
}
