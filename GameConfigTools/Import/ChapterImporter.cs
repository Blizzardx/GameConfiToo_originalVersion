using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class ChapterImporter : AbstractExcelImporter
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

            ChapterConfigTable config = new ChapterConfigTable();
            tbase = config;
            config.ChapterConfigMap = new Dictionary<int, ChapterConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，章节ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int nextChapterId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nextChapterId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，下一章节ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int firstStageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out firstStageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，第一个关卡ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int award1LimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out award1LimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，第一个宝箱条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int award1FuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out award1FuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，第一个宝箱功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int flag1Id;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out flag1Id, 0, 1024))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，宝箱1是否领取的旗标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, 1024);
                        return;
                    }
                    int award2LimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out award2LimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，第二个宝箱条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int award2FuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out award2FuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，第二个宝箱功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int flag2Id;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out flag2Id, 0, 1024))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，宝箱2是否领取的旗标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, 1024);
                        return;
                    }
                    int award3LimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out award3LimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，第三个宝箱条件组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int award3FuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out award3FuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，第三个宝箱功能组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int flag3Id;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out flag3Id, 0, 1024))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，宝箱3是否领取的旗标ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, 1024);
                        return;
                    }

                    XElement chapterE = new XElement("chapter");
                    root.Add(chapterE);
                    chapterE.Add(new XAttribute("id", id));
                    chapterE.Add(new XAttribute("nextChapterId", nextChapterId));
                    chapterE.Add(new XAttribute("name", name));
                    chapterE.Add(new XAttribute("firstStageId", firstStageId));
                    chapterE.Add(new XAttribute("award1LimitId", award1LimitId));
                    chapterE.Add(new XAttribute("award1FuncId", award1FuncId));
                    chapterE.Add(new XAttribute("flag1Id", flag1Id));
                    chapterE.Add(new XAttribute("award2LimitId", award2LimitId));
                    chapterE.Add(new XAttribute("award2FuncId", award2FuncId));
                    chapterE.Add(new XAttribute("flag2Id", flag2Id));
                    chapterE.Add(new XAttribute("award3LimitId", award3LimitId));
                    chapterE.Add(new XAttribute("award3FuncId", award3FuncId));
                    chapterE.Add(new XAttribute("flag3Id", flag3Id));

                    ChapterConfig c = new ChapterConfig();
                    c.Id = id;
                    c.NextChapterId = nextChapterId;
                    c.FirstStageId = firstStageId;
                    c.Award1LimitId = award1LimitId;
                    c.Flag1Id = flag1Id;
                    c.Award1FuncId = award1FuncId;
                    c.Award2LimitId = award2LimitId;
                    c.Award2FuncId = award2FuncId;
                    c.Flag2Id = flag2Id;
                    c.Award3LimitId = award3LimitId;
                    c.Award3FuncId = award3FuncId;
                    c.Flag3Id = flag3Id;
                    config.ChapterConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.CHAPTER_CONFIG;
        }
    }
}
