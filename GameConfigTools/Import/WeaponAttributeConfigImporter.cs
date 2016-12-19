using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class WeaponAttributeConfigImporter : AbstractExcelImporter
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

            WeaponAttributeConfigTable config = new WeaponAttributeConfigTable();
            tbase = config;
            config.WeaponAttributeConfigMap = new Dictionary<int, Dictionary<int, WeaponAttributeConfig>>();

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

                    int weaponId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out weaponId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，武器ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int level;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out level))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，武器等级必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int normalSkill;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out normalSkill))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，普通攻击技能必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
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

                    if (!config.WeaponAttributeConfigMap.ContainsKey(weaponId))
                    {
                        config.WeaponAttributeConfigMap.Add(weaponId, new Dictionary<int, WeaponAttributeConfig>());
                    }
                    Dictionary<int, WeaponAttributeConfig> dic = config.WeaponAttributeConfigMap[weaponId];
                    if (dic.ContainsKey(level))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，Id:{3} level:{4}配置重复", this.GetConfigName(), sheetName, row, weaponId, level);
                        return;
                    }

                    List<string> list = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        list.Add(values[i][j]);
                    }
                    List<List<string>> resultList = this.ParseBracket(list);
                    if (resultList == null || resultList.Count < 1)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，Id:{3} level:{4}没有配置属性", this.GetConfigName(), sheetName, row, weaponId, level);
                        return;
                    }
                    List<string> attrList = new List<string>();

                    foreach (string str in resultList[0])
                    {
                        if (str == null || str.Trim() == "")
                        {
                            continue;
                        }
                        attrList.Add(str);
                    }
                    if((attrList.Count() & 1) == 1)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，Id:{3} level:{4}属性配置不合法", this.GetConfigName(), sheetName, row, weaponId, level);
                        return;
                    }

                    XElement weaponAttributeE = new XElement("weaponAttribute");
                    root.Add(weaponAttributeE);
                    weaponAttributeE.Add(new XAttribute("weaponId", weaponId));
                    weaponAttributeE.Add(new XAttribute("level", level));
                    weaponAttributeE.Add(new XAttribute("normalSkill", normalSkill));
                    weaponAttributeE.Add(new XAttribute("skill1", skill1));
                    weaponAttributeE.Add(new XAttribute("skill2", skill2));
                    XElement passiveSkillsE = new XElement("passiveSkills");
                    weaponAttributeE.Add(passiveSkillsE);

                    XElement attributesE = new XElement("attributes");
                    weaponAttributeE.Add(attributesE);


                    WeaponAttributeConfig c = new WeaponAttributeConfig();
                    c.WeaponId = weaponId;
                    c.Level = level;
                    c.NormalSkill = normalSkill;
                    c.Skill1 = skill1;
                    c.Skill2 = skill2;
                    c.PassiveSkillList = new List<int>();
                    if(passiveSkill1 > 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill1);
                        XElement skillE = new XElement("passiveSkill", passiveSkill1);
                        passiveSkillsE.Add(skillE);
                    }
                    if (passiveSkill2 > 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill2);
                        XElement skillE = new XElement("passiveSkill", passiveSkill2);
                        passiveSkillsE.Add(skillE);
                    }
                    if (passiveSkill3 > 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill3);
                        XElement skillE = new XElement("passiveSkill", passiveSkill3);
                        passiveSkillsE.Add(skillE);
                    }
                    if (passiveSkill4 > 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill4);
                        XElement skillE = new XElement("passiveSkill", passiveSkill4);
                        passiveSkillsE.Add(skillE);
                    }
                    if (passiveSkill5 > 0)
                    {
                        c.PassiveSkillList.Add(passiveSkill5);
                        XElement skillE = new XElement("passiveSkill", passiveSkill5);
                        passiveSkillsE.Add(skillE);
                    }
                    c.AttrMap = new Dictionary<int, int>();
                    for(int j = 0; j < attrList.Count(); j++)
                    {
                        int attrId = 0;
                        int value = 0;
                        if((j & 1) == 0)
                        {
                            if (!int.TryParse(attrList[j], out attrId))
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，属性ID:[{3}]必须为整型", this.GetConfigName(), sheetName, row, attrList[j]);
                                return;
                            }
                            if (!int.TryParse(attrList[j + 1], out value))
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，属性值:[{3}]必须为整型", this.GetConfigName(), sheetName, row, attrList[j + 1]);
                                return;
                            }
                            if (attrId == 0 || value == 0)
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，属性ID或属性值不能为0", this.GetConfigName(), sheetName, row);
                                return;
                            }

                            c.AttrMap.Add(attrId, value);

                            XElement attributeE = new XElement("attribute");
                            attributeE.Add(new XAttribute("id", attrId));
                            attributeE.Add(new XAttribute("value", value));
                            attributesE.Add(attributeE);
                        }
                    }
                    dic.Add(c.Level, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.WEAPON_ATTRIBUTE_CONFIG;
        }
    }
}
