using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class PvpStageConfigImporter:AbstractExcelImporter
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

            PvpStageConfigTable config = new PvpStageConfigTable();
            tbase = config;
            config.StageConfigMap = new Dictionary<int, PvpStageConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string stageMapResource = values[i][index++];
                    string icon = values[i][index++];
                    int endLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out endLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int endFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out endFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int modeId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out modeId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，模式必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int resultId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out resultId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，结算ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<int> dropIdList = VaildUtil.SplitToList(values[i][index++]);
                    if (dropIdList == null)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，掉落列表ID组必须以\",\"分割，并且每个ID都为整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int starbyteCounterId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out starbyteCounterId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int weatherPlanId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out weatherPlanId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int godStateTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out godStateTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int initCradit;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out initCradit))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int atkCraditPet;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out atkCraditPet))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int killCraditPet;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out killCraditPet))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int bekillCraditPet;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out bekillCraditPet))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int otherUserCol;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out otherUserCol))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int killPet;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out killPet))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int birthBuff;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out birthBuff))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    XElement stageE = new XElement("pvpStage");
                    root.Add(stageE);
                    stageE.Add(new XAttribute("id", id));
                    stageE.Add(new XAttribute("name", name));
                    stageE.Add(new XAttribute("stageMapResource", stageMapResource));
                    stageE.Add(new XAttribute("endLimitId", endLimitId));
                    stageE.Add(new XAttribute("endFuncId", endFuncId));
                    stageE.Add(new XAttribute("modeId", modeId));
                    stageE.Add(new XAttribute("resultId", resultId));
                    stageE.Add(new XAttribute("godStateTime", godStateTime));
                    stageE.Add(new XAttribute("initCradit", initCradit));
                    stageE.Add(new XAttribute("atkCraditPet", atkCraditPet));
                    stageE.Add(new XAttribute("bekillCraditPet", bekillCraditPet));
                    stageE.Add(new XAttribute("killCraditPet", killCraditPet));
                    stageE.Add(new XAttribute("otherUserCol", otherUserCol));
                    

                    PvpStageConfig c  =new PvpStageConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.DescMessageId = descMessageId;
                    c.StageMapResource = stageMapResource;
                    c.IconPic = icon;
                    c.EndLimitId = endLimitId;
                    c.EndFuncId = endFuncId;
                    c.ModeId = modeId;
                    c.ShowDropItemIdList = dropIdList;
                    c.StarBit4CountId = starbyteCounterId;
                    c.WeatherPlanId = weatherPlanId;
                    c.GodStatusTime = godStateTime;
                    c.InitCradit = initCradit;
                    c.AtkCraditPet = atkCraditPet;
                    c.KillCraditPet = killCraditPet;
                    c.BekillCraditPet = bekillCraditPet;
                    c.OtherPlayerCol = otherUserCol;
                    c.KillPet = killPet;
                    c.BirthBuff = birthBuff;
                    config.StageConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.PVP_STAGE_CONFIG;
        }
    }
}
