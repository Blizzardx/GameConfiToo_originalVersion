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
    public class MissionStepImporter : AbstractExcelImporter
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

            MissionStepConfigTable config = new MissionStepConfigTable();
            tbase = config;
            config.MissionStepByMissionIdConfigMap = new Dictionary<int, List<MissionStepConfig>>();
            config.MissionStepByStepIdConfigMap = new Dictionary<int, MissionStepConfig>();


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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分任务ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int missionId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out missionId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分任务ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int sceneId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sceneId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分任务场景ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int sceneLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sceneLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分任务场景条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int sceneFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sceneFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分任务场景功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int completeLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out completeLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分任务完成条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int completeFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out completeFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分任务完成功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int guideMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out guideMessageId, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，完成引导消息ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string guideAudioId = values[i][index++];
                   
                    
                    XElement equipmentE = new XElement("missionStep");
                    root.Add(equipmentE);
                    equipmentE.Add(new XAttribute("id", missionId));
                    equipmentE.Add(new XAttribute("sceneId", sceneId));
                    equipmentE.Add(new XAttribute("sceneLimitId", sceneLimitId));
                    equipmentE.Add(new XAttribute("sceneFuncId", sceneFuncId));
                    equipmentE.Add(new XAttribute("completeLimitId", completeLimitId));
                    equipmentE.Add(new XAttribute("completeFuncId", completeFuncId));
                    //equipmentE.Add(new XAttribute("guideType", guideType));
                    //foreach (GuideParamEntry ep in GuideParamEntryList)
                    //{
                    //    XElement propertyE = new XElement("guideParam");
                    //    equipmentE.Add(propertyE);
                    //    propertyE.Add(new XAttribute("key", ep.Key));
                    //    propertyE.Add(new XAttribute("value", ep.Value));
                    //}

                    MissionStepConfig c = new MissionStepConfig();

                    c.Id = id;
                    c.MissionId = missionId;
                    c.SceneId = sceneId;
                    c.SceneLimitId = sceneLimitId;
                    c.SceneFuncId = sceneFuncId;
                    c.CompleteLimitId = completeLimitId;
                    c.CompleteFuncId = completeFuncId;
                    c.GuideMessageId = guideMessageId;
                    c.GuideAudioId = guideAudioId;
                    
                    if (!config.MissionStepByMissionIdConfigMap.ContainsKey(c.MissionId))
                    {
                        config.MissionStepByMissionIdConfigMap.Add(c.MissionId, new List<MissionStepConfig>());
                    }
                    List<MissionStepConfig> tmp = config.MissionStepByMissionIdConfigMap[c.MissionId];
                    tmp.Add(c);

                    if (config.MissionStepByStepIdConfigMap.ContainsKey(c.Id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] 任务阶段表，任务阶段id:[{2}]读取出现错误，ID不唯一", this.GetConfigName(), sheetName, c.Id);
                        return;
                    }
                    config.MissionStepByStepIdConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.MISSION_STEP_CONFIG;
        }
    }
}
