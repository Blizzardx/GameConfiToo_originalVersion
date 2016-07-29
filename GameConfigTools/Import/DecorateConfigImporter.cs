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
    class DecorateConfigImporter : AbstractExcelImporter
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

            DecorateConfigTable config = new DecorateConfigTable();
            tbase = config;
            config.DecorateConfigMap = new Dictionary<int, DecorateConfig>();

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
                    if (config.DecorateConfigMap.ContainsKey(id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID重复", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    string name = values[i][index++];

                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string icon = values[i][index++];
                    int quality;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quality))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int posId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out posId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string resource = values[i][index++];
                    string desc = values[i][index++];

                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int putonFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out putonFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int takeoffFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out takeoffFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int sortId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sortId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int activeLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int activeFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int activeType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int displayLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out displayLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int mainPanelTipType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out mainPanelTipType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int posPanelTipType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out posPanelTipType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string attachPos = values[i][index++];

                    XElement monsterE = new XElement("decorate");
                    root.Add(monsterE);
                    monsterE.Add(new XAttribute("id", id));
                    monsterE.Add(new XAttribute("name", name));
                    monsterE.Add(new XAttribute("quality", quality));
                    monsterE.Add(new XAttribute("firstType", posId));
                    monsterE.Add(new XAttribute("putonFuncId", putonFuncId));
                    monsterE.Add(new XAttribute("takeOffFuncId", takeoffFuncId));
                    monsterE.Add(new XAttribute("activeLimitId", activeLimitId));
                    monsterE.Add(new XAttribute("activeFuncId", activeFuncId));

                    DecorateConfig c = new DecorateConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.Icon = icon;
                    c.Quality = quality;
                    c.FirstType = posId;
                    c.Resource = resource;
                    c.DescMessageId = descMessageId;
                    c.PutonFuncId = putonFuncId;
                    c.TakeoffFuncId = takeoffFuncId;
                    c.SortId = sortId;
                    c.ActiveLimitId = activeLimitId;
                    c.ActiveFuncId = activeFuncId;
                    c.ActiveType = activeType;
                    c.DisplayLimitId = displayLimitId;
                    c.MainPanelTipType = mainPanelTipType;
                    c.PosPanelTipType = posPanelTipType;
                    c.AttachPos = attachPos;

                    config.DecorateConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.DECORATE_CONFIG;
        }
    }
}
