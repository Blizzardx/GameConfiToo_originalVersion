using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class StageImporter : AbstractExcelImporter
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

            StageConfigTable config = new StageConfigTable();
            tbase = config;
            config.StageConfigMap = new Dictionary<int, StageConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int nextStageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nextStageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，下一个关卡ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    //章节ID
                    int chapterId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out chapterId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，章节ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string titleResource = values[i][index ++];
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int stageType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out stageType,0,2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int unlockLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out unlockLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int showMonster;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out showMonster))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，showmnster id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int failLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out failLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int totalTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out totalTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总时长必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int winLimitID;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out winLimitID))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetLimitId1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetLimitId1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetFunc1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetFunc1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetMessageId1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetMessageId1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetLimitId2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetLimitId2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetFunc2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetFunc2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetMessageId2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetMessageId2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetLimitId3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetLimitId3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetFunc3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetFunc3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int targetMessageId3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetMessageId3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string stageMaprResource = values[i][index++];

                    int beforeStoryId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out beforeStoryId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int afterStoryId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out afterStoryId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string modelID = values[i][index++];
                    
                    string modelAction = values[i][index++];
                    
                    string modelActionPass = values[i][index++];
                    int starBit4CountId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out starBit4CountId, 0, 2048))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，星级的8位计数器ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, 2048);
                        return;
                    }
                    int weatherPlanid;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out weatherPlanid))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，天气策略id必须为整型", this.GetConfigName(), sheetName, row, index, 2048);
                        return;
                    }

                    XElement stageE = new XElement("stage");
                    root.Add(stageE);
                    stageE.Add(new XAttribute("id", id));
                    stageE.Add(new XAttribute("nextStageId", nextStageId));
                    stageE.Add(new XAttribute("chapterId", chapterId));
                    stageE.Add(new XAttribute("titleResource", titleResource));
                    stageE.Add(new XAttribute("type", stageType));
                    stageE.Add(new XAttribute("stageMaprResource", stageMaprResource));
                    stageE.Add(new XAttribute("unlockLimitId", unlockLimitId));
                    stageE.Add(new XAttribute("totalTime", totalTime));
                    stageE.Add(new XAttribute("winLimitID", winLimitID));
                    stageE.Add(new XAttribute("targetLimitId1", targetLimitId1));
                    stageE.Add(new XAttribute("targetFunc1", targetFunc1));
                    stageE.Add(new XAttribute("targetMessageId1", targetMessageId1));
                    stageE.Add(new XAttribute("targetLimitId2", targetLimitId2));
                    stageE.Add(new XAttribute("targetFunc2", targetFunc2));
                    stageE.Add(new XAttribute("targetMessageId2", targetMessageId2));
                    stageE.Add(new XAttribute("targetLimitId3", targetLimitId3));
                    stageE.Add(new XAttribute("targetFunc3", targetFunc3));
                    stageE.Add(new XAttribute("targetMessageId3", targetMessageId3));
                    stageE.Add(new XAttribute("beforeStoryId", beforeStoryId));
                    stageE.Add(new XAttribute("afterStoryId", afterStoryId));
                   // stageE.Add(new XAttribute("modelID", modelID));
                    stageE.Add(new XAttribute("starBit4CountId", starBit4CountId));
                    
                    StageConfig c = new StageConfig();
                    c.Id = id;
                    c.NextStageId = nextStageId;
                    c.NameMessageId = nameMessageId;
                    c.DescMessageId = descMessageId;
                    c.ChapterId = chapterId;
                    c.StageMaprResource = stageMaprResource;
                    c.BeforeStoryId = beforeStoryId;
                    c.AfterStoryId = afterStoryId;
                    c.WinLimitId = winLimitID;
                    c.StarBit4CountId = starBit4CountId;
                    c.WeatherPlanId = weatherPlanid;
                    c.TitleResource = titleResource;
                    c.StageType = stageType;
                    c.UnlockLimitId = unlockLimitId;
                    c.ShowMonsterId = showMonster;
                    c.FailLimitId = failLimitId;
                    c.TotalTime = totalTime;
                    c.WinLimitId = winLimitID;
                    c.TargetLimitId1 = targetLimitId1;
                    c.TargetFunc1 = targetFunc1;
                    c.TargetMessageId1 = targetMessageId1;
                    c.TargetLimitId2 = targetLimitId2;
                    c.TargetMessageId2 = targetMessageId2;
                    c.TargetFunc2 = targetFunc2;
                    c.TargetLimitId3 = targetLimitId3;
                    c.TargetFunc3 = targetFunc3;
                    c.TargetMessageId3 = targetMessageId3;
                    c.ModelID = modelID;
                    c.ModelAction = modelAction;
                    c.ModelActionPass = modelActionPass;
                    config.StageConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.STAGE_CONFIG;
        } 
    }
}
