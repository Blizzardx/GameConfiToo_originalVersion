using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using Common.Config;
using Common.Config.Table;

namespace GameConfigTools.Import
{
    class FlightImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            root = new XElement("root");

            FlightGameConfigTable config = new FlightGameConfigTable();
            tbase = config;
            config.FlightConfigList = new List<FlightGameConfig>();
            string[] sheetNames = this.GetSheetNames();

            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    FlightGameConfig flightGameConfig = new FlightGameConfig();
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int row = i + 1;
                    int index = 0;

                    float difficulty;
                    if (!VaildUtil.TryConvertFloat(values[i][index++], out difficulty))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度级别(ID)必须为0 - {4}浮点型", this.GetConfigName(), sheetName, row, index, float.MaxValue);
                        return;
                    }
                    float frequency;
                    if (!VaildUtil.TryConvertFloat(values[i][index++], out frequency))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，频率周期(ID)必须为0 - {4}浮点型", this.GetConfigName(), sheetName, row, index, float.MaxValue);
                        return;
                    }
                    flightGameConfig.Difficultyid = difficulty;
                    flightGameConfig.Frequency = frequency;
                    config.FlightConfigList.Add(flightGameConfig);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.FLIGHT_CONFIG;
        }
    }
}
