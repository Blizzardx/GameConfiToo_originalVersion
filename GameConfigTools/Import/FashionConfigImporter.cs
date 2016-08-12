using System.Collections.Generic;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class FashionConfigImporter : AbstractExcelImporter
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

            FashionConfigTable config = new FashionConfigTable();
            tbase = config;
            config.FashionConfigMap = new Dictionary<int, FashionConfig>();

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
                    int decomposeId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out decomposeId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分解ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string icon = values[i][index++];

                    int firstType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out firstType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，类型必须为1 - 3的整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    string resource = values[i][index++];
                    int activeLimit;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeLimit))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，类型必须为整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int activeCostId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeCostId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，普通攻击必须为0 - {4}整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int mainPanelTipType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out mainPanelTipType,1,3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生功能ID必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, 1,3);
                        return;
                    }
                    int positionPanelTipType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out positionPanelTipType, 1, 3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生功能ID必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, 1, 3);
                        return;
                    }
                    int activeType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out activeType, 1, 2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生功能ID必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, 1, 3);
                        return;
                    }

                    XElement monsterE = new XElement("fashion");
                    root.Add(monsterE);
                    monsterE.Add(new XAttribute("id", id));
                    monsterE.Add(new XAttribute("name", name));
                    monsterE.Add(new XAttribute("decomposeId", decomposeId));
                    monsterE.Add(new XAttribute("firstType", firstType));
                    monsterE.Add(new XAttribute("activeCostId", activeCostId));
                    monsterE.Add(new XAttribute("activeLimit", activeLimit));

                    FashionConfig c = new FashionConfig();
                    c.Id = id;
                    c.NameId = nameMessageId;
                    c.DescId = descMessageId;
                    c.Icon = icon;
                    c.FirstType = firstType;
                    c.Resource = resource;
                    c.ActiveCostId = activeCostId;
                    c.ActiveLimitId = activeLimit;
                    c.MainPanelTipType = mainPanelTipType;
                    c.PosPanelTipType = positionPanelTipType;
                    c.ActiveType = activeType;

                    if (config.FashionConfigMap.ContainsKey(id))
                    {
                        errMsg = " id 重复 " + id;
                        return;
                    }
                    config.FashionConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.FASHION_CONFIG;

        }
    }
}
