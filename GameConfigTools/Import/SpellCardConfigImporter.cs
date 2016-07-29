using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class SpellCardConfigImporter : AbstractExcelImporter
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

            SpellCardConfigTable config = new SpellCardConfigTable();
            tbase = config;
            config.SpellCardConfigMap = new Dictionary<int, SpellCardConfig>();

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
                    int quality;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quality))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string icon = values[i][index++];

                    int activeLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int activeFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int sortId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sortId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int displayLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out displayLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int tipType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tipType,1,3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int disattachFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out disattachFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int attachFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out attachFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    XElement monsterE = new XElement("spellcard");
                    root.Add(monsterE);
                    monsterE.Add(new XAttribute("id", id));
                    monsterE.Add(new XAttribute("name", name));
                    monsterE.Add(new XAttribute("quality", quality));
                    monsterE.Add(new XAttribute("activeLimitId", activeLimitId));
                    monsterE.Add(new XAttribute("activeFuncId", activeFuncId));
                    monsterE.Add(new XAttribute("sortId", sortId));
                    monsterE.Add(new XAttribute("displayLimitId", displayLimitId));
                    //monsterE.Add(new XAttribute("disattachFuncId", disattachFuncId));
                    //monsterE.Add(new XAttribute("attachFuncId", attachFuncId));

                    SpellCardConfig c = new SpellCardConfig();
                    c.Id = id;
                    c.Quality = quality;
                    c.NameId = nameMessageId;
                    c.DescId = descMessageId;
                    c.Icon = icon;
                    c.SortId = sortId;
                    c.ActiveLimitId = activeLimitId;
                    c.ActiveFuncId = activeFuncId;
                    c.DisplayLimitId = displayLimitId;
                    c.TipType = tipType;
                    
                    if (config.SpellCardConfigMap.ContainsKey(id))
                    {
                        errMsg = " id 重复 " + id;
                        return;
                    }
                    config.SpellCardConfigMap.Add(c.Id, c);
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.SPELLCARD_CONFIG;
        }
    }
}
