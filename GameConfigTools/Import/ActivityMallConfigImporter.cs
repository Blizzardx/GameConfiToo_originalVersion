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
    class ActivityMallConfigImporter : AbstractExcelImporter
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

                    DateTime? discountStart;
                    if (!VaildUtil.VaildDateTime(values[i][index++], true, out discountStart))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，折扣开始时间格式不正确", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    DateTime? discountEnd;
                    if (!VaildUtil.VaildDateTime(values[i][index++], true, out discountEnd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，折扣结束时间格式不正确", this.GetConfigName(), sheetName, row, index, 1, 3);
                        return;
                    }

                    int discountCount;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out discountCount, -1, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，折扣出售数量必须为-1 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int buyLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out buyLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，购买条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int buyLimitMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out buyLimitMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，购买条件说明ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int count;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out count, -1, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出售数量必须为-1 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int topType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out topType, 0, 2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，置顶标签必须为0 - 2整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    DateTime? topStart;
                    if (!VaildUtil.VaildDateTime(values[i][index++], true, out topStart))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，置顶标签开始时间格式不正确", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    DateTime? topEnd;
                    if (!VaildUtil.VaildDateTime(values[i][index++], true, out topEnd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，置顶标签结束时间格式不正确", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int version;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out version))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具版本必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    XElement mallE = new XElement("item");
                    root.Add(mallE);
                    mallE.Add(new XAttribute("id", id));
                    mallE.Add(new XAttribute("itemId", itemId));
                    mallE.Add(new XAttribute("order", order));
                    mallE.Add(new XAttribute("discount", discount));
                    mallE.Add(new XAttribute("discountStart", discountStart.ToFormatString()));
                    mallE.Add(new XAttribute("discountEnd", discountEnd.ToFormatString()));
                    mallE.Add(new XAttribute("discountCount", discountCount));
                    mallE.Add(new XAttribute("buyLimitId", buyLimitId));
                    mallE.Add(new XAttribute("buyLimitMessageId", buyLimitMessageId));
                    mallE.Add(new XAttribute("count", count));
                    mallE.Add(new XAttribute("topType", topType));
                    mallE.Add(new XAttribute("topStart", topStart.ToFormatString()));
                    mallE.Add(new XAttribute("topEnd", topEnd.ToFormatString()));
                    mallE.Add(new XAttribute("version", version));
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.ACTIVITY_MALL_CONFIG;
        }
    }
}
