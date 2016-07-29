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
    public class DialogImporter : AbstractExcelImporter
    {

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out System.Xml.Linq.XElement root, out Thrift.Protocol.TBase tbase)
        {

            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            DialogConfigTable config = new DialogConfigTable();
            tbase = config;
            config.DialogConfigMap = new Dictionary<int, DialogConfig>();

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


                    int npcId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out npcId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话 NPC ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int messageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out messageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话的消息ID 必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    DialogConfig c = new DialogConfig();
                    c.Id = id;
                    c.NpcId = npcId;
                    c.MessageId = messageId;
                    config.DialogConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.DIALOG_CONFIG;
        }
    }
}
