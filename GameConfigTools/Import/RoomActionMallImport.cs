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
    public class RoomActionMallImport : AbstractExcelImporter
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

            RoomActionMallConfigTable config = new RoomActionMallConfigTable();
            tbase = config;
            config.RoomActionMallConfigMap = new Dictionary<int, RoomActionMallConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，动作卡ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，动作名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
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
                    int actionType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out actionType, 1, 2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，动作类型必须为1 - 2整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    XElement mallE = new XElement("mall");
                    root.Add(mallE);
                    mallE.Add(new XAttribute("itemId", itemId));
                    mallE.Add(new XAttribute("currencyType", currencyType));
                    mallE.Add(new XAttribute("price", price));
                    mallE.Add(new XAttribute("actionType", actionType));

                    RoomActionMallConfig c = new RoomActionMallConfig();
                    c.ItemId = itemId;
                    c.NameMessageId = nameMessageId;
                    c.CurrencyType = currencyType;
                    c.Price = price;
                    c.ActionType = actionType;
                    config.RoomActionMallConfigMap.Add(c.ItemId, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.ROOM_ACTION_MALL_CONFIG;
        }
    }
}
