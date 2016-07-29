using System.Collections.Generic;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;

namespace GameConfigTools.Import
{
    public class AeroConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out System.Xml.Linq.XElement root, out Thrift.Protocol.TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            AeroConfigTable config = new AeroConfigTable();
            tbase = config;
            config.AeroConfigMap = new Dictionary<int, AeroConfig>();
            root = new XElement("root");

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string name = values[i][index++];

                    int nameMsgId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMsgId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int descMsgId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMsgId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string modle = values[i][index++];
                    string prefab = values[i][index++];
                    string icon = values[i][index++];

                    int moveAdd;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out moveAdd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int flyAdd;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out flyAdd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int moveMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out moveMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int flyMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out flyMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int dropAdd;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out dropAdd))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int dropMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out dropMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int friction;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out friction))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int resistance;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out resistance))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int recoverId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out recoverId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int recoverHp;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out recoverHp))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    XElement chapterE = new XElement("aero");
                    root.Add(chapterE);
                    chapterE.Add(new XAttribute("id", id));
                    chapterE.Add(new XAttribute("name", name));

                    AeroConfig c  = new AeroConfig();
                    c.Id = id;
                    c.NameMessageId = nameMsgId;
                    c.DescMessageId = descMsgId;
                    c.Model = modle;
                    c.Prefab = prefab;
                    c.Icon = icon;
                    c.MoveAdd = moveAdd;
                    c.FlyAdd = flyAdd;
                    c.MoveMax = moveMax;
                    c.FlyMax = flyMax;
                    c.DropAdd = dropAdd;
                    c.DropMax = dropMax;
                    c.Friction = friction;
                    c.ResistanceAdd = resistance;
                    c.RecoverHp = recoverHp;
                    c.RecoverId = recoverId;
                    config.AeroConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.AERO_CONFIG;
        }
    }
}
