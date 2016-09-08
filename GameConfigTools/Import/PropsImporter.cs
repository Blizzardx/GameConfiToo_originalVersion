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
    public class PropsImporter : AbstractExcelImporter
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

            PropsConfigTable config = new PropsConfigTable();
            tbase = config;
            config.PropsConfigMap = new Dictionary<int, Config.PropsConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，名称ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    //desc
                    index++;
                    int funcDescMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out funcDescMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，功能描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string icon = values[i][index++];
                    int firstType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out firstType, 1, 10))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，一级分类必须为1 - 10整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int secondType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out secondType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，二级分类必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int quality;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quality, 1, 7))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，品质必须为1 - 7整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int canUse;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canUse, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，能否使用必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int useLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out useLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，使用条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int useFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out useFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，使用功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int canSell;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canSell, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，能否出售必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int sellCurrencyType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sellCurrencyType, 0, 3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出售的货币类型必须为0 - 3整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    if(canSell != 0 && sellCurrencyType == 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，物品配置可以出售时，出售的货币类型不能为0", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int sellPrice;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sellPrice))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出售价格必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int canGive;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canGive, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，能否赠送必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int canAuction;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canAuction, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，能否拍卖必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    XElement monsterE = new XElement("props");
                    root.Add(monsterE);
                    monsterE.Add(new XAttribute("id", id));
                    monsterE.Add(new XAttribute("name", name));
                    monsterE.Add(new XAttribute("firstType", firstType));
                    monsterE.Add(new XAttribute("secondType", secondType));
                    monsterE.Add(new XAttribute("quality", quality));
                    monsterE.Add(new XAttribute("canUse", canUse != 0));
                    monsterE.Add(new XAttribute("useLimitId", useLimitId));
                    monsterE.Add(new XAttribute("useFuncId", useFuncId));
                    monsterE.Add(new XAttribute("canSell", canSell != 0));
                    monsterE.Add(new XAttribute("sellCurrencyType", sellCurrencyType));
                    monsterE.Add(new XAttribute("sellPrice", sellPrice));
                    monsterE.Add(new XAttribute("canGive", canGive != 0));
                    monsterE.Add(new XAttribute("canAuction", canAuction != 0));

                    PropsConfig c = new PropsConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.FuncDescMessageId = funcDescMessageId;
                    c.DescMessageId = descMessageId;
                    c.Icon = icon;
                    c.FirstType = firstType;
                    c.SecondType = secondType;
                    c.Quality = quality;
                    c.CanUse = canUse != 0;
                    c.UseLimitId = useLimitId;
                    c.UseFuncId = useFuncId;
                    c.CanSell = canSell != 0;
                    c.SellCurrencyType = sellCurrencyType;
                    c.SellPrice = sellPrice;
                    c.CanGive = canGive != 0;
                    c.CanAuction = canAuction != 0;
                    config.PropsConfigMap.Add(c.Id, c);
                }
            }

        }

        protected override string GetConfigName()
        {
            return SysConstant.PROPS_CONFIG;
        }
    }
}
