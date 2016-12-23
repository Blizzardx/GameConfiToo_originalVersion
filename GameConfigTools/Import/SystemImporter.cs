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
            systemConfig.CharacterConfig = new SystemCharacterConfig();
            systemConfig.LoverConfig = new SystemLoverConfig();
            systemConfig.EndlessConfig = new SystemEndlessConfig();
            systemConfig.GuildConfig = new SystemGuildConfig();

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
            if(!ValidCharacterConfig(root, systemConfig.CharacterConfig, ref errMsg))
            {
                return false;
            }
            if (!ValidLoverConfig(root, systemConfig.LoverConfig, ref errMsg))
            {
                return false;
            }
            if (!ValidEndlessConfig(root, systemConfig.EndlessConfig, ref errMsg))
            {
                return false;
            }
            if (!ValidGuildConfig(root, systemConfig.GuildConfig, ref errMsg))
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
        private bool ValidCharacterConfig(XElement root, SystemCharacterConfig config, ref string errMsg)
        {
            config.MaleInitDIYList = new List<InitDIYConfig>();
            config.FemaleInitDIYList = new List<InitDIYConfig>();

            XElement characterE = root.Element("character");

            int maxLevel;
            if (!int.TryParse(characterE.Element("maxLevel").Value, out maxLevel))
            {
                errMsg = "<maxLevel> 必须为整数";
                return false;
            }
            config.MaxLevel = maxLevel;

            XElement initDiysE = characterE.Element("initDiys");
            var maleDiys = initDiysE.Elements("maleDiy");
            var femaleDiys = initDiysE.Elements("femaleDiy");

            HashSet<int> posSet = new HashSet<int>();

            foreach(var maleDiy in maleDiys)
            {
                int pos;
                if (!int.TryParse(maleDiy.Attribute("pos").Value, out pos))
                {
                    errMsg = "<maleDiy> pos属性必须为整数";
                    return false;
                }
                int itemId;
                if (!int.TryParse(maleDiy.Attribute("itemId").Value, out itemId))
                {
                    errMsg = "<maleDiy> itemId属性必须为整数";
                    return false;
                }
                if (!posSet.Add(pos))
                {
                    errMsg = "<maleDiy> pos属性值:" + pos + " 已存在";
                    return false;
                }
                InitDIYConfig c = new InitDIYConfig();
                c.Pos = pos;
                c.ItemId = itemId;
                config.MaleInitDIYList.Add(c);
            }
            posSet.Clear();
            foreach (var maleDiy in femaleDiys)
            {
                int pos;
                if (!int.TryParse(maleDiy.Attribute("pos").Value, out pos))
                {
                    errMsg = "<femaleDiy> pos属性必须为整数";
                    return false;
                }
                int itemId;
                if (!int.TryParse(maleDiy.Attribute("itemId").Value, out itemId))
                {
                    errMsg = "<femaleDiy> itemId属性必须为整数";
                    return false;
                }
                if (!posSet.Add(pos))
                {
                    errMsg = "<femaleDiy> pos属性值:" + pos + " 已存在";
                    return false;
                }
                InitDIYConfig c = new InitDIYConfig();
                c.Pos = pos;
                c.ItemId = itemId;
                config.FemaleInitDIYList.Add(c);
            }
            return true;
        }
        private bool ValidLoverConfig(XElement root, SystemLoverConfig config, ref string errMsg)
        {
            root = root.Element("friend");
            config.ExpStepInfoList = new List<SystemLoverExpStepInfo>();
            var list = root.Element("loverExpSteps").Elements("loverExpStep");
            foreach (var elem in list)
            {
                SystemLoverExpStepInfo elemInfo = new SystemLoverExpStepInfo();
                int min, max;
                if (!int.TryParse(elem.Attribute("min").Value, out min))
                {
                    errMsg = "<loverExpSteps-min> 必须为整数";
                    return false;
                }
                if (!int.TryParse(elem.Attribute("max").Value, out max))
                {
                    errMsg = "<loverExpSteps-max> 必须为整数";
                    return false;
                }
                elemInfo.Icon = elem.Attribute("icon").Value;
                elemInfo.Min = min;
                elemInfo.Max = max;

                config.ExpStepInfoList.Add(elemInfo);
            }
            int maxLoverExp = 0;
            int battleAddLoverExpCycleId = 0;
            int battleAddLoverExpCounterId = 0;
            int findLoverIB = 0;
            int battleAddLoverExp = 0;
            int battleAddLoverExpCount = 0;
            int loverGiftListCycleId = 0;
            int loverGiftListCounterId = 0;

            if (!int.TryParse(root.Element("maxLoverExp").Value, out maxLoverExp))
            {
                errMsg = "<maxLoverExp> 必须为整数";
                return false;
            }
            config.MaxLoverExp = maxLoverExp;
            if (!int.TryParse(root.Element("battleAddLoverExpCycleId").Value, out battleAddLoverExpCycleId))
            {
                errMsg = "<battleAddLoverExpCycleId> 必须为整数";
                return false;
            }
            config.BattleAddLoverExpCycleId = battleAddLoverExpCycleId;
            if (!int.TryParse(root.Element("battleAddLoverExpCounterId").Value, out battleAddLoverExpCounterId))
            {
                errMsg = "<battleAddLoverExpCounterId> 必须为整数";
                return false;
            }
            config.BattleAddLoverExpCounterId = battleAddLoverExpCounterId;
            if (!int.TryParse(root.Element("findLoverIB").Value, out findLoverIB))
            {
                errMsg = "<findLoverIB> 必须为整数";
                return false;
            }
            config.FindLoverIB = findLoverIB;

            if (!int.TryParse(root.Element("battleAddLoverExp").Value, out battleAddLoverExp))
            {
                errMsg = "<battleAddLoverExp> 必须为整数";
                return false;
            }
            config.BattleAddLoverExp = battleAddLoverExp;

            if (!int.TryParse(root.Element("battleAddLoverExpCount").Value, out battleAddLoverExpCount))
            {
                errMsg = "<battleAddLoverExpCount> 必须为整数";
                return false;
            }
            config.BattleAddLoverExpCount = battleAddLoverExpCount;

            if (!int.TryParse(root.Element("loverGiftListCycleId").Value, out loverGiftListCycleId))
            {
                errMsg = "<loverGiftListCycleId> 必须为整数";
                return false;
            }
            config.LoverGiftListCycleId = loverGiftListCycleId;

            if (!int.TryParse(root.Element("loverGiftListCounterId").Value, out loverGiftListCounterId))
            {
                errMsg = "<loverGiftListCounterId> 必须为整数";
                return false;
            }
            config.LoverGiftListCounterId = loverGiftListCounterId;

            var giftlist = root.Element("loverGifts").Elements("loverGift");
            config.GiftInfoList = new List<SystemLoverGiftInfo>();
            foreach (var elem in giftlist)
            {
                SystemLoverGiftInfo elemInfo = new SystemLoverGiftInfo();
                int itemId, counterId, max,broadcastMessageId;

                if (!int.TryParse(elem.Attribute("itemId").Value, out itemId))
                {
                    errMsg = "<loverGift-itemId> 必须为整数";
                    return false;
                }
                if (!int.TryParse(elem.Attribute("counterId").Value, out counterId))
                {
                    errMsg = "<loverGift-counterId> 必须为整数";
                    return false;
                }
                if (!int.TryParse(elem.Attribute("max").Value, out max))
                {
                    errMsg = "<loverGift-max> 必须为整数";
                    return false;
                }
                if (!int.TryParse(elem.Attribute("broadcastMessageId").Value, out broadcastMessageId))
                {
                    errMsg = "<loverGift-broadcastMessageId> 必须为整数";
                    return false;
                }

                elemInfo.ItemId = itemId;
                elemInfo.CounterId = counterId;
                elemInfo.Max = max;
                elemInfo.BroadcastMessageId = broadcastMessageId;
                config.GiftInfoList.Add(elemInfo);
            }

            return true;
        }
        private bool ValidEndlessConfig(XElement root, SystemEndlessConfig config, ref string errMsg)
        {
            root = root.Element("endless");

            int friendInvitationCd;
            int guildInvitationCd;
            int IdleInvitationCd;
            int treasureCountId ;
            int treasureFreeCountId ;
            int treasureInitNum ;
            int treasureBuyNum;

            if (!int.TryParse(root.Element("friendInvitationCd").Value, out friendInvitationCd))
            {
                errMsg = "<friendInvitationCd> 必须为整数";
                return false;
            }
            config.FriendInvitationCd = friendInvitationCd;

            if (!int.TryParse(root.Element("guildInvitationCd").Value, out guildInvitationCd))
            {
                errMsg = "<guildInvitationCd> 必须为整数";
                return false;
            }
            config.GuildInvitationCd = guildInvitationCd;

            if (!int.TryParse(root.Element("IdleInvitationCd").Value, out IdleInvitationCd))
            {
                errMsg = "<IdleInvitationCd> 必须为整数";
                return false;
            }
            config.IdleInvitationCd = IdleInvitationCd;

            if (!int.TryParse(root.Element("treasureCountId").Value, out treasureCountId))
            {
                errMsg = "<treasureCountId> 必须为整数";
                return false;
            }
            config.TreasureCountId = treasureCountId;

            if (!int.TryParse(root.Element("treasureFreeCountId").Value, out treasureFreeCountId))
            {
                errMsg = "<treasureFreeCountId> 必须为整数";
                return false;
            }
            config.TreasureFreeCountId = treasureFreeCountId;

            if (!int.TryParse(root.Element("treasureInitNum").Value, out treasureInitNum))
            {
                errMsg = "<treasureInitNum> 必须为整数";
                return false;
            }
            config.TreasureInitNum = treasureInitNum;

            if (!int.TryParse(root.Element("treasureBuyNum").Value, out treasureBuyNum))
            {
                errMsg = "<treasureBuyNum> 必须为整数";
                return false;
            }
            config.TreasureBuyNum = treasureBuyNum;

            return true;
        }

        private bool ValidGuildConfig(XElement root, SystemGuildConfig config, ref string errMsg)
        {
            XElement guildE = root.Element("guild");
            int createGuildPrice;
            if (!int.TryParse(guildE.Element("createGuildPrice").Value, out createGuildPrice))
            {
                errMsg = "<createGuildPrice> 必须为整数";
                return false;
            }
            int changeGuildNamePrice;
            if (!int.TryParse(guildE.Element("changeGuildNamePrice").Value, out changeGuildNamePrice))
            {
                errMsg = "<changeGuildNamePrice> 必须为整数";
                return false;
            }
            int changeGuildIconPrice;
            if (!int.TryParse(guildE.Element("changeGuildIconPrice").Value, out changeGuildIconPrice))
            {
                errMsg = "<changeGuildIconPrice> 必须为整数";
                return false;
            }
            int localRecruitPrice;
            if (!int.TryParse(guildE.Element("localRecruitPrice").Value, out localRecruitPrice))
            {
                errMsg = "<localRecruitPrice> 必须为整数";
                return false;
            }
            int crossRecruitPrice;
            if (!int.TryParse(guildE.Element("crossRecruitPrice").Value, out crossRecruitPrice))
            {
                errMsg = "<crossRecruitPrice> 必须为整数";
                return false;
            }
            config.CreateGuildPrice = createGuildPrice;
            config.ChangeGuildNamePrice = changeGuildNamePrice;
            config.ChangeGuildIconPrice = changeGuildIconPrice;
            config.LocalRecruitPrice = localRecruitPrice;
            config.CrossRecruitPrice = crossRecruitPrice;

            config.PowerConfigMap = new Dictionary<int, GuildPowerConfig>();

            var powersE = guildE.Element("powers").Elements("power");
            foreach (var powerE in powersE)
            {
                int id;
                if (!int.TryParse(powerE.Attribute("id").Value, out id))
                {
                    errMsg = "<power> id属性必须为整数";
                    return false;
                }
                int weight;
                if (!int.TryParse(powerE.Attribute("weight").Value, out weight))
                {
                    errMsg = "<power> weight属性必须为整数";
                    return false;
                }
                GuildPowerConfig c = new GuildPowerConfig();
                c.PowerId = id;
                c.Weight = weight;
                config.PowerConfigMap.Add(c.PowerId, c);
            }
            config.RightConfigMap = new Dictionary<int, GuildRightConfig>();
            var rightsE = guildE.Element("rights").Elements("right");
            foreach (var rightE in rightsE)
            {
                int id;
                if (!int.TryParse(rightE.Attribute("id").Value, out id))
                {
                    errMsg = "<right> id属性必须为整数";
                    return false;
                }
                int weight;
                if (!int.TryParse(rightE.Attribute("weight").Value, out weight))
                {
                    errMsg = "<right> weight属性必须为整数";
                    return false;
                }
                GuildRightConfig c = new GuildRightConfig();
                c.RightId = id;
                c.Weight = weight;
                config.RightConfigMap.Add(c.RightId, c);
            }
            config.DonateConfigList = new List<GuildDonateConfig>();
            var donatesE = guildE.Element("donates").Elements("donate");
            foreach (var donateE in donatesE)
            {
                GuildDonateConfig c = new GuildDonateConfig();

                int id;
                if (!int.TryParse(donateE.Attribute("id").Value, out id))
                {
                    errMsg = "<donate> id属性必须为整数";
                    return false;
                }
                int type;
                if (!VaildUtil.TryConvertInt(donateE.Attribute("type").Value, out type, 1, 2))
                {
                    errMsg = "<donate> type属性必须为1-2整数";
                    return false;
                }
                int currencyType;
                if (donateE.Attribute("currencyType") != null)
                {
                    if (!VaildUtil.TryConvertInt(donateE.Attribute("currencyType").Value, out currencyType, 1, 4))
                    {
                        errMsg = "<donate> currencyType属性必须为1-4整数";
                        return false;
                    }
                    c.CurrencyType = currencyType;
                }
                else
                {
                    if (type == 1)
                    {
                        errMsg = "<donate> type等于1时必须要配置currencyType属性";
                        return false;
                    }
                }

                int itemId;
                if (donateE.Attribute("itemId") != null)
                {
                    if (!int.TryParse(donateE.Attribute("itemId").Value, out itemId))
                    {
                        errMsg = "<donate> count属性必须为整数";
                        return false;
                    }
                    c.ItemId = itemId;
                }
                else
                {
                    if (type == 2)
                    {
                        errMsg = "<donate> type等于2时必须要配置itemId属性";
                        return false;
                    }
                }
                
                int count;
                if (!int.TryParse(donateE.Attribute("count").Value, out count))
                {
                    errMsg = "<donate> count属性必须为整数";
                    return false;
                }
                int cycleId;
                if (!int.TryParse(donateE.Attribute("cycleId").Value, out cycleId))
                {
                    errMsg = "<donate> cycleId属性必须为整数";
                    return false;
                }
                int cycleCounterId;
                if (!int.TryParse(donateE.Attribute("cycleCounterId").Value, out cycleCounterId))
                {
                    errMsg = "<donate> cycleCounterId属性必须为整数";
                    return false;
                }
                int honer;
                if (!int.TryParse(donateE.Attribute("honer").Value, out honer))
                {
                    errMsg = "<donate> honor属性必须为整数";
                    return false;
                }
                c.Id = id;
                c.Type = type == 1 ? GuildDonateType.Currency : GuildDonateType.Item;
                c.Count = count;
                c.CycleId = cycleId;
                c.CycleCounterId = cycleCounterId;
                c.Honer = honer;
                config.DonateConfigList.Add(c);
            }
            return true;
        }

        protected override string GetConfigName()
        {
            return SysConstant.SYSTEM_CONFIG;
        }
    }
}
