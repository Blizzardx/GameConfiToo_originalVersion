using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using System.Xml.Linq;
using Thrift.Protocol;
using GameConfigTools.Util;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class SystemImporter : AbstractXmlImporter
    {
        protected override bool Valid(XElement root, out TBase tbase, ref string errMsg)
        {
            SystemConfigTable systemConfig = new SystemConfigTable();
            tbase = systemConfig;
            systemConfig.RoomConfig = new SystemRoomConfig();
            systemConfig.DecorateTypeSrotConfig = new SystemDecorateTypeSortConfig();
            systemConfig.ChatConfig = new SystemChatConfig();
            if (!ValidRoomConfig(root, systemConfig.RoomConfig, ref errMsg))
            {
                return false;
            }
            if (!ValidDecorateTypeSortConfig(root, systemConfig.DecorateTypeSrotConfig, ref errMsg))
            {
                return false;
            }
            if(!ValidChatConfig(root, systemConfig.ChatConfig, ref errMsg))
            {
                return false;
            }
            return true;
        }

        private bool ValidRoomConfig(XElement e, SystemRoomConfig config, ref string errMsg)
        {
            e = e.Element("room");
            var funcId = e.Element("likeOnResultFuncId");
            if (funcId == null)
            {
                errMsg = "<characterConfig> - <heads>节点不能为空";
                return false;
            }
            int id = 0;
            int.TryParse(funcId.Value, out id);
            config.LikeOnResultFuncId = id;
            return true;
        }
        private bool ValidDecorateTypeSortConfig(XElement e, SystemDecorateTypeSortConfig config, ref string errMsg)
        {
            e = e.Element("decorateTypeSort");
            config.SortInfoList = new List<SystemDecorateTypeSortInfo>();
            var list = e.Elements("sortInfo");
            foreach (var elem in list)
            {
                SystemDecorateTypeSortInfo info = new SystemDecorateTypeSortInfo();
                info.NodeName = elem.Attribute("nodeName").Value;
                if (string.IsNullOrEmpty(info.NodeName))
                {
                    errMsg = "<nodeName> 节点不能为空";
                    return false;
                }
                int sortId = 0;
                if (!int.TryParse(elem.Attribute("sortId").Value, out sortId))
                {
                    errMsg = "<sortId> 必须为整数";
                    return false;
                }
                info.SortId = sortId;
                config.SortInfoList.Add(info);
            }
            return true;
        }
        private bool ValidChatConfig(XElement root, SystemChatConfig config, ref string errMsg)
        {
            XElement chatE = root.Element("chat");
            int chatSpeakerStayTime;
            if (!int.TryParse(chatE.Element("chatSpeakerStayTime").Value, out chatSpeakerStayTime))
            {
                errMsg = "<chatSpeakerStayTime> 必须为整数";
                return false;
            }
            config.ChatChannelConfigMap = new Dictionary<int, ChatChannelConfig>();
            var channelsE = chatE.Element("channels").Elements("channel");
            foreach(var channel in channelsE)
            {
                int id;
                if (!int.TryParse(channel.Attribute("id").Value, out id))
                {
                    errMsg = "<channel> id属性必须为整数";
                    return false;
                }
                int costItemId;
                if (!int.TryParse(channel.Attribute("costItemId").Value, out costItemId))
                {
                    errMsg = "<channel> costItemId属性必须为整数";
                    return false;
                }
                int cdTime;
                if (!int.TryParse(channel.Attribute("cdTime").Value, out cdTime))
                {
                    errMsg = "<channel> cdTime属性必须为整数";
                    return false;
                }
                int cdCount;
                if (!int.TryParse(channel.Attribute("cdCount").Value, out cdCount))
                {
                    errMsg = "<channel> cdCount属性必须为整数";
                    return false;
                }
                ChatChannelConfig c = new ChatChannelConfig();
                c.Id = id;
                c.CostItemId = costItemId;
                c.CdTime = cdTime;
                c.CdCount = cdCount;

                config.ChatChannelConfigMap.Add(id, c);
            }
            return true;
        }
        //private bool VaildCharacterConfig(XElement e, CharacterConfig config, ref string errMsg)
        //{
        //    XElement headsE = e.Element("heads");
        //    if (headsE == null)
        //    {
        //        errMsg = "<characterConfig> - <heads>节点不能为空";
        //        return false;
        //    }
        //    var headList = headsE.Elements("head");
        //    foreach (var v in headList)
        //    {
        //        if (v.Attribute("id") == null)
        //        {
        //            errMsg = "<characterConfig> - <heads> - <head>节点,id属性不能为空";
        //            return false;
        //        }
        //        if (v.Attribute("resource") == null)
        //        {
        //            errMsg = "<characterConfig> - <heads> - <head>节点,resource属性不能为空";
        //            return false;
        //        }
        //        int id;
        //        if (!VaildUtil.TryConvertInt(v.Attribute("id").Value, out id))
        //        {
        //            errMsg = "<characterConfig> - <heads> - <head>节点,id属性必须为整型";
        //            return false;
        //        }
        //        string resource = v.Attribute("resource").Value;

            //        HeadConfig c = new HeadConfig();
            //        c.Id = id;
            //        c.Resource = resource;
            //        config.HeadsConfig.HeadConfigList.Add(c);
            //    }

            //    XElement maxLevelE = e.Element("maxLevel");
            //    if (maxLevelE == null)
            //    {
            //        errMsg = "<characterConfig> - <maxLevel>节点不能为空";
            //        return false;
            //    }
            //    int maxLevel;
            //    if (!VaildUtil.TryConvertInt(maxLevelE.Value, out maxLevel, 0, short.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <maxLevel>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }
            //    XElement recoverMaxPowerE = e.Element("recoverMaxPower");
            //    if (recoverMaxPowerE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverMaxPower>节点不能为空";
            //        return false;
            //    }
            //    int recoverMaxPower;
            //    if (!VaildUtil.TryConvertInt(recoverMaxPowerE.Value, out recoverMaxPower, 0, short.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverMaxPower>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }

            //    XElement recoverPowerMinuteE = e.Element("recoverPowerMinute");
            //    if (recoverPowerMinuteE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverPowerMinute>节点不能为空";
            //        return false;
            //    }
            //    int recoverPowerMinute;
            //    if (!VaildUtil.TryConvertInt(recoverPowerMinuteE.Value, out recoverPowerMinute, 0, sbyte.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverPowerMinute>节点值必须为0 - {0}的整数", sbyte.MaxValue);
            //        return false;
            //    }

            //    XElement recoverPowerNumE = e.Element("recoverPowerNum");
            //    if (recoverPowerNumE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverPowerNum>节点不能为空";
            //        return false;
            //    }
            //    int recoverPowerNum;
            //    if (!VaildUtil.TryConvertInt(recoverPowerNumE.Value, out recoverPowerNum, 0, sbyte.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverPowerNum>节点值必须为0 - {0}的整数", sbyte.MaxValue);
            //        return false;
            //    }

            //    XElement recoverMaxEnergyE = e.Element("recoverMaxEnergy");
            //    if (recoverMaxEnergyE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverMaxEnergy>节点不能为空";
            //        return false;
            //    }
            //    int recoverMaxEnergy;
            //    if (!VaildUtil.TryConvertInt(recoverMaxEnergyE.Value, out recoverMaxEnergy, 0, short.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverMaxEnergy>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }

            //    XElement recoverEnergyMinuteE = e.Element("recoverEnergyMinute");
            //    if (recoverEnergyMinuteE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverEnergyMinute>节点不能为空";
            //        return false;
            //    }
            //    int recoverEnergyMinute;
            //    if (!VaildUtil.TryConvertInt(recoverEnergyMinuteE.Value, out recoverEnergyMinute, 0, sbyte.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverEnergyMinute>节点值必须为0 - {0}的整数", sbyte.MaxValue);
            //        return false;
            //    }

            //    XElement recoverEnergyNumE = e.Element("recoverEnergyNum");
            //    if (recoverEnergyNumE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverEnergyNum>节点不能为空";
            //        return false;
            //    }
            //    int recoverEnergyNum;
            //    if (!VaildUtil.TryConvertInt(recoverEnergyNumE.Value, out recoverEnergyNum, 0, sbyte.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverEnergyNum>节点值必须为0 - {0}的整数", sbyte.MaxValue);
            //        return false;
            //    }

            //    XElement maxVipLevelE = e.Element("maxVipLevel");
            //    if (maxVipLevelE == null)
            //    {
            //        errMsg = "<characterConfig> - <maxVipLevel>节点不能为空";
            //        return false;
            //    }
            //    int maxVipLevel;
            //    if (!VaildUtil.TryConvertInt(maxVipLevelE.Value, out maxVipLevel, 0, sbyte.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <maxVipLevel>节点值必须为0 - {0}的整数", sbyte.MaxValue);
            //        return false;
            //    }

            //    config.MaxLevel = (short)maxLevel;
            //    config.RecoverMaxPower = (short)recoverMaxPower;
            //    config.RecoverPowerMinute = (sbyte)recoverPowerMinute;
            //    config.RecoverPowerNum = (sbyte)recoverPowerNum;
            //    config.RecoverMaxEnergy = (short)recoverMaxEnergy;
            //    config.RecoverEnergyMinute = (sbyte)recoverEnergyMinute;
            //    config.RecoverEnergyNum = (sbyte)recoverEnergyNum;
            //    config.MaxVipLevel = (sbyte)maxVipLevel;

            //    XElement carryHerosE = e.Element("carryHeros");
            //    if (carryHerosE == null)
            //    {
            //        errMsg = "<characterConfig> - <carryHeros>节点不能为空";
            //        return false;
            //    }

            //    var carryHeroList = carryHerosE.Elements("carryHero");
            //    foreach (var c in carryHeroList)
            //    {
            //        if (c.Attribute("level") == null)
            //        {
            //            errMsg = "<characterConfig> - <carryHeros> - <carryHero>节点, level属性不能为空";
            //            return false;
            //        }
            //        if (c.Attribute("num") == null)
            //        {
            //            errMsg = "<characterConfig> - <carryHeros> - <carryHero>节点, num属性不能为空";
            //            return false;
            //        }

            //        int level;
            //        if (!VaildUtil.TryConvertInt(c.Attribute("level").Value, out level, 0, sbyte.MaxValue))
            //        {
            //            errMsg = string.Format("<characterConfig> - <carryHeros> - <carryHero>节点, level属性值必须为0 - {0}的整数", sbyte.MaxValue);
            //            return false;
            //        }

            //        int num;
            //        if (!VaildUtil.TryConvertInt(c.Attribute("level").Value, out num, 0, sbyte.MaxValue))
            //        {
            //            errMsg = string.Format("<characterConfig> - <carryHeros> - <carryHero>节点, num属性值必须为0 - {0}的整数", sbyte.MaxValue);
            //            return false;
            //        }

            //        CarryHeroConfig hc = new CarryHeroConfig();
            //        hc.Level = (sbyte)level;
            //        hc.Num = (sbyte)num;
            //        config.CarryHerosConfig.CarryHeroConfigList.Add(hc);

            //    }

            //    XElement maxSkillPointE = e.Element("maxSkillPoint");
            //    if (maxSkillPointE == null)
            //    {
            //        errMsg = "<characterConfig> - <maxSkillPoint>节点不能为空";
            //        return false;
            //    }
            //    int maxSkillPoint;
            //    if (!VaildUtil.TryConvertInt(maxSkillPointE.Value, out maxSkillPoint, 0, short.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <maxSkillPoint>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }

            //    XElement recoverSkillPointMinuteE = e.Element("recoverSkillPointMinute");
            //    if (recoverSkillPointMinuteE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverSkillPointMinute>节点不能为空";
            //        return false;
            //    }
            //    int recoverSkillPointMinute;
            //    if (!VaildUtil.TryConvertInt(recoverSkillPointMinuteE.Value, out recoverSkillPointMinute, 0, byte.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverSkillPointMinute>节点值必须为0 - {0}的整数", byte.MaxValue);
            //        return false;
            //    }

            //    XElement recoverSkillPointNumE = e.Element("recoverSkillPointNum");
            //    if (recoverSkillPointNumE == null)
            //    {
            //        errMsg = "<characterConfig> - <recoverSkillPointNum>节点不能为空";
            //        return false;
            //    }
            //    int recoverSkillPointNum;
            //    if (!VaildUtil.TryConvertInt(recoverSkillPointNumE.Value, out recoverSkillPointNum, 0, byte.MaxValue))
            //    {
            //        errMsg = string.Format("<characterConfig> - <recoverSkillPointNum>节点值必须为0 - {0}的整数", byte.MaxValue);
            //        return false;
            //    }

            //    config.MaxSkillPoint = (short)maxSkillPoint;
            //    config.RecoverSkillPointMinute = (sbyte)recoverSkillPointMinute;
            //    config.RecoverSkillPointNum = (sbyte)recoverSkillPointNum;

            //    return true;
            //}

            //private bool VaildBattleConfig(XElement e, SystemBattleConfig config, ref string errMsg)
            //{
            //    XElement mainBattleTimeoutE = e.Element("mainBattleTimeout");

            //    if (mainBattleTimeoutE == null)
            //    {
            //        errMsg = string.Format("<battle> - <mainBattleTimeout>节点不能为空");
            //        return false;
            //    }
            //    int mainBattleTimeout;
            //    if (!VaildUtil.TryConvertInt(mainBattleTimeoutE.Value, out mainBattleTimeout, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <mainBattleTimeout>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement initRageE = e.Element("initRage");

            //    if (initRageE == null)
            //    {
            //        errMsg = string.Format("<battle> - <initRage>节点不能为空");
            //        return false;
            //    }
            //    int initRage;
            //    if (!VaildUtil.TryConvertInt(initRageE.Value, out initRage, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <initRage>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement rageMaxE = e.Element("rageMax");

            //    if (rageMaxE == null)
            //    {
            //        errMsg = string.Format("<battle> - <rageMax>节点不能为空");
            //        return false;
            //    }
            //    int rageMax;
            //    if (!VaildUtil.TryConvertInt(rageMaxE.Value, out rageMax, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <rageMax>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement recoverRageSecondE = e.Element("recoverRageSecond");
            //    if (recoverRageSecondE == null)
            //    {
            //        errMsg = string.Format("<battle> - <recoverRageSecond>节点不能为空");
            //        return false;
            //    }
            //    int recoverRageSecond;
            //    if (!VaildUtil.TryConvertInt(recoverRageSecondE.Value, out recoverRageSecond, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <recoverRageSecond>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement recoverRageNumE = e.Element("recoverRageNum");
            //    if (recoverRageNumE == null)
            //    {
            //        errMsg = string.Format("<battle> - <recoverRageNum>节点不能为空");
            //        return false;
            //    }
            //    int recoverRageNum;
            //    if (!VaildUtil.TryConvertInt(recoverRageNumE.Value, out recoverRageNum, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <recoverRageNum>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement recoverRageKillE = e.Element("recoverRageKill");
            //    if (recoverRageKillE == null)
            //    {
            //        errMsg = string.Format("<battle> - <recoverRageKill>节点不能为空");
            //        return false;
            //    }
            //    int recoverRageKill;
            //    if (!VaildUtil.TryConvertInt(recoverRageKillE.Value, out recoverRageKill, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <recoverRageKill>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement quickWinFreeCycleIdE = e.Element("quickWinFreeCycleId");
            //    if (quickWinFreeCycleIdE == null)
            //    {
            //        errMsg = string.Format("<battle> - <quickWinFreeCycleId>节点不能为空");
            //        return false;
            //    }
            //    int quickWinFreeCycleId;
            //    if (!VaildUtil.TryConvertInt(quickWinFreeCycleIdE.Value, out quickWinFreeCycleId, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <quickWinFreeCycleId>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement quickWinFreeCycleCounterIdE = e.Element("quickWinFreeCycleCounterId");
            //    if (quickWinFreeCycleCounterIdE == null)
            //    {
            //        errMsg = string.Format("<battle> - <quickWinFreeCycleCounterId>节点不能为空");
            //        return false;
            //    }
            //    int quickWinFreeCycleCounterId;
            //    if (!VaildUtil.TryConvertInt(quickWinFreeCycleCounterIdE.Value, out quickWinFreeCycleCounterId, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <quickWinFreeCycleCounterId>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }

            //    XElement initQuickWinFreeCountE = e.Element("initQuickWinFreeCount");
            //    if (initQuickWinFreeCountE == null)
            //    {
            //        errMsg = string.Format("<battle> - <initQuickWinFreeCount>节点不能为空");
            //        return false;
            //    }
            //    int initQuickWinFreeCount;
            //    if (!VaildUtil.TryConvertInt(initQuickWinFreeCountE.Value, out initQuickWinFreeCount, 0, int.MaxValue))
            //    {
            //        errMsg = string.Format("<battle> - <initQuickWinFreeCount>节点值必须为0 - {0}的整数", int.MaxValue);
            //        return false;
            //    }
            //    config.MainBattleTimeout = mainBattleTimeout;
            //    config.InitRage = initRage;
            //    config.RageMax = rageMax;
            //    config.RecoverRageSecond = recoverRageSecond;
            //    config.RecoverRageNum = recoverRageNum;
            //    config.RecoverRageKill = recoverRageKill;
            //    config.QuickWinFreeCycleId = quickWinFreeCycleId;
            //    config.QuickWinFreeCycleCounterId = quickWinFreeCycleCounterId;
            //    config.InitQuickWinFreeCount = initQuickWinFreeCount;

            //    return true;
            //}
            //private bool VaildHeroConfig(XElement e, SystemHeroConfig config, ref string errMsg)
            //{
            //    config.ExpPropsIdList = new List<int>();
            //    XElement expPropsIdsE = e.Element("expPropsIds");
            //    if (expPropsIdsE == null)
            //    {
            //        errMsg = string.Format("<hero> - <expPropsIds>节点不能为空");
            //        return false;
            //    }

            //    var expPropsIds = expPropsIdsE.Elements("expPropsId");
            //    if (expPropsIds == null || expPropsIds.Count() != 5)
            //    {
            //        errMsg = string.Format("<hero> - <expPropsIds> - <expPropsId>必须配置5条");
            //        return false;
            //    }
            //    foreach (var v in expPropsIds)
            //    {
            //        int expPropsId;
            //        if (!VaildUtil.TryConvertInt(v.Value, out expPropsId, 0, int.MaxValue))
            //        {
            //            errMsg = string.Format("<hero> - <expPropsIds> - <expPropsId>节点值必须为0 - {0}的整数", int.MaxValue);
            //            return false;
            //        }
            //        config.ExpPropsIdList.Add(expPropsId);
            //    }
            //    int maxLevelByWhiteQuality;
            //    if (!VaildUtil.TryConvertInt(e.Element("maxLevelByWhiteQuality").Value, out maxLevelByWhiteQuality))
            //    {
            //        errMsg = string.Format("<hero> - <maxLevelByWhiteQuality>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }
            //    int maxLevelByGreenQuality;
            //    if (!VaildUtil.TryConvertInt(e.Element("maxLevelByGreenQuality").Value, out maxLevelByGreenQuality))
            //    {
            //        errMsg = string.Format("<hero> - <maxLevelByGreenQuality>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }
            //    int maxLevelByBlueQuality;
            //    if (!VaildUtil.TryConvertInt(e.Element("maxLevelByBlueQuality").Value, out maxLevelByBlueQuality))
            //    {
            //        errMsg = string.Format("<hero> - <maxLevelByBlueQuality>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }
            //    int maxLevelByPurpleQuality;
            //    if (!VaildUtil.TryConvertInt(e.Element("maxLevelByPurpleQuality").Value, out maxLevelByPurpleQuality))
            //    {
            //        errMsg = string.Format("<hero> - <maxLevelByPurpleQuality>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }
            //    int maxLevelByGlodenQuality;
            //    if (!VaildUtil.TryConvertInt(e.Element("maxLevelByGlodenQuality").Value, out maxLevelByGlodenQuality))
            //    {
            //        errMsg = string.Format("<hero> - <maxLevelByGlodenQuality>节点值必须为0 - {0}的整数", short.MaxValue);
            //        return false;
            //    }
            //    config.MaxLevelByWhiteQuality = (short)maxLevelByWhiteQuality;
            //    config.MaxLevelByGreenQuality = (short)maxLevelByGreenQuality;
            //    config.MaxLevelByBlueQuality = (short)maxLevelByBlueQuality;
            //    config.MaxLevelByPurpleQuality = (short)maxLevelByPurpleQuality;
            //    config.MaxLevelByGlodenQuality = (short)maxLevelByGlodenQuality;

            //    return true;
            //}

            //private bool VaildFightConfig(XElement e, SystemFightConfig config, ref string errMsg)
            //{
            //    float initAvo;
            //    if (!VaildUtil.TryConvertFloat(e.Element("initAvo").Value, out initAvo))
            //    {
            //        errMsg = string.Format("<fight> - <initAvo>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float avoFactorA;
            //    if (!VaildUtil.TryConvertFloat(e.Element("avoFactorA").Value, out avoFactorA))
            //    {
            //        errMsg = string.Format("<fight> - <avoFactorA>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }

            //    float avoFactorB;
            //    if (!VaildUtil.TryConvertFloat(e.Element("avoFactorB").Value, out avoFactorB))
            //    {
            //        errMsg = string.Format("<fight> - <avoFactorB>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }

            //    float avoMin;
            //    if (!VaildUtil.TryConvertFloat(e.Element("avoMin").Value, out avoMin))
            //    {
            //        errMsg = string.Format("<fight> - <avoMin>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }

            //    float avoMax;
            //    if (!VaildUtil.TryConvertFloat(e.Element("avoMax").Value, out avoMax))
            //    {
            //        errMsg = string.Format("<fight> - <avoMax>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float initCrit;
            //    if (!VaildUtil.TryConvertFloat(e.Element("initCrit").Value, out initCrit))
            //    {
            //        errMsg = string.Format("<fight> - <initCrit>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critFactorA;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critFactorA").Value, out critFactorA))
            //    {
            //        errMsg = string.Format("<fight> - <critFactorA>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critFactorB;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critFactorB").Value, out critFactorB))
            //    {
            //        errMsg = string.Format("<fight> - <critFactorB>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critMin;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critMin").Value, out critMin))
            //    {
            //        errMsg = string.Format("<fight> - <critMin>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critMax;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critMax").Value, out critMax))
            //    {
            //        errMsg = string.Format("<fight> - <critMax>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float initCritDamage;
            //    if (!VaildUtil.TryConvertFloat(e.Element("initCritDamage").Value, out initCritDamage))
            //    {
            //        errMsg = string.Format("<fight> - <initCritDamage>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critDamageFactorA;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critDamageFactorA").Value, out critDamageFactorA))
            //    {
            //        errMsg = string.Format("<fight> - <critDamageFactorA>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critDamageFactorB;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critDamageFactorB").Value, out critDamageFactorB))
            //    {
            //        errMsg = string.Format("<fight> - <critDamageFactorB>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critDamageMin;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critDamageMin").Value, out critDamageMin))
            //    {
            //        errMsg = string.Format("<fight> - <critDamageMin>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float critDamageMax;
            //    if (!VaildUtil.TryConvertFloat(e.Element("critDamageMax").Value, out critDamageMax))
            //    {
            //        errMsg = string.Format("<fight> - <critDamageMax>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float defFactor;
            //    if (!VaildUtil.TryConvertFloat(e.Element("defFactor").Value, out defFactor))
            //    {
            //        errMsg = string.Format("<fight> - <defFactor>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float resumeFactor;
            //    if (!VaildUtil.TryConvertFloat(e.Element("resumeFactor").Value, out resumeFactor))
            //    {
            //        errMsg = string.Format("<fight> - <resumeFactor>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    float randomNum;
            //    if (!VaildUtil.TryConvertFloat(e.Element("randomNum").Value, out randomNum))
            //    {
            //        errMsg = string.Format("<fight> - <randomNum>节点值必须为0 - {0}的整数", float.MaxValue);
            //        return false;
            //    }
            //    string skillCircleEffect = e.Element("skillCircleEffect").Value;
            //    string skillDirEffect = e.Element("skillDirEffect").Value;
            //    string skillPointEffect = e.Element("skillPointEffect").Value;
            //    string skillbigHuduEffect = e.Element("skillbigHuduEffect").Value;
            //    string skillsmallHuduEffect = e.Element("skillsmallHuduEffect").Value;
            //    string selectMonster = e.Element("selectMonster").Value;
            //    string selectHero = e.Element("selectHero").Value;
            //    string clickPoint = e.Element("clickPoint").Value;
            //    string battleStart = e.Element("battleStart").Value;
            //    string battleStar1 = e.Element("battleStar1").Value;
            //    string battleStar2 = e.Element("battleStar2").Value;
            //    string battleStar3 = e.Element("battleStar3").Value;
            //    string battleLoseeffect = e.Element("battleLoseeffect").Value;
            //    string findBoss = e.Element("findBoss").Value;
            //    string atkFocus = e.Element("atkFocus").Value;
            //    string skillactive = e.Element("skillactive").Value;
            //    string uniqueSkill = e.Element("uniqueSkill").Value;



            //    config.InitAvo = initAvo;
            //    config.AvoFactorA = avoFactorA;
            //    config.AvoFactorB = avoFactorB;
            //    config.AvoMin = avoMin;
            //    config.AvoMax = avoMax;
            //    config.InitCrit = config.InitCrit;
            //    config.CritFactorA = critFactorA;
            //    config.CritFactorB = critFactorB;
            //    config.CritMin = critMin;
            //    config.CritMax = critMax;
            //    config.InitCritDamage = initCritDamage;
            //    config.CritDamageFactorA = critDamageFactorA;
            //    config.CritDamageFactorB = critDamageFactorB;
            //    config.CritDamageMin = critDamageMin;
            //    config.CritDamageMax = critDamageMax;
            //    config.DefFactor = defFactor;
            //    config.ResumeFactor = resumeFactor;
            //    config.RandomNum = randomNum;
            //    config.SkillCircleEffect = skillCircleEffect;
            //    config.SkillDirEffect = skillDirEffect;
            //    config.SkillPointEffect = skillPointEffect;
            //    config.SkillbigHuduEffect = skillbigHuduEffect;
            //    config.SkillsmallHuduEffect = skillsmallHuduEffect;
            //    config.SelectMonster = selectMonster;
            //    config.SelectHero = selectHero;
            //    config.ClickPoint = clickPoint;
            //    config.BattleStart = battleStart;
            //    config.BattleStar1 = battleStar1;
            //    config.BattleStar2 = battleStar2;
            //    config.BattleStar3 = battleStar3;
            //    config.BattleLoseeffect = battleLoseeffect;
            //    config.FindBoss = findBoss;
            //    config.AtkFocus = atkFocus;
            //    config.Skillactive = skillactive;
            //    config.UniqueSkill = uniqueSkill;

            //    return true;
            //}


        protected override string GetConfigName()
        {
            return SysConstant.SYSTEM_CONFIG;
        }
    }
}
