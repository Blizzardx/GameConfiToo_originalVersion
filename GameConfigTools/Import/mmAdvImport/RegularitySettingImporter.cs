//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// FileName : RegularitySettingImporter
//
// Created by : Baoxue at 2015/12/11 14:16:03
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Import;
using GameConfigTools.Util;
using Thrift.Protocol;

public class RegularitySettingImporter : AbstractExcelImporter
{
    protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
    {
        root = null;
        tbase = null;
        if (sheetValues == null || sheetValues.Count == 0)
        {
            return;
        }
        root = new XElement("regularitySetting");

        RegularityGameSettingTable config = new RegularityGameSettingTable();
        tbase = config;

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

                int leftTime;
                if (!VaildUtil.TryConvertInt(values[i][index++], out leftTime))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，游戏时间必须为0 - {4}整型，秒", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                int count;
                if (!VaildUtil.TryConvertInt(values[i][index++], out count))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，游戏次数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                
                config.PlayCountLimit = count;
                config.PlayTime = leftTime;
            }
        }
    }

    protected override string GetConfigName()
    {
        return SysConstant.REGULARITY_SETTING_CONFIG;
    }
}
