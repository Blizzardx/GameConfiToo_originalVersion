using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class BattleBuffImporter : AbstractExcelImporter
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

            BattleBuffConfigTable config = new BattleBuffConfigTable();
            tbase = config;
            config.BuffConfigMap = new Dictionary<int, BattleBuffConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string name = values[i][index++];
                    string desc = values[i][index++];

                    int type;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out type, 0 , sbyte.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, sbyte.MaxValue);
                        return;
                    }
                    string icon = values[i][index++];
                    string effectResource = values[i][index++];
                    string bindPoint = values[i][index++];

                    int tickTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickTime, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 跳动时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int continueTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out continueTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 持续时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    if (continueTime > 0)
                    {
                        if (continueTime * 1000 <= tickTime)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff持续时间不能小于buff跳动时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                    }
                    else
                    {
                        if(tickTime > 0)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff持续时间等于0时，buff跳动时间必须也为0", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                    }
                    int addTargetId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out addTargetId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 初始目标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int addLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out addLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 初始条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int addFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out addFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 初始功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int tickTargetId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickTargetId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 跳动目标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int tickLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 跳动条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int tickFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 跳动功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int delTargetId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out delTargetId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 消失目标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int delLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out delLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 消失条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int delFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out delFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff 消失功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int buffDurability;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out buffDurability))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buffDurability  必须为整型", this.GetConfigName(), sheetName, row, index, 10000);
                        return;
                    }

                    XElement buffE = new XElement("buff");
                    root.Add(buffE);

                    buffE.Add(new XAttribute("id", id));
                    buffE.Add(new XAttribute("name", name));
                    buffE.Add(new XAttribute("type", type));
                    buffE.Add(new XAttribute("tickTime", tickTime));
                    buffE.Add(new XAttribute("continueTime", continueTime));
                    buffE.Add(new XAttribute("addTargetId", addTargetId));
                    buffE.Add(new XAttribute("addLimitId", addLimitId));
                    buffE.Add(new XAttribute("addFuncId", addFuncId));
                    buffE.Add(new XAttribute("tickTargetId", tickTargetId));
                    buffE.Add(new XAttribute("tickLimitId", tickLimitId));
                    buffE.Add(new XAttribute("tickFuncId", tickFuncId));
                    buffE.Add(new XAttribute("delTargetId", delTargetId));
                    buffE.Add(new XAttribute("delLimitId", delLimitId));
                    buffE.Add(new XAttribute("delFuncId", delFuncId));
                    buffE.Add(new XAttribute("buffDurability", buffDurability));

                    BattleBuffConfig c = new BattleBuffConfig();
                    c.Id = id;
                    c.Type = type;
                    c.Icon = icon;
                    c.EffectResource = effectResource;
                    c.BindPoint = bindPoint;
                    c.TickTime = tickTime;
                    c.ContinueTime = continueTime;
                    c.AddTargetId = addTargetId;
                    c.AddLimitId = addLimitId;
                    c.AddFuncId = addFuncId;
                    c.TickTargetId = tickTargetId;
                    c.TickLimitId = tickLimitId;
                    c.TickFuncId = tickFuncId;
                    c.DelTargetId = delTargetId;
                    c.DelLimitId = delLimitId;
                    c.DelFuncId = delFuncId;
                    c.BuffDurability = buffDurability;
                    config.BuffConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_BUFF_CONFIG;
        }
    }
}
