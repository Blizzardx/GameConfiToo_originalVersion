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
    public class MainMissionImporter : AbstractExcelImporter
    {

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out System.Xml.Linq.XElement root, out Thrift.Protocol.TBase tbase)
        {

            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            root = new XElement("root");
            
            MainMissionConfigTable config = new MainMissionConfigTable();
            tbase = config;
            config.MainMissionConfigMap = new Dictionary<int, MainMissionConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务 ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string name = values[i][index++];

                    int acceptLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out acceptLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务 接受任务条件ID类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务 名字消息ID类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string nameAudioId = values[i][index++];
                    if (string.IsNullOrEmpty(nameAudioId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务 名字声音文件不能为空", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    string desc = values[i][index++];


                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务描述ID类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string descAudioId = values[i][index++];
                    if (string.IsNullOrEmpty(descAudioId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务 描述声音文件不能为空", this.GetConfigName(), sheetName, row, index);
                        return;
                    }


                    int completeLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out completeLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，任务 下一个任务ID 必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int completeFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out completeFuncId, 0, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，完成功能函数ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    XElement buffE = new XElement("mission");
                    root.Add(buffE);

                    buffE.Add(new XAttribute("id", id));
                    buffE.Add(new XAttribute("name", name));
                    buffE.Add(new XAttribute("completeLimitId", completeLimitId));
                    buffE.Add(new XAttribute("completeFuncId", completeFuncId));

                    MainMissionConfig c = new MainMissionConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.NameAudioId = nameAudioId;
                    c.DesMessageId = descMessageId;
                    c.DesAudioId = descAudioId;
                    c.CompleteLimitId = completeLimitId;
                    c.CompleteFuncId = completeFuncId;
                    config.MainMissionConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.MAIN_MISSION_CONFIG;
        }
    }
}
