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
                    string name = values[i][index++];
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string help = values[i][index++];
                    int helpMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out helpMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡帮助ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int targetMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，副本关卡目标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    //章节ID
                    int chapterId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out chapterId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，章节ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string stageMaprResource = values[i][index++];
                    int beforeStoryId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out beforeStoryId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，前置剧情ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int afterStoryId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out afterStoryId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，后置剧情ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    
                    string backgroundPic = values[i][index++];
                    
                    string iconPic = values[i][index++];
                    string iconPicPass = values[i][index++];
                    int quickWinLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quickWinLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡扫荡条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int quickWinFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quickWinFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡扫荡功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int enterLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out enterLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，进入关卡条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int enterFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out enterFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，进入关卡功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int beforeShowLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out beforeShowLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，展示前条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int beforeShowFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out beforeShowFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，展示前功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int loseLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out loseLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡失败条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int loseFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out loseFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡失败功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int winLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out winLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡通关后条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int winFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out winFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡通关后功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<int> dropIdList = VaildUtil.SplitToList(values[i][index++]);
                    if (dropIdList == null)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，掉落列表ID组必须以\",\"分割，并且每个ID都为整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<int> showDropItemIdList = VaildUtil.SplitToList(values[i][index++]);
                    if (showDropItemIdList == null)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，显示掉落列表ID组必须以\",\"分割，并且每个ID都为整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<int> showMonsterIdList = VaildUtil.SplitToList(values[i][index++]);
                    if (showMonsterIdList == null)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，显示怪物列表ID组必须以\",\"分割，并且每个ID都为整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
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
                    stageE.Add(new XAttribute("name", name));
                    stageE.Add(new XAttribute("chapterId", chapterId));
                    stageE.Add(new XAttribute("quickWinLimitId", quickWinLimitId));
                    stageE.Add(new XAttribute("quickWinFuncId", quickWinFuncId));
                    stageE.Add(new XAttribute("enterLimitId", enterLimitId));
                    stageE.Add(new XAttribute("enterFuncId", enterFuncId));
                    stageE.Add(new XAttribute("beforeShowLimitId", beforeShowLimitId));
                    stageE.Add(new XAttribute("beforeShowFuncId", beforeShowFuncId));
                    stageE.Add(new XAttribute("loseLimitId", loseLimitId));
                    stageE.Add(new XAttribute("loseFuncId", loseFuncId));
                    stageE.Add(new XAttribute("winLimitId", winLimitId));
                    stageE.Add(new XAttribute("winFuncId", winFuncId));
                    stageE.Add(new XAttribute("starBit4CountId", starBit4CountId));


                    XElement dropIdListE = new XElement("dropIdList");
                    stageE.Add(dropIdListE);
                    foreach(int dropId in dropIdList)
                    {
                        if (dropId == 0)
                        {
                            continue;
                        }
                        dropIdListE.Add(new XElement("dropId", dropId));
                    }

                    StageConfig c = new StageConfig();
                    c.Id = id;
                    c.NextStageId = nextStageId;
                    c.NameMessageId = nameMessageId;
                    c.DescMessageId = descMessageId;
                    c.HelpMessageId = helpMessageId;
                    c.TargetMessageId = targetMessageId;
                    c.ChapterId = chapterId;
                    c.StageMaprResource = stageMaprResource;
                    c.BeforeStoryId = beforeStoryId;
                    c.AfterStoryId = afterStoryId;
                    c.BackgroundPic = backgroundPic;
                    c.IconPic = iconPic;
                    c.IconPicPass = iconPicPass;
                    c.QuickWinLimitId = quickWinLimitId;
                    c.QuickWinFuncId = quickWinFuncId;
                    c.EnterLimitId = enterLimitId;
                    c.EnterFuncId = enterFuncId;
                    c.BeforeShowLimitId = beforeShowLimitId;
                    c.BeforeShowFuncId = beforeShowFuncId;
                    c.LoseLimitId = loseLimitId;
                    c.LoseFuncId = loseFuncId;
                    c.WinLimitId = winLimitId;
                    c.WinFuncId = winFuncId;
                    c.DropIdList = new List<int>();
                    c.ShowDropItemIdList = new List<int>();
                    c.ShowMonsterIdList = new List<int>();
                    foreach (int dropId in dropIdList)
                    {
                        if (dropId == 0)
                        {
                            continue;
                        }
                        c.DropIdList.Add(dropId);
                    }
                    foreach (int showDropItemId in showDropItemIdList)
                    {
                        if (showDropItemId == 0)
                        {
                            continue;
                        }
                        c.ShowDropItemIdList.Add(showDropItemId);
                    }
                    foreach (int showMonsterId in showMonsterIdList)
                    {
                        if (showMonsterId == 0)
                        {
                            continue;
                        }
                        c.ShowMonsterIdList.Add(showMonsterId);
                    }
                    c.StarBit4CountId = starBit4CountId;
                    c.WeatherPlanId = weatherPlanid;
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
