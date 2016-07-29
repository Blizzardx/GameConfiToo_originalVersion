using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Microsoft.Office.Interop.Excel;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class SpellCardLevelupConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            SpellCardConfigTable messageConfig = ImporterManager.instance.GetCacheConfig(SysConstant.SPELLCARD_CONFIG, ref errMsg) as SpellCardConfigTable;

            if (messageConfig == null)
            {
                return;
            }
            root = new XElement("root");

            SpellCardLevelupConfigTable config = new SpellCardLevelupConfigTable();
            tbase = config;
            config.SpellcardLevelupConfigMap = new Dictionary<int, List<SpellCardLevelupConfig>>();

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
                    int level;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out level))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int quality;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quality))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int disattachFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out disattachFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int attachFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out attachFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int levelupLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out levelupLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int levelupFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out levelupFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    XElement spellcardLevelup = new XElement("spellcardLevelup");
                    root.Add(spellcardLevelup);
                    spellcardLevelup.Add(new XAttribute("id", id));
                    spellcardLevelup.Add(new XAttribute("level", level));
                    spellcardLevelup.Add(new XAttribute("disattachFuncId", disattachFuncId));
                    spellcardLevelup.Add(new XAttribute("attachFuncId", attachFuncId));
                    spellcardLevelup.Add(new XAttribute("levelupLimitId", levelupLimitId));
                    spellcardLevelup.Add(new XAttribute("levelupFuncId", levelupFuncId));

                    SpellCardLevelupConfig c = new SpellCardLevelupConfig();
                    c.Id = id;
                    c.Level = level;
                    c.Quality = quality;
                    c.DisAttachFuncId = disattachFuncId;
                    c.AttachFuncId = attachFuncId;
                    c.LevelupLimitId = levelupLimitId;
                    c.LevelupFuncId = levelupFuncId;

                    if (!messageConfig.SpellCardConfigMap.ContainsKey(c.Id))
                    {
                        errMsg = "技能卡id在技能卡表中不存在 "+id;
                        return;
                    }
                    if (config.SpellcardLevelupConfigMap.ContainsKey(id))
                    {
                        var list = config.SpellcardLevelupConfigMap[id ];
                        foreach (var elem in list)
                        {
                            if (elem.Level == c.Level)
                            {
                                errMsg = "相同技能卡id下，等级重复 " + id + " level " + c.Level;
                                return;
                            }
                        }
                        config.SpellcardLevelupConfigMap[id].Add(c);
                    }
                    else
                    {
                        config.SpellcardLevelupConfigMap.Add(id,new List<SpellCardLevelupConfig>() {c});
                    }
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.SPELLCARD_LEVELUP_CONFIG;
        }
    }
}
