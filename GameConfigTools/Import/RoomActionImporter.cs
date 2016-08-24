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
    public class RoomActionImporter : AbstractExcelImporter
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

            RoomActionConfigTable config = new RoomActionConfigTable();
            tbase = config;
            config.RoomActionConfigMap = new Dictionary<int, List<RoomActionConfig>>();

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

                    int itemId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out itemId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，道具ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int actionType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out actionType, 0, 2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，动作类型必须为0 - 2整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    string resource = values[i][index++];
                    int time;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out time))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，动作时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string attachment = values[i][index++];
                    string attachpoint = values[i][index++];
                    if((attachment.Trim() == "" && attachpoint.Trim() != "") || (attachment.Trim() != "" && attachpoint.Trim() == ""))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，特效和挂点必须匹配", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    

                    XElement actionE = new XElement("action");
                    root.Add(actionE);
                    actionE.Add(new XAttribute("itemId", itemId));
                    actionE.Add(new XAttribute("actionType", actionType));
                    actionE.Add(new XAttribute("time", time));

                    

                    RoomActionConfig c = new RoomActionConfig();
                    c.ItemId = itemId;
                    c.ActionType = actionType;
                    c.Resource = resource;
                    c.Time = time;
                    c.AttachMap = new Dictionary<string, string>();

                    if (attachment.Trim() != "")
                    {
                        string[] ss1 = attachment.Split(',');
                        string[] ss2 = attachpoint.Split(',');
                        if (ss1.Length != ss2.Length)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，特效和挂点必须匹配", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                            return;
                        }
                        for(int k = 0; k < ss1.Length; k++)
                        {
                            c.AttachMap.Add(ss1[k], ss2[k]);
                        }
                    }

                    if (!config.RoomActionConfigMap.ContainsKey(itemId))
                    {
                        config.RoomActionConfigMap.Add(itemId, new List<RoomActionConfig>());
                    }
                    List<RoomActionConfig> list = config.RoomActionConfigMap[itemId];
                    list.Add(c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.ROOM_ACTION_CONFIG;
        }
    }
}
