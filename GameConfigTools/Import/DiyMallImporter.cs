using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class DiyMallImporter : AbstractExcelImporter
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

            DiyMallConfigTable config = new DiyMallConfigTable();
            tbase = config;
            config.DiyMallConfigMap = new Dictionary<int, Config.DiyMallConfig>();

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

                    int itemId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out itemId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，itemId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    if (config.DiyMallConfigMap.ContainsKey(itemId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，itemId重复", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    //备注
                    index++;

                    int gender;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out gender, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，性别必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int currencyType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out currencyType, 1, 3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，货币类型必须为1 - 3整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int price;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out price))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，价格必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string defaultColor = values[i][index++];
                    if (!string.IsNullOrEmpty(defaultColor))
                    {
                        defaultColor = "#"+ defaultColor;
                    }
                    // skill list
                    List<string> colorList = new List<string>();
                    if (!DecodeList(values[i], ref index, colorList))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误， 解析可用颜色列表出错", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    for(int j=0;j<colorList.Count;++j)
                    {
                        if (!string.IsNullOrEmpty(colorList[j]))
                        {
                            colorList[j] = "#" + colorList[j];
                        }
                    }
                    XElement itemE = new XElement("item");
                    root.Add(itemE);
                    itemE.Add(new XAttribute("itemId", itemId));
                    itemE.Add(new XAttribute("gender", gender));
                    itemE.Add(new XAttribute("currencyType", currencyType));
                    itemE.Add(new XAttribute("price", price));
                    itemE.Add(new XAttribute("defaultColor", defaultColor));

                    XElement colorsE = new XElement("availableColors");
                    itemE.Add(colorsE);
                    foreach (var elem in colorList)
                    {
                        colorsE.Add(new XElement("availableColor", elem));
                    }

                    DiyMallConfig c = new DiyMallConfig();
                    c.ItemId = itemId;
                    c.Gender = gender;
                    c.CurrencyType = currencyType;
                    c.Price = price;
                    c.AvailableClos = colorList;
                    c.DefaultColor = defaultColor;
                    config.DiyMallConfigMap.Add(c.ItemId, c);
                }
            }
        }

        private bool DecodeList(string[] content, ref int index, List<string> targetList)
        {
            if (content[index++] != "(")
            {
                return false;
            }
            bool isDone = false;
            for (; index < content.Length; ++index)
            {
                string s = content[index];

                if (s == ")")
                {
                    ++index;
                    isDone = true;
                    break;
                }
                else
                {
                    targetList.Add(s);
                }
            }
            if (!isDone)
            {
                return false;
            }
            return true;
        }
        protected override string GetConfigName()
        {
            return SysConstant.DIY_MALL_CONFIG;
        }
    }
}
