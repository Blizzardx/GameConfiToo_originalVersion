//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// FileName : SkillImporter
//
// Created by : Baoxue at 2015/11/23 11:54:09
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Import;
using GameConfigTools.Util;
using Thrift.Protocol;

class SkillImporter : AbstractExcelImporter
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

        SkillConfigTable config = new SkillConfigTable();
        tbase = config;
        config.SkillConfigMap = new Dictionary<int, SkillConfig>();

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
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能 ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                string name = values[i][index++];

                int nameMessageId;
                if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能 名字消息ID类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                int descMessageId;
                if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务描述ID类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                string skillIcon = values[i][index++];
               
                int actionId;
                if (!VaildUtil.TryConvertInt(values[i][index++], out actionId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，动画ID 必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                int priority;
                if (!VaildUtil.TryConvertInt(values[i][index++], out priority, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能优先级必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                int skillType;
                if (!VaildUtil.TryConvertInt(values[i][index++], out skillType, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，skilltype必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                int quality;
                if (!VaildUtil.TryConvertInt(values[i][index++], out quality, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，quality必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                int level;
                if (!VaildUtil.TryConvertInt(values[i][index++], out level, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，level必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int beginCD;
                if (!VaildUtil.TryConvertInt(values[i][index++], out beginCD, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，beginCD必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int initCd;
                if (!VaildUtil.TryConvertInt(values[i][index++], out initCd, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，initCd必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int addCd;
                if (!VaildUtil.TryConvertInt(values[i][index++], out addCd, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，initCd必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int perLimit;
                if (!VaildUtil.TryConvertInt(values[i][index++], out perLimit, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，perLimit必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int perFunc;
                if (!VaildUtil.TryConvertInt(values[i][index++], out perFunc, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，preFuncId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int target;
                if (!VaildUtil.TryConvertInt(values[i][index++], out target, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，target必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int limit;
                if (!VaildUtil.TryConvertInt(values[i][index++], out limit, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，limit必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }
                int func;
                if (!VaildUtil.TryConvertInt(values[i][index++], out func, 0, int.MaxValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，func必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return;
                }

                XElement buffE = new XElement("skill");
                root.Add(buffE);

                buffE.Add(new XAttribute("id", id));
                buffE.Add(new XAttribute("name", name));
                buffE.Add(new XAttribute("descMessageId", descMessageId));
                buffE.Add(new XAttribute("skillIcon", skillIcon));
                buffE.Add(new XAttribute("actionId", actionId));
                buffE.Add(new XAttribute("priority", priority));
                buffE.Add(new XAttribute("skillType", skillType));
                buffE.Add(new XAttribute("quality", quality));
                buffE.Add(new XAttribute("level", level));
                buffE.Add(new XAttribute("beginCD", beginCD));
                buffE.Add(new XAttribute("initCd", initCd));
                buffE.Add(new XAttribute("addCd", addCd));
                buffE.Add(new XAttribute("perLimit", perLimit));
                buffE.Add(new XAttribute("perFunc", perFunc));
                buffE.Add(new XAttribute("target", target));
                buffE.Add(new XAttribute("limit", limit));
                buffE.Add(new XAttribute("func", func));

                SkillConfig c = new SkillConfig();
                c.Id = id;
                c.NameMessageId = nameMessageId;
                c.DescMessageId = descMessageId;
                c.SkillIcon = skillIcon;
                c.ActionId = actionId;
                c.Priority = priority;
                c.SkillType = skillType;
                c.Quality = quality;
                c.Level = level;
                c.BeginCd = beginCD;
                c.InitCd = initCd;
                c.AddCd = addCd;
                c.PerLimitId = perLimit;
                c.PerFuncId = perFunc;
                c.TargeteId = target;
                c.LimitId = limit;
                c.FuncId = func;

                config.SkillConfigMap.Add(c.Id, c);
            }
        }
    }

    protected override string GetConfigName()
    {
        return SysConstant.SKILL_CONFIG;
    }
}

