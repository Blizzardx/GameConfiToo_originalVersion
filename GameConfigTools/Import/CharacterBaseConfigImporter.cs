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
    public class CharacterBaseConfigImporter : AbstractExcelImporter
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

            CharacterBaseConfigTable config = new CharacterBaseConfigTable();
            tbase = config;
            config.CharacterBaseConfigMap = new Dictionary<int, Config.CharacterBaseConfig>();
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
                    if (config.CharacterBaseConfigMap.ContainsKey(id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID重复", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int gender;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out gender, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，性别必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    string modelBattle = values[i][index++];
                    string modelPrepare = values[i][index++];
                    int defaultAeroId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out defaultAeroId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，默认飞行器ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string headIcon = values[i][index++];
                    string bodyIcon = values[i][index++];

                    XElement characterBaseConfig = new XElement("characterBaseConfig");
                    root.Add(characterBaseConfig);

                    characterBaseConfig.Add(new XAttribute("id", id));
                    characterBaseConfig.Add(new XAttribute("gender", gender));
                    characterBaseConfig.Add(new XAttribute("defaultAeroId", defaultAeroId));

                    CharacterBaseConfig c = new CharacterBaseConfig();
                    c.Id = id;
                    c.Gender = gender;
                    c.ModelBattle = modelBattle;
                    c.ModelPrepare = modelPrepare;
                    c.DefaultAeroId = defaultAeroId;
                    c.HeadIcon = headIcon;
                    c.BodyIcon = bodyIcon;

                    config.CharacterBaseConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.CHARACTER_BASE_CONFIG;
        }
    }
}
