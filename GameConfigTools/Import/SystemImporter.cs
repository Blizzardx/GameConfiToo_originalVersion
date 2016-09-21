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

        protected override string GetConfigName()
        {
            return SysConstant.SYSTEM_CONFIG;
        }
    }
}
