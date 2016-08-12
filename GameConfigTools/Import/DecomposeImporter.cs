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
    public class DecomposeImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {

            root = new XElement("root");
            tbase = null;

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

                    XElement decomposeE = new XElement("decompose");
                    root.Add(decomposeE);

                    int decomposeId;
                    if (!int.TryParse(values[i][index++], out decomposeId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分解ID必须为整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    decomposeE.Add(new XAttribute("id", decomposeId));

                    //分解描述
                    index++;

                    List<string> list = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        list.Add(values[i][j]);
                    }
                    List<List<string>> resultList = this.ParseBracket(list);
                    if (resultList == null || resultList.Count < 1)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，分解配置不合法", this.GetConfigName(), sheetName, row);
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

                    //解析分解道具
                    if (itemList.Count > 0 && itemList.Count % 2 != 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，分解出来的道具ID和数量成对出现", this.GetConfigName(), sheetName, row);
                        return;
                    }
                    if(itemList.Count > 0)
                    {
                        List<XElement> needItemList = new List<XElement>(itemList.Count / 2);
                        for (int k = 0; k < itemList.Count / 2; k++)
                        {
                            needItemList.Add(new XElement("item"));
                        }
                        decomposeE.Add(needItemList);
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
                            }
                            else
                            {
                                if (!int.TryParse(itemList[k], out count))
                                {
                                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，道具数量:[{3}]必须为整型", this.GetConfigName(), sheetName, row, itemList[k]);
                                    return;
                                }
                                needItemList[k / 2].Add(new XAttribute("count", count));
                            }
                        }
                    }
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.DECOMPOSE_CONFIG;
        }
    }
}
