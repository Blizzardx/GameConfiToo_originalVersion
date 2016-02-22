using Config;
using Config.Table;
using GameConfigTools.Constant;
//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// FileName : StoryImporter
//
// Created by : Baoxue at 2016/2/22 14:58:20
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class StoryImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            root = new XElement("storyConfigTable");
            StoryConfigTable storyConfigTable = new StoryConfigTable();
            storyConfigTable.StoryConfigMap = new Dictionary<int, List<Config.StoryConfig>>();

            tbase = storyConfigTable;

            string[][] content = sheetValues[0];
            for (int i = 0; i < content.Length; ++i)
            {
                if (null == content[i][0])
                {
                    continue;
                }
                if ("" == content[i][0])
                {
                    break;
                }
                string[] line = content[i];
                int index = 0;

                int id;
                int dialogId;
                int talkerId;
                bool isFocusOn;
                int delay;

                if (!int.TryParse(line[index++], out id))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                if (!int.TryParse(line[index++], out dialogId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                if (!int.TryParse(line[index++], out talkerId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                int tmpbool = 0;
                if (!int.TryParse(line[index++], out tmpbool))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                isFocusOn = tmpbool == 1;

                if (!int.TryParse(line[index++], out delay))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }

                //out put xml
                XElement npcDataGroup = new XElement("StoryConfig", new XAttribute("id", id));
                root.Add(npcDataGroup);

                XElement npcDataElement = new XElement("storyElement",
                    new XAttribute("id", id));

                npcDataGroup.Add(npcDataElement);

                //out put thrift
                StoryConfig storyElem = new StoryConfig();
                storyElem.Id = id;
                storyElem.TalkerId = talkerId;
                storyElem.IsFocusOnTalker = isFocusOn;
                storyElem.DialogId = dialogId;
                storyElem.Delay = delay;

                if (!storyConfigTable.StoryConfigMap.ContainsKey(storyElem.Id))
                {
                    storyConfigTable.StoryConfigMap.Add(storyElem.Id,new List<StoryConfig>());
                }
                storyConfigTable.StoryConfigMap[storyElem.Id].Add(storyElem);
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.STORY_CONFIG;
        }
    }
}
