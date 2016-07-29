using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using Thrift.Protocol;
using GameConfigTools.Constant;

namespace GameConfigTools.Import
{
    public class DropImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            ISet<int> dropListIdSet = new HashSet<int>();

            root = new XElement("root");

            DropConfigTable config = new DropConfigTable();
            tbase = config;
            config.DropListConfigMap = new Dictionary<int, DropListConfig>();

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
                    if (!int.TryParse(values[i][index++], out id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，掉落列表ID:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    if (!dropListIdSet.Add(id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，掉落列表ID:[{4}]重复", this.GetConfigName(), sheetName, row, index, id);
                        return;
                    }
                    int dropLimitId;
                    if (!int.TryParse(values[i][index++], out dropLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，掉落条件ID:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    index++;
                    List<string> list = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        list.Add(values[i][j]);
                    }
                    List<List<string>> resultList = this.ParseBracket(list);
                    if (resultList == null || resultList.Count < 1)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，掉落列表配置不合法", this.GetConfigName(), sheetName, row);
                        return;
                    }

                    XElement dropListElement = new XElement("drop");
                    dropListElement.Add(new XAttribute("id", id));
                    dropListElement.Add(new XAttribute("dropLimitId", dropLimitId));
                    root.Add(dropListElement);

                    DropListConfig c = new DropListConfig();
                    c.DropItemList = new List<DropItem>();
                    c.DropListId = id;
                    c.DropLimitId = dropLimitId;

                    config.DropListConfigMap.Add(c.DropListId, c);

                    for (int k = 0; k < resultList.Count; k++)
                    {
                        List<string> dropList = resultList[k];
                        if (dropList.Count < 4)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，第{3}个掉落道具配置错误", this.GetConfigName(), sheetName, row, (k + 1));
                            return;
                        }
                        int dropIndex = 0;
                        int itemId;
                        if (!int.TryParse(dropList[dropIndex++], out itemId))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，第{3}个掉落道具ID:[{4}]必须为整型", this.GetConfigName(), sheetName, row, (k + 1), dropList[dropIndex - 1]);
                            return;
                        }
                        int minDropCount;
                        if (!int.TryParse(dropList[dropIndex++], out minDropCount))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，第{3}个掉落道具，最小掉落数量:[{4}]必须为整型", this.GetConfigName(), sheetName, row, (k + 1), dropList[dropIndex - 1]);
                            return;
                        }
                        int maxDropCount;
                        if (!int.TryParse(dropList[dropIndex++], out maxDropCount))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，第{3}个掉落道具，最大掉落数量:[{4}]必须为整型", this.GetConfigName(), sheetName, row, (k + 1), dropList[dropIndex - 1]);
                            return;
                        }
                        int weight;
                        if (!int.TryParse(dropList[dropIndex++], out weight))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，第{3}个掉落道具，权重:[{4}]必须为整型", this.GetConfigName(), sheetName, row, (k + 1), dropList[dropIndex - 1]);
                            return;
                        }

                        XElement dropItemElement = new XElement("dropItem");
                        dropItemElement.Add(new XAttribute("itemId", itemId));
                        dropItemElement.Add(new XAttribute("minDropCount", minDropCount));
                        dropItemElement.Add(new XAttribute("maxDropCount", maxDropCount));
                        dropItemElement.Add(new XAttribute("weight", weight));
                        dropListElement.Add(dropItemElement);

                        DropItem dropItem = new DropItem();
                        dropItem.ItemId = itemId;
                        dropItem.MinDropCount = (sbyte)minDropCount;
                        dropItem.MaxDropCount = (sbyte)maxDropCount;
                        dropItem.Weight = weight;
                        c.DropItemList.Add(dropItem);
                    }
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.DROP_CONFIG;
        }
    }
}
