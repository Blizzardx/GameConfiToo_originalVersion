//========================================================================
// Copyright(C): CYTX
//
// FileName : MusicGameSettingImporter
// 
// Created by : LeoLi at 2015/12/29 15:45:25
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
public class MusicGameSettingImporter : AbstractExcelImporter
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

        MusicGameSettingTable table = new MusicGameSettingTable();
        tbase = table;
        table.MusicConfigMap = new Dictionary<int, MusicGameNoteKeyConfig>();

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

                MusicGameNoteKeyConfig config = new MusicGameNoteKeyConfig();
                int musicId;
                if (!VaildUtil.TryConvertInt(values[i][index++], out musicId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，乐曲ID必须为Int型", this.GetConfigName(), sheetName, row, index);
                    return;
                }
                // check "("
                config.NoteKeyList = new List<MusicGameNoteKey>();
                string tmp = values[i][index++];
                if (tmp == "(")
                {
                    while (true)
                    {
                        float time = 0f;
                        if (!VaildUtil.TryConvertFloat(values[i][index++], out time))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 Time", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        int key = -1;
                        if (!VaildUtil.TryConvertInt(values[i][index++], out key))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 Key", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        MusicGameNoteKey elem = new MusicGameNoteKey();
                        elem.Time = time;
                        elem.Key = key;
                        config.NoteKeyList.Add(elem);
                        string tmp1 = values[i][index];
                        if (tmp1 == ")")
                        {
                            ++index;
                            break;
                        }
                    }
                }
                else
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，括号为中文或者括号没配对", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                if (!table.MusicConfigMap.ContainsKey(musicId))
                    table.MusicConfigMap.Add(musicId, config);

            }
        }
    }
    protected override string GetConfigName()
    {
        return SysConstant.MUSICGAME_SETTING_CONFIG;
    }
}

