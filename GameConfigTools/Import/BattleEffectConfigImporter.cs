using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class BattleEffectConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            BattleEffectConfigTable config = new BattleEffectConfigTable();
            tbase = config;
            config.BattleEffectConfigMap = new Dictionary<int, BattleEffectConfig>();

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
                    if (config.BattleEffectConfigMap.ContainsKey(id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID重复", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    index++;
                    string res = values[i][index++];
                    string dataPrefab = values[i][index++];
                    int totalFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out totalFrame))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maxFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxFrame))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    if (totalFrame == 0 && maxFrame == 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，当总帧数不限制时，最大帧数不能为0", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int enterLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out enterLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，进入条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int enterFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out enterFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，进入功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int stayLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out stayLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，停留条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int stayFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out stayFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，停留功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int exitLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out exitLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，离开条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int exitFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out exitFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，离开功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int deadLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out deadLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，销毁时条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int deadFunId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out deadFunId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，销毁时功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int type;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out type))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，特效类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int followInterval;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out followInterval))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，追踪检查间隔时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int isWorld;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isWorld))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，位置是否基于世界坐标系必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int posX;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out posX, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，初始位置X必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    //if(posX > 0 && posX < 10000)
                    //{
                    //    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，浮点型最小单位为10000", this.GetConfigName(), sheetName, row, index);
                    //    return;
                    //}
                    int posY;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out posY, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，初始位置Y必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    //if (posY > 0 && posY < 10000)
                    //{
                    //    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，浮点型最小单位为10000", this.GetConfigName(), sheetName, row, index);
                    //    return;
                    //}
                    int initSpeedX;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out initSpeedX, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，初始速度X必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    //if (initSpeedX > 0 && initSpeedX < 10000)
                    //{
                    //    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，浮点型最小单位为10000", this.GetConfigName(), sheetName, row, index);
                    //    return;
                    //}
                    int initSpeedY;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out initSpeedY, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，初始速度Y必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    //if (initSpeedY > 0 && initSpeedY < 10000)
                    //{
                    //    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，浮点型最小单位为10000", this.GetConfigName(), sheetName, row, index);
                    //    return;
                    //}
                    int addSpeedX;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out addSpeedX, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，加速度X必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    //if (addSpeedX > 0 && addSpeedX < 10000)
                    //{
                    //    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，浮点型最小单位为10000", this.GetConfigName(), sheetName, row, index);
                    //    return;
                    //}
                    int addSpeedY;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out addSpeedY, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，加速度Y必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    string dieEffect = values[i][index++];

                    ////if (addSpeedY > 0 && addSpeedY < 10000)
                    ////{
                    ////    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，浮点型最小单位为10000", this.GetConfigName(), sheetName, row, index);
                    ////    return;
                    ////}
                    BattleEffectConfig c = new BattleEffectConfig();
                    c.Id = id;
                    c.Res = res;
                    c.TotalFrame = totalFrame;
                    c.MaxFrame = maxFrame;
                    c.TargetId = targetId;
                    c.EnterLimitId = enterLimitId;
                    c.EnterFuncId = enterFuncId;
                    c.StayLimitId = stayLimitId;
                    c.StayFuncId = stayFuncId;
                    c.ExitLimitId = exitLimitId;
                    c.ExitFuncId = exitFuncId;
                    c.DeadLimitId = deadLimitId;
                    c.DeadFunId = deadFunId;
                    c.Type = type;
                    c.FollowInterval = followInterval;
                    c.IsWorld = isWorld != 0;
                    c.PosX = posX;
                    c.PosY = posY;
                    c.InitSpeedX = initSpeedX;
                    c.InitSpeedY = initSpeedY;
                    c.AddSpeedX = addSpeedX;
                    c.AddSpeedY = addSpeedY;
                    c.DataPrefab = dataPrefab;
                    c.DieEffect = dieEffect;
                    config.BattleEffectConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_EFFECT_CONFIG;
        }
    }
}
