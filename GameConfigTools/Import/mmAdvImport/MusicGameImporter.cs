//========================================================================
// Copyright(C): CYTX
//
// FileName : MusicGameImporter
// 
// Created by : LeoLi at 2015/12/29 15:44:36
//
// Purpose : 
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
public class MusicGameImporter : AbstractExcelImporter
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

        MusicGameConfigTable table = new MusicGameConfigTable();
        tbase = table;
        table.MusicRangeConfigMap = new List<MusicGameRangeConfig>();
        table.MusicSpeedConfigMap = new List<MusicGameSpeedConfig>();
        table.MusicErrorConfigMap = new List<MusicGameErrorConfig>();

        string[] sheetNames = this.GetSheetNames();
        for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
        {
            string sheetName = sheetNames[sheetIndex];

            if (sheetName == "TargetRange")
            {
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int row = i + 1;
                    int index = 0;

                    MusicGameRangeConfig c = new MusicGameRangeConfig();
                    float difId;
                    if (!VaildUtil.TryConvertFloat(values[i][index++], out difId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度系数 必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    float range;
                    if (!VaildUtil.TryConvertFloat(values[i][index++], out range))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，点击范围 必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    c.Difficultyid = difId;
                    c.Range = range;

                    table.MusicRangeConfigMap.Add(c);
                }
            }
            else if (sheetName == "MusicSpeed")
            {
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int row = i + 1;
                    int index = 0;

                    MusicGameSpeedConfig c = new MusicGameSpeedConfig();
                    float difId;
                    if (!VaildUtil.TryConvertFloat(values[i][index++], out difId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度系数 必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    float speed;
                    if (!VaildUtil.TryConvertFloat(values[i][index++], out speed))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，音乐速度 必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    c.Difficultyid = difId;
                    c.Speed = speed;

                    table.MusicSpeedConfigMap.Add(c);
                }
            }
            else if (sheetName == "ErrorCount")
            {
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int row = i + 1;
                    int index = 0;

                    MusicGameErrorConfig c = new MusicGameErrorConfig();
                    float difId;
                    if (!VaildUtil.TryConvertFloat(values[i][index++], out difId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度系数 必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    int errorCount;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out errorCount))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，漏点次数 必须为Int型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    c.Difficultyid = difId;
                    c.ErrorCount = errorCount;

                    table.MusicErrorConfigMap.Add(c);
                }
            }

           
        }
    }

    protected override string GetConfigName()
    {
        return SysConstant.MUSICGAME_CONFIG;
    }
}

