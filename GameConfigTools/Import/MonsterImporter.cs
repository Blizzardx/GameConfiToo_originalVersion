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
    public class MonsterImporter : AbstractExcelImporter
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

            MonsterConfigTable config = new MonsterConfigTable();
            tbase = config;
            config.MonsterConfigMap = new Dictionary<int, MonsterConfig>();

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

                    int TagMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out TagMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string headIcon = values[i][index++];
                    string dialogIcon = values[i][index++];
                    string model = values[i][index++];
                    string dataModle = values[i][index++];

                    int monsterType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out monsterType, 1, 3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，类型必须为1 - 3的整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int points;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out points))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，类型必须为整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int normalSkill;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out normalSkill))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，普通攻击必须为0 - {4}整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int bornLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out bornLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int bornFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out bornFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int deathLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out deathLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，死亡条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int deathFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out deathFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，死亡功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int level;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out level, 1, 200))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物等级必须为1 - 200之间的整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int hp;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out hp, 1, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物生命必须为1 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    // drop list
                    List<int> dropIdList = VaildUtil.SplitToList(values[i][index++]);
                    if (dropIdList == null)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，掉落列表配置不合法", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int isAliveInRiver;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isAliveInRiver, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int canResume;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canResume, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int resumeLast;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out resumeLast, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int resumeId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out resumeId, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int canDestroy;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canDestroy, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int aliveTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out aliveTime, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int InitActionGroupId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out InitActionGroupId, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int initaiId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out initaiId, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物AI ID必须为0 - {4}之间的整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    // ai list
                    List<MonsterAiParam> tmpAiParamList = new List<MonsterAiParam>();
                    if (!DecodeAiParamList(values[i],ref index,tmpAiParamList))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ai 列表解析出错", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    // skill list
                    List<int> skillList = new List<int>();
                    if (!DecodeList(values[i], ref index, skillList))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误， 解析技能列表出错", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    

                    XElement monsterE = new XElement("monster");
                    root.Add(monsterE);
                    monsterE.Add(new XAttribute("id", id));
                    monsterE.Add(new XAttribute("name", name));
                    monsterE.Add(new XAttribute("monsterType", monsterType));
                    //monsterE.Add(new XAttribute("sex", sex));
                    monsterE.Add(new XAttribute("bornLimitId", bornLimitId));
                    monsterE.Add(new XAttribute("bornFuncId", bornFuncId));
                    monsterE.Add(new XAttribute("deathLimitId", deathLimitId));
                    monsterE.Add(new XAttribute("deathFuncId", deathFuncId));
                    monsterE.Add(new XAttribute("level", level));
                    monsterE.Add(new XAttribute("hp", hp));
                    monsterE.Add(new XAttribute("resumeId", resumeId));
                    monsterE.Add(new XAttribute("aliveTime", aliveTime));
                    monsterE.Add(new XAttribute("canDestroy", canDestroy));
                    monsterE.Add(new XAttribute("resumeLast", resumeLast));
                    monsterE.Add(new XAttribute("isAliveInRiver", isAliveInRiver));
                    monsterE.Add(new XAttribute("points", points));
                    monsterE.Add(new XAttribute("dataPrefab", dataModle));

                    XElement skillIdsE = new XElement("skillIds");
                    monsterE.Add(skillIdsE);
                    foreach (var elem in skillList)
                    {
                        skillIdsE.Add(new XElement("skillId", elem));
                    }

                    if (dropIdList.Count > 0)
                    {
                        XElement dropIdsE = new XElement("dropIds");
                        monsterE.Add(dropIdsE);
                        foreach (int dropId in dropIdList)
                        {
                            dropIdsE.Add(new XElement("dropId", dropId));
                        }
                    }


                    MonsterConfig c = new MonsterConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.TagMessageId = TagMessageId;
                    c.HeadIcon = headIcon;
                    c.DialogIcon = dialogIcon;
                    c.Model = model;
                    //c.Sex = (sbyte)sex;
                    c.NormalSkill = normalSkill;
                    c.BornLimitId = bornLimitId;
                    c.BornFuncId = bornFuncId;
                    c.DeadLimitId = deathLimitId;
                    c.DeadFuncId = deathFuncId;
                    c.Level = (short)level;
                    c.Hp = hp;
                    c.SkillIdList = skillList;
                    c.InitAiId = initaiId;
                    c.AiChangeList = tmpAiParamList;
                    c.ResumeId = resumeId;
                    c.InitActionGroupId = InitActionGroupId;
                    c.Alivetime = aliveTime;
                    c.CanDestroy = canDestroy != 0;
                    c.DropList = dropIdList;
                    c.IsAliveInRiver = isAliveInRiver != 0;
                    c.ResumeLast = resumeLast;
                    c.Points = points;
                    c.DataPrefab = dataModle;

                    config.MonsterConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.MONSTER_CONFIG;
        }

        private bool DecodeList(string[] content, ref int index, List<int> targetList)
        {
            if (content[index++] != "(")
            {
                return false;
            }
            bool isDone = false;
            for (; index < content.Length; ++index)
            {
                string s = content[index];

                if (s == ")")
                {
                    ++index;
                    isDone = true;
                    break;
                }
                else
                {
                    int tmp = 0;
                    if (!int.TryParse(s, out tmp))
                    {
                        break;
                    }
                    targetList.Add(tmp);
                }
            }
            if (!isDone)
            {
                return false;
            }
            return true;
        }

        private bool DecodeList(string content, List<int> targetList)
        {
            string tmp = string.Empty;
            for (int i = 0; i < content.Length; ++i)
            {
                char c = content[i];
                if (c == '|')
                {
                    int tmpi;
                    if (!int.TryParse(tmp, out tmpi))
                    {
                        return false;
                    }
                    targetList.Add(tmpi);
                    continue;
                }
                tmp += c;
            }
            return true;
        }

        private bool DecodeAiParamList(string[] content, ref int index, List<MonsterAiParam> targetList)
        {
            if (content[index++] != "(")
            {
                return false;
            }
            bool isDone = false;
            for (; index < content.Length; ++index)
            {
                string s = content[index];
                if (s == ",")
                {
                    continue;
                }
                if (s == ")")
                {
                    ++ index;
                    isDone = true;
                    break;
                }
                else
                {
                    try
                    {
                        MonsterAiParam param = new MonsterAiParam();
                        int tmp;
                        if (!int.TryParse(content[index], out tmp))
                        {
                            break;
                        }
                        param.LimitId = tmp;
                        if (!int.TryParse(content[index + 1], out tmp))
                        {
                            break;
                        }
                        param.AiId = tmp;
                        if (!int.TryParse(content[index + 2], out tmp))
                        {
                            break;
                        }
                        param.ActionGroupId = tmp;
                        targetList.Add(param);
                        index += 2;
                    }
                    catch (Exception)
                    {
                        isDone = false;
                        break;
                    }
                }
            }
            if (!isDone)
            {
                return false;
            }
            return true;
        }
        private bool CheckIndex(string[] content, int index)
        {
            if (index < 0 || index >= content.Length)
            {
                return false;
            }
            return true;
        }
    }
}
