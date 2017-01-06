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
            root = new XElement("root");
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
                    string model = values[i][index++];
                    string dataPrefab = values[i][index++];
                    string blush = values[i][index++];
                    int blushType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out blushType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，blushType为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int totalTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out totalTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maxTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    if (totalTime == 0 && maxTime == 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，当总帧数不限制时，最大帧数不能为0", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int collisionLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out collisionLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，碰撞条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int collisionFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out collisionFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，碰撞功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
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
                    int targetId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int followInterval;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out followInterval))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，追踪检查间隔时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int posCoordType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out posCoordType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，参考坐标系必须为整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int speedCoordType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out speedCoordType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，speedCoordType必须为整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int floatTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out floatTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，直线飞行时间必须为整型", this.GetConfigName(), sheetName, row, index);
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
                    int posZ;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out posZ, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，初始位置Z必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
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
                    int initSpeedZ;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out initSpeedZ, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，初始速度Z必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
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
                    int addSpeedZ;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out addSpeedZ, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，加速度Z必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    string dieEffect = values[i][index++];

                    int bornRotate;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out bornRotate, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，bornRotate必须为{4} - {5}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }

                    XElement effectE = new XElement("effect");
                    root.Add(effectE);
                    effectE.Add(new XAttribute("id", id));
                    effectE.Add(new XAttribute("totalTime", totalTime));
                    effectE.Add(new XAttribute("maxTime", maxTime));
                    effectE.Add(new XAttribute("collisionLimitId", collisionLimitId));
                    effectE.Add(new XAttribute("collisionFuncId", collisionFuncId));
                    effectE.Add(new XAttribute("enterLimitId", enterLimitId));
                    effectE.Add(new XAttribute("enterFuncId", enterFuncId));
                    effectE.Add(new XAttribute("stayLimitId", stayLimitId));
                    effectE.Add(new XAttribute("stayFuncId", stayFuncId));


                    BattleEffectConfig c = new BattleEffectConfig();
                    c.Id = id;
                    c.Model = model;
                    c.DataPrefab = dataPrefab;
                    c.Blush = blush;
                    c.BlushType = blushType;
                    c.TotalTime = totalTime / SysConstant.CLIENT_FRAME_TIME;
                    c.MaxTime= maxTime / SysConstant.CLIENT_FRAME_TIME;
                    c.CollisionLimitId = collisionLimitId;
                    c.CollisionFuncId = collisionFuncId;
                    c.EnterLimitId = enterLimitId;
                    c.EnterFuncId = enterFuncId;
                    c.StayLimitId = stayLimitId;
                    c.StayFuncId = stayFuncId;
                    c.ExitLimitId = exitLimitId;
                    c.ExitFuncId = exitFuncId;
                    c.DeadLimitId = deadLimitId;
                    c.DeadFunId = deadFunId;
                    c.Type = type;
                    c.TargetId = targetId;
                    c.FollowInterval = followInterval;
                    c.PosCoordType = posCoordType;
                    c.SpeedCoordType = speedCoordType;
                    c.FloatTime = floatTime / SysConstant.CLIENT_FRAME_TIME;
                    c.PosX = posX;
                    c.PosY = posY;
                    c.PoxZ = posZ;
                    c.InitSpeedX = initSpeedX;
                    c.InitSpeedY = initSpeedY;
                    c.InitSpeedZ = initSpeedZ;
                    c.AddSpeedX = addSpeedX;
                    c.AddSpeedY = addSpeedY;
                    c.AddSpeedZ = addSpeedZ;
                    c.DieEffect = dieEffect;
                    c.BornRotate = bornRotate;
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
