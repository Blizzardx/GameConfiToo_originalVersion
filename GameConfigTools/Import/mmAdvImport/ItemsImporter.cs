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
    public class ItemsImporter : AbstractExcelImporter
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

            ItemsConfigTable config = new ItemsConfigTable();
            tbase = config;
            config.PropsConfigMap = new Dictionary<int, ItemsConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int firstType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out firstType, 1, 100))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具一级分类必须为1 - 100整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int secondType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out secondType, 1, 100))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具二级分类必须为1 - 100整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    string icon = values[i][index++];
                    string dropIcon = values[i][index++];
                    int quality;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quality, 1, 5))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具品质必须为1 - 5整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int sellGold;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sellGold))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具出售金币数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int Accessmessage;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out Accessmessage))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，获取途径messageID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int useLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out useLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具使用条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int useFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out useFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具使用功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int canSell;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canSell, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具能否出售必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int canUse;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canUse, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具能否使用必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int pos = 0;
                    int attribute = 0;
                    attribute |= canSell << pos++;
                    attribute |= canUse << pos++;

                    XElement propsE = new XElement("props");
                    root.Add(propsE);
                    propsE.Add(new XAttribute("id", id));
                    propsE.Add(new XAttribute("name", name));
                    propsE.Add(new XAttribute("firstType", firstType));
                    propsE.Add(new XAttribute("secondType", secondType));
                    propsE.Add(new XAttribute("quality", quality));
                    propsE.Add(new XAttribute("sellGold", sellGold));
                    propsE.Add(new XAttribute("useLimitId", useLimitId));
                    propsE.Add(new XAttribute("useFuncId", useFuncId));
                    propsE.Add(new XAttribute("attribute", attribute));

                    ItemsConfig c = new ItemsConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.DescMessageId = descMessageId;
                    c.FirstType = (sbyte)firstType;
                    c.SecondType = (sbyte)secondType;
                    c.Icon = icon;
                    c.DropIcon = dropIcon;
                    c.Quality = (sbyte)quality;
                    c.SellGold = sellGold;
                    c.UseLimitId = useLimitId;
                    c.UseFuncId = useFuncId;
                    c.Attribute = attribute;
                    config.PropsConfigMap.Add(c.Id, c);
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.ITEMS_CONFIG;
        }
    }
}
