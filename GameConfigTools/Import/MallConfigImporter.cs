using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class MallConfigImporter : AbstractExcelImporter
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

                    int id;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];
                    
                    int itemId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out itemId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int order;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out order))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，排序值必须为0 - {4}整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    
                    int discount;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out discount, 1, 10))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，折扣必须为1 - 10整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    
                    
                    int topType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out topType, 0, 2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，置顶标签必须为0 - 2整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    XElement mallE = new XElement("item");
                    root.Add(mallE);
                    mallE.Add(new XAttribute("id", id));
                    mallE.Add(new XAttribute("itemId", itemId));
                    mallE.Add(new XAttribute("order", order));
                    mallE.Add(new XAttribute("discount", discount));
                    mallE.Add(new XAttribute("topType", topType));

                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.MALL_CONFIG;
        }
    }
}
