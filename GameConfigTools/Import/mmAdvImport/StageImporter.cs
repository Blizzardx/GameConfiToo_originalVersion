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
                    string stageIcon = values[i][index++];
                    if (string.IsNullOrEmpty(stageIcon))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡缩略图不能为空", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string nameAudioId = values[i][index++];

                    string desc = values[i][index++];
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string descAudioId = values[i][index++];

                    string help = values[i][index++];
                    int helpMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out helpMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡帮助ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string helpAudioId = values[i][index++];
                    
                    int stageMapId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out stageMapId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡地图方案ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int recommendLevel;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out recommendLevel))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，推荐等级必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, short.MaxValue);
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
                    int loseFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out loseFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡失败功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    XElement stageE = new XElement("stage");
                    root.Add(stageE);
                    stageE.Add(new XAttribute("id", id));
                    stageE.Add(new XAttribute("nextStageId", nextStageId));
                    stageE.Add(new XAttribute("name", name));
                    stageE.Add(new XAttribute("stageMapId", stageMapId));
                    stageE.Add(new XAttribute("enterLimitId", enterLimitId));
                    stageE.Add(new XAttribute("enterFuncId", enterFuncId));
                    stageE.Add(new XAttribute("loseFuncId", loseFuncId));
                    stageE.Add(new XAttribute("winLimitId", winLimitId));
                    stageE.Add(new XAttribute("winFuncId", winFuncId));


                    StageConfig c = new StageConfig();
                    c.Id = id;
                    c.NextStageId = nextStageId;
                    c.NameMessageId = nameMessageId;
                    c.NameAudioId = nameAudioId;
                    c.DescMessageId = descMessageId;
                    c.DescAudioId = descAudioId;
                    c.HelpMessageId = helpMessageId;
                    c.HelpAudioId = helpAudioId;
                    c.StageMapId = stageMapId;
                    c.RecommendLevel = (short)recommendLevel;
                    c.EnterLimitId = enterLimitId;
                    c.EnterFuncId = enterFuncId;
                    c.LoseFuncId = loseFuncId;
                    c.WinLimitId = c.WinLimitId;
                    c.WinFuncId = winFuncId;

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
