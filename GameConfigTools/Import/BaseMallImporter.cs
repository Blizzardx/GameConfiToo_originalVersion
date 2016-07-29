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
    public class BaseMallImporter : AbstractExcelImporter
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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];

                    int tab;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tab, 1, 3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，tab必须为1 - 3的整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int canGive;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canGive, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，能否赠送必须为0 - 1整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int currencyType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out currencyType, 0, 3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，货币类型必须为0 - 3整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int price;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out price))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，价格必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    XElement mallE = new XElement("item");
                    root.Add(mallE);
                    mallE.Add(new XAttribute("itemId", itemId));
                    mallE.Add(new XAttribute("tab", tab));
                    mallE.Add(new XAttribute("canGive", canGive != 0));
                    mallE.Add(new XAttribute("currencyType", currencyType));
                    mallE.Add(new XAttribute("price", price));
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BASE_MALL_CONFIG;
        }
    }
}
