﻿using System;
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
    class RainConfigImporter:AbstractExcelImporter
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

            RainConfigTable config = new RainConfigTable();
            tbase = config;
            config.RainConfigMap = new Dictionary<int, RainConfig>();

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
                    int duringtimemin;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out duringtimemin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，持续时间min必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int duringtimemax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out duringtimemax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，持续时间max必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int funcId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out funcId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，firstTaskFucId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int tickFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，positionid必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int endFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out endFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，positionid必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int tickTargetId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickTargetId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，positionid必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    RainConfig c = new RainConfig();
                    c.Id = id;
                    c.BeginTimeMin = begintimemin;
                    c.BeginTimeMax = begintimemax;
                    c.DuringTimeMin = duringtimemin;
                    c.DuringTimeMax = duringtimemax;
                    c.BeginFuncId = funcId;
                    c.TickFuncId = tickFuncId;
                    c.EndFuncId = endFuncId;
                    c.TickTargetId = tickTargetId;
                    config.RainConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.RAIN_CONFIG;
        }
    }
}
