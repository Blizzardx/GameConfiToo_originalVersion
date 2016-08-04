using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using GameConfigTools.Constant;

namespace GameConfigTools.Import
{
    public class ExchangeImporter : AbstractExcelImporter
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
            //ExchangeConfigTable config = new ExchangeConfigTable();
            //config.ExchangeConfigMap = new Dictionary<int, ExchangeConfig>();
            //tbase = config;

            //string[] sheetNames = this.GetSheetNames();
            //for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            //{
            //    string sheetName = sheetNames[sheetIndex];
            //    string[][] values = sheetValues[sheetIndex];
            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        if (!this.IsLineNotNull(values[i]))
            //        {
            //            continue;
            //        }
            //        int row = i + 1;
            //        int index = 0;

            //        XElement exchangeElement = new XElement("exchange");
            //        root.Add(exchangeElement);

            //        ExchangeConfig exchangeConfig = new ExchangeConfig();

            //        int exchangeId;
            //        if (!int.TryParse(values[i][index++], out exchangeId))
            //        {
            //            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，兑换ID必须为整型", this.GetConfigName(), sheetName, row, index);
            //            return;
            //        }

            //        exchangeElement.Add(new XAttribute("id", exchangeId));
            //        exchangeConfig.Id = exchangeId;
            //        config.ExchangeConfigMap.Add(exchangeConfig.Id, exchangeConfig);

            //        //兑换目标的名称
            //        index++;
            //        //兑换目标的星级
            //        index++;
            //        int exchangeItemId;
            //        if (!int.TryParse(values[i][index++], out exchangeItemId))
            //        {
            //            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，兑换的道具ID必须为整型", this.GetConfigName(), sheetName, row, index);
            //            return;
            //        }
            //        exchangeElement.Add(new XAttribute("exchangeItemId", exchangeItemId));
            //        exchangeConfig.ExchangeItemId = exchangeItemId;

            //        index++;
            //        List<string> list = new List<string>();
            //        for (int j = index; j < values[i].Length; j++)
            //        {
            //            list.Add(values[i][j]);
            //        }
            //        List<List<string>> resultList = this.ParseBracket(list);
            //        if (resultList == null || resultList.Count < 1)
            //        {
            //            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，兑换条件配置不合法", this.GetConfigName(), sheetName, row);
            //            return;
            //        }

            //        List<string> itemList = new List<string>();

            //        foreach (string str in resultList[0])
            //        {
            //            if (str == null || str.Trim() == "")
            //            {
            //                continue;
            //            }
            //            itemList.Add(str);
            //        }

            //        //解析兑换所需道具
            //        if (itemList == null || itemList.Count == 0 || itemList.Count % 2 != 0)
            //        {
            //            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，兑换条件必须是道具ID和数量成对出现", this.GetConfigName(), sheetName, row);
            //            return;
            //        }
            //        exchangeConfig.NeedItemConfigList = new List<NeedItemConfig>();
            //        List<XElement> needItemList = new List<XElement>(itemList.Count / 2);
            //        for (int k = 0; k < itemList.Count / 2; k++)
            //        {
            //            needItemList.Add(new XElement("needItem"));
            //            exchangeConfig.NeedItemConfigList.Add(new NeedItemConfig());
            //        }
            //        exchangeElement.Add(needItemList);
            //        for (int k = 0; k < itemList.Count; k++)
            //        {
            //            int itemId = 0;
            //            int count = 0;
            //            if (k % 2 == 0)
            //            {
            //                if (!int.TryParse(itemList[k], out itemId))
            //                {
            //                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，道具ID:[{3}]必须为整型", this.GetConfigName(), sheetName, row, itemList[k]);
            //                    return;
            //                }
            //                needItemList[k / 2].Add(new XAttribute("itemId", itemId));
            //                exchangeConfig.NeedItemConfigList[k / 2].ItemId = itemId;
            //            }
            //            else
            //            {
            //                if (!int.TryParse(itemList[k], out count))
            //                {
            //                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，道具数量:[{3}]必须为整型", this.GetConfigName(), sheetName, row, itemList[k]);
            //                    return;
            //                }
            //                needItemList[k / 2].Add(new XAttribute("count", count));
            //                exchangeConfig.NeedItemConfigList[k / 2].Count = (short)count;
            //            }
            //        }
            //        List<string> currencyList = new List<string>();

            //        if (resultList.Count > 1 && resultList[1] != null)
            //        {
            //            foreach (string str in resultList[1])
            //            {
            //                if (str == null || str.Trim() == "")
            //                {
            //                    continue;
            //                }
            //                currencyList.Add(str);
            //            }
            //        }
            //        //解析兑换所需货币
            //        if (currencyList.Count > 0)
            //        {
            //            //解析兑换所需货币
            //            if (currencyList.Count % 2 != 0)
            //            {
            //                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，兑换条件必须是货币类型和货币数量成对出现", this.GetConfigName(), sheetName, row);
            //                return;
            //            }
            //            List<XElement> needCurrencyList = new List<XElement>(currencyList.Count / 2);
            //            exchangeConfig.NeedCurrencyConfigList = new List<NeedCurrencyConfig>();
            //            for (int k = 0; k < currencyList.Count / 2; k++)
            //            {
            //                needCurrencyList.Add(new XElement("needCurrency"));
            //                exchangeConfig.NeedCurrencyConfigList.Add(new NeedCurrencyConfig());
            //            }
            //            exchangeElement.Add(needCurrencyList);
            //            for (int k = 0; k < currencyList.Count; k++)
            //            {
            //                int type = 0;
            //                int count = 0;
            //                if (k % 2 == 0)
            //                {
            //                    if (!int.TryParse(currencyList[k], out type))
            //                    {
            //                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，货币类型:[{3}]必须为整型", this.GetConfigName(), sheetName, row, currencyList[k]);
            //                        return;
            //                    }
            //                    if (type != 1 && type != 2)
            //                    {
            //                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，货币类型:[{3}]必须为[1(钻石)或者2(金币)]", this.GetConfigName(), sheetName, row, currencyList[k]);
            //                        return;
            //                    }
            //                    needCurrencyList[k / 2].Add(new XAttribute("type", type));
            //                    exchangeConfig.NeedCurrencyConfigList[k / 2].Type = (sbyte)type;
            //                }
            //                else
            //                {
            //                    if (!int.TryParse(currencyList[k], out count))
            //                    {
            //                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，货币数量:[{3}]必须为整型", this.GetConfigName(), sheetName, row, currencyList[k]);
            //                        return;
            //                    }
            //                    needCurrencyList[k / 2].Add(new XAttribute("count", count));
            //                    exchangeConfig.NeedCurrencyConfigList[k / 2].Count = count;
            //                }
            //            }
            //        }
            //    }
            //}
        }
        protected override string GetConfigName()
        {
            return SysConstant.EXCHANGE_CONFIG;
        }
    }
}
