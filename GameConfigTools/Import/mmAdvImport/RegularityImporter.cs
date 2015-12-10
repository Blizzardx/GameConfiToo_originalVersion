//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// FileName : RegularityImporter
//
// Created by : Baoxue at 2015/12/10 15:34:29
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

class RegularityImporter : AbstractExcelImporter
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

        RegularityGameConfigTable config = new RegularityGameConfigTable();
        tbase = config;
        config.RegularityConfigMap = new List<RegularityGameConfig>();

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

                RegularityGameConfig c = new RegularityGameConfig();
                float difId;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out difId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度系数必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                    return;
                }
                // check "("
                c.OptionList = new List<RegularityGameOption>();

                string tmp = values[i][index++];
                if(tmp == "(")
                {
                    while (true)
                    {
                        string name = values[i][index++];
                        if (string.IsNullOrEmpty(name) || name == ")" || name == "(")
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，选项名字有错误或者没有跟是否显示配对", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        int isVisable = -1;
                        if (!VaildUtil.TryConvertInt(values[i][index++], out isVisable))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，选项名字有错误或者没有跟是否显示配对", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        if (isVisable != 0 && isVisable != 1)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，选项是否显示必须填0或1", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        RegularityGameOption elem = new RegularityGameOption();
                        elem.Name = name;
                        elem.IsVisable = isVisable == 1;
                        c.OptionList.Add(elem);
                        string tmp1 = values[i][index];
                        if (tmp1 == ")")
                        {
                            ++ index;
                            break;
                        }
                    }
                }
                else
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，括号为中文或者括号没配对", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                // check "("
                c.AnswerList = new List<string>();

                string tmpBegin = values[i][index++];
                if (tmpBegin == "(")
                {
                    while (true)
                    {
                        string name = values[i][index++];
                        if (string.IsNullOrEmpty(name) || name == ")" || name == "(")
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，选项名字有错误或者没有跟是否显示配对", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        c.AnswerList.Add(name);

                        string tmp1 = values[i][index];
                        if (tmp1 == ")")
                        {
                            ++ index;
                            break;
                        }
                    }
                }
                else
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，括号为中文或者括号没配对", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                c.Difficultyid = difId;

                config.RegularityConfigMap.Add(c);
            }
        }
    }

    protected override string GetConfigName()
    {
        return SysConstant.REGULARITY_CONFIG;
    }
}


