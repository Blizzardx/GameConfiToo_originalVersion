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
    public class AeroAttributeConfigImporter : AbstractExcelImporter
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

            AeroAttributeConfigTable config = new AeroAttributeConfigTable();
            tbase = config;
            config.AeroConfigMap = new Dictionary<string, AeroAttributeConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，等级必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string key = id +"_" + level;
                    if (config.AeroConfigMap.ContainsKey(key))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，已存在ID:{4} level:{5}的记录", this.GetConfigName(), sheetName, row, index, id, level);
                        return;
                    }
                    int normalSkill;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out normalSkill))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，普通攻击必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int attk;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out attk))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，普通攻击必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int skill1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out skill1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能1必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int skill2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out skill2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能2必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int passiveSkill1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out passiveSkill1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，被动技能1必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int passiveSkill2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out passiveSkill2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，被动技能2必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int passiveSkill3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out passiveSkill3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，被动技能3必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int passiveSkill4;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out passiveSkill4))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，被动技能4必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int passiveSkill5;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out passiveSkill5))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，被动技能5必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maxHp;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxHp))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大血量必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maxMp;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxMp))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大能量必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int recoveryFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out recoveryFrame))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，恢复时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int recoverHp;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out recoverHp))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，恢复血量必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int moveAdd;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out moveAdd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，水平加速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int moveMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out moveMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，水平最大速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int flyAdd;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out flyAdd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，上升加速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int flyMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out flyMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，上升最大速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int dropAdd;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out dropAdd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，下降加速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int dropMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out dropMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，下降最大速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int resistAdd;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out resistAdd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，阻力减速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int friction;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out friction))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，摩擦减速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int defineMp;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out defineMp))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，摩擦减速度必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    XElement aeroAttrE = new XElement("aeroAttribute");
                    root.Add(aeroAttrE);
                    aeroAttrE.Add(new XAttribute("id", id));
                    aeroAttrE.Add(new XAttribute("level", level));

                    AeroAttributeConfig c = new AeroAttributeConfig();
                    c.Id = id;
                    c.Level = level;
                    c.NormalSkill = normalSkill;
                    c.Skill1 = skill1;
                    c.Skill2 = skill2;
                    c.PassiveSkillList = new List<int>();
                    if(passiveSkill1 != 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill1);
                    }
                    if (passiveSkill2 != 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill2);
                    }
                    if (passiveSkill3 != 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill3);
                    }
                    if (passiveSkill4 != 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill4);
                    }
                    if (passiveSkill5 != 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill5 );
                    }
                    c.MaxHp = maxHp;
                    c.MaxMp = maxMp;
                    c.RecoveryFrame = recoveryFrame;
                    c.RecoverHp = recoverHp;
                    c.MoveAdd = moveAdd;
                    c.MoveMax = moveMax;
                    c.FlyAdd = flyAdd;
                    c.FlyMax = flyMax;
                    c.DropAdd = dropAdd;
                    c.DropMax = dropMax;
                    c.ResistAdd = resistAdd;
                    c.RecoverHp = recoverHp;
                    c.DefineMap = defineMp;
                    c.Attk = attk;
                    config.AeroConfigMap.Add(key, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.AERO_ATTRIBUTE_CONFIG;
        }
    }
}
