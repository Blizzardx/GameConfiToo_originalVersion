using Config;
using Config.Table;
using GameConfigTools.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class ConsumeImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {

            root = new XElement("root");

            ConsumeConfigTable config = new ConsumeConfigTable();
            config.ConsumeConfigMap = new Dictionary<int, ConsumeConfig>();
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

                    XElement consumeE = new XElement("consume");
                    root.Add(consumeE);

                    ConsumeConfig c = new ConsumeConfig();

                    int consumeId;
                    if (!int.TryParse(values[i][index++], out consumeId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，消耗ID必须为整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    consumeE.Add(new XAttribute("id", consumeId));
                    c.Id = consumeId;
                    config.ConsumeConfigMap.Add(consumeId, c);

                    //消耗描述
                    index++;

                    List<string> list = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        list.Add(values[i][j]);
                    }
                    List<List<string>> resultList = this.ParseBracket(list);
                    if (resultList == null || resultList.Count < 1)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，消耗条件配置不合法", this.GetConfigName(), sheetName, row);
                        return;
                    }

                    List<string> itemList = new List<string>();

                    foreach (string str in resultList[0])
                    {
                        if (str == null || str.Trim() == "")
                        {
                            continue;
                        }
                        itemList.Add(str);
                    }

                    //解析兑换所需道具
                    if (itemList.Count > 0 && itemList.Count % 2 != 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，兑换条件必须是道具ID和数量成对出现", this.GetConfigName(), sheetName, row);
                        return;
                    }
                    if(itemList.Count > 0)
                    {
                        c.NeedItemConfigList = new List<NeedItemConfig>();
                        List<XElement> needItemList = new List<XElement>(itemList.Count / 2);
                        for (int k = 0; k < itemList.Count / 2; k++)
                        {
                            needItemList.Add(new XElement("needItem"));
                            c.NeedItemConfigList.Add(new NeedItemConfig());
                        }
                        consumeE.Add(needItemList);
                        for (int k = 0; k < itemList.Count; k++)
                        {
                            int itemId = 0;
                            int count = 0;
                            if (k % 2 == 0)
                            {
                                if (!int.TryParse(itemList[k], out itemId))
                                {
                                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，道具ID:[{3}]必须为整型", this.GetConfigName(), sheetName, row, itemList[k]);
                                    return;
                                }
                                needItemList[k / 2].Add(new XAttribute("itemId", itemId));
                                c.NeedItemConfigList[k / 2].ItemId = itemId;
                            }
                            else
                            {
                                if (!int.TryParse(itemList[k], out count))
                                {
                                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，道具数量:[{3}]必须为整型", this.GetConfigName(), sheetName, row, itemList[k]);
                                    return;
                                }
                                needItemList[k / 2].Add(new XAttribute("count", count));
                                c.NeedItemConfigList[k / 2].Count = (short)count;
                            }
                        }
                    }
                    
                    List<string> currencyList = new List<string>();

                    if (resultList.Count > 1 && resultList[1] != null)
                    {
                        foreach (string str in resultList[1])
                        {
                            if (str == null || str.Trim() == "")
                            {
                                continue;
                            }
                            currencyList.Add(str);
                        }
                    }
                    //解析兑换所需货币
                    if (currencyList.Count > 0)
                    {
                        //解析兑换所需货币
                        if (currencyList.Count % 2 != 0)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，消耗条件必须是货币类型和货币数量成对出现", this.GetConfigName(), sheetName, row);
                            return;
                        }
                        List<XElement> needCurrencyList = new List<XElement>(currencyList.Count / 2);
                        c.NeedCurrencyConfigList = new List<NeedCurrencyConfig>();
                        for (int k = 0; k < currencyList.Count / 2; k++)
                        {
                            needCurrencyList.Add(new XElement("needCurrency"));
                            c.NeedCurrencyConfigList.Add(new NeedCurrencyConfig());
                        }
                        consumeE.Add(needCurrencyList);
                        for (int k = 0; k < currencyList.Count; k++)
                        {
                            int type = 0;
                            int count = 0;
                            if (k % 2 == 0)
                            {
                                if (!int.TryParse(currencyList[k], out type))
                                {
                                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，货币类型:[{3}]必须为整型", this.GetConfigName(), sheetName, row, currencyList[k]);
                                    return;
                                }
                                if (type < 1 || type > 3)
                                {
                                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，货币类型错误", this.GetConfigName(), sheetName, row, currencyList[k]);
                                    return;
                                }
                                needCurrencyList[k / 2].Add(new XAttribute("type", type));
                                c.NeedCurrencyConfigList[k / 2].Type = type;
                            }
                            else
                            {
                                if (!int.TryParse(currencyList[k], out count))
                                {
                                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，货币数量:[{3}]必须为整型", this.GetConfigName(), sheetName, row, currencyList[k]);
                                    return;
                                }
                                needCurrencyList[k / 2].Add(new XAttribute("count", count));
                                c.NeedCurrencyConfigList[k / 2].Count = count;
                            }
                        }
                    }

                    if((c.NeedItemConfigList == null || c.NeedItemConfigList.Count == 0) && (c.NeedCurrencyConfigList == null || c.NeedCurrencyConfigList.Count == 0))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，消耗条件至少要有一个", this.GetConfigName(), sheetName, row);
                        return;
                    }
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.CONSUME_CONFIG;
        }
    }
}
