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
    public partial class EndlessStageConfigImporter : AbstractExcelImporter
    {
        private EndlessStageConfigTable config;
        private XElement e;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.ENDLESS_STAGE_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if(startCurveId > endCurveId)
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，难度曲线表起始Id不能小于结束Id", this.GetConfigName(), sheetName, row);
                return;
            }
            if (cycleStartCurveId > cycleEndCurveId)
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，循环难度曲线表起始Id不能小于结束Id", this.GetConfigName(), sheetName, row);
                return;
            }

            //List<int> rewardItemIdList = VaildUtil.SplitToList_int(rewardItemIds);

            XElement endlessStageE = new XElement("endlessStage");
            e.Add(endlessStageE);
            endlessStageE.Add(new XAttribute("id", id));
            endlessStageE.Add(new XAttribute("name", nameMessageId));
            endlessStageE.Add(new XAttribute("activeLimitId", activeLimitId));
            endlessStageE.Add(new XAttribute("difficultyDegree", difficultyDegree));
            endlessStageE.Add(new XAttribute("maxScore", maxScore));

            if (rewardItemIds != null && rewardItemIds.Count > 0)
            {
                foreach (int itemId in rewardItemIds)
                {
                    XElement rewardItemIdE = new XElement("rewardItemId");
                    endlessStageE.Add(rewardItemIdE);
                    rewardItemIdE.Add(itemId);
                }
            }

            EndlessStageConfig c = new EndlessStageConfig();
            c.Id = id;
            c.NameMessageId = nameMessageId;
            c.DescMessageId = descMessageId;
            c.ActiveLimitId = activeLimitId;
            c.DifficultyDegree = difficultyDegree;
            c.StartCurveId = startCurveId;
            c.EndCurveId = endCurveId;
            c.CycleStartCurveId = cycleStartCurveId;
            c.CycleEndCurveId = cycleEndCurveId;
            c.RewardMessageId = rewardMessageId;
            c.Thumbnail = thumbnail;
            c.ScenceIdList = scenceIds;
            c.SequenceNum = sequenceNum;
            c.MaxScore = maxScore;
            c.RewardItemIdList = rewardItemIds;
            c.RewardMessageId = rewardMessageId;
            config.EndlessStageConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new EndlessStageConfigTable();
            config.EndlessStageConfigMap = new Dictionary<int, EndlessStageConfig>();

            e = new XElement("root");
        }
    }
}
