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
    public partial class CharacterExpConfigImporter : AbstractExcelImporter
    {
        private XElement rootE;
        private CharacterExpConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = rootE;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.CHARACTER_EXP_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if(level != 1)
            {
                if (config.CharacterExpConfigMap.ContainsKey(level))
                {
                    errMsg = string.Format("{0}.xlsx �ȼ�{1}���ظ�", this.GetConfigName(), level);
                    return;
                }
                if(!config.CharacterExpConfigMap.ContainsKey(level - 1))
                {
                    errMsg = string.Format("{0}.xlsx �ȼ����ñ���Ҫ����", this.GetConfigName());
                    return;
                }
                CharacterExpConfig beforeConfig = config.CharacterExpConfigMap[level - 1];
                if(totalExp <= beforeConfig.TotalExp)
                {
                    errMsg = string.Format("{0}.xlsx ��ǰ�ȼ�{1}������ֵ����С����һ���ȼ��ľ���ֵ", this.GetConfigName(), level);
                    return;
                }
            }

            if(resultList == null || resultList.Count == 0)
            {
                errMsg = string.Format("{0}.xlsx ��ǰ�ȼ�{1}������ֵ����Ϊ��", this.GetConfigName(), level);
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
            if ((attrList.Count() & 1) == 1)
            {
                errMsg = string.Format("{0}.xlsx ��ǰ�ȼ�{1}������ֵ���Ϸ�", this.GetConfigName(), level);
                return;
            }

            CharacterExpConfig c = new CharacterExpConfig();
            c.Level = level;
            c.TotalExp = totalExp;
            c.LevelUpLimitId = levelUpLimitId;
            c.LevelUpFuncId = levelUpFuncId;
            config.CharacterExpConfigMap.Add(level, c);

            XElement levelConfigE = new XElement("level");
            rootE.Add(levelConfigE);

            levelConfigE.Add(new XAttribute("level", level));
            levelConfigE.Add(new XAttribute("totalExp", totalExp));
            levelConfigE.Add(new XAttribute("levelUpLimitId", levelUpLimitId));
            levelConfigE.Add(new XAttribute("levelUpFuncId", levelUpFuncId));

            XElement attributesE = new XElement("attributes");
            levelConfigE.Add(attributesE);

            c.AttrMap = new Dictionary<int, int>();
            for (int j = 0; j < attrList.Count(); j++)
            {
                int attrId = 0;
                int value = 0;
                if ((j & 1) == 0)
                {
                    if (!int.TryParse(attrList[j], out attrId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}��]��ȡ���ִ�������ID:[{3}]����Ϊ����", this.GetConfigName(), sheetName, row, attrList[j]);
                        return;
                    }
                    if (!int.TryParse(attrList[j + 1], out value))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}��]��ȡ���ִ�������ֵ:[{3}]����Ϊ����", this.GetConfigName(), sheetName, row, attrList[j + 1]);
                        return;
                    }
                    if (attrId == 0 || value == 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}��]��ȡ���ִ�������ID������ֵ����Ϊ0", this.GetConfigName(), sheetName, row);
                        return;
                    }

                    c.AttrMap.Add(attrId, value);

                    XElement attributeE = new XElement("attribute");
                    attributeE.Add(new XAttribute("id", attrId));
                    attributeE.Add(new XAttribute("value", value));
                    attributesE.Add(attributeE);
                }
            }

        }

        protected override void OnAutoParasBegin()
        {
            config = new CharacterExpConfigTable();
            config.CharacterExpConfigMap = new Dictionary<int, CharacterExpConfig>();

            rootE = new XElement("root");
        }
    }
}
