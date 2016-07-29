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
    public class BattleSkillConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            BattleSkillConfigTable config = new BattleSkillConfigTable();
            tbase = config;
            config.BattleSkillConfigMap = new Dictionary<int, BattleSkillConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    if (config.BattleSkillConfigMap.ContainsKey(id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID重复", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能名字字典id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    index++;
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能描述字典id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string icon = values[i][index++];
                    int cdFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out cdFrame))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能cd必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int useLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out useLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，条件函数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int useFunId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out useFunId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，功能函数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    BattleSkillConfig c = new BattleSkillConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.DescMessageId = descMessageId;
                    c.Icon = icon;
                    c.CdFrame = cdFrame;
                    c.UseLimitId = useLimitId;
                    c.UseFunId = useFunId;
                    config.BattleSkillConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_SKILL_CONFIG;
        }
    }
}
