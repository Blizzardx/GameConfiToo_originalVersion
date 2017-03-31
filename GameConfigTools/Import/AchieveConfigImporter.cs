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
    public class AchieveConfigImporter : AbstractExcelImporter
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

            AchieveConfigTable config = new AchieveConfigTable();
            tbase = config;
            config.AchieveConfigMap = new Dictionary<int, AchieveConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，名称ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int type;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out type, 1, 5))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，成就类型必须为1 - 5整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int sceneId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sceneId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，sceneId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int forwardId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out forwardId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，forwardId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string icon = values[i][index++];
                    int showLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out showLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，showLimitId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int sceneLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sceneLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，sceneLimitId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int sceneFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sceneFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，sceneFuncId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int completeLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out completeLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，completeLimitId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int honor;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out honor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，荣誉值必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int order;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out order))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，排序值必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string color = values[i][index++];
                    if (!VaildUtil.VaildColor(color))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，颜色不合法", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    string resource = values[i][index++];

                    List<string> list = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        list.Add(values[i][j]);
                    }
                    List<List<string>> resultList = this.ParseBracket(list);
                    //if (resultList == null || resultList.Count < 1)
                    //{
                    //    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，Id:{3} level:{4}没有配置属性", this.GetConfigName(), sheetName, row, weaponId, star);
                    //    return;
                    //}
                    List<string> attrList = new List<string>();
                    if (resultList != null && resultList.Count > 0)
                    {
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
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，Id:{3} 属性配置不合法", this.GetConfigName(), sheetName, row, id);
                            return;
                        }
                    }

                    XElement achieveE = new XElement("achieve");
                    root.Add(achieveE);
                    achieveE.Add(new XAttribute("id", id));
                    achieveE.Add(new XAttribute("name", name));
                    achieveE.Add(new XAttribute("type", type));
                    achieveE.Add(new XAttribute("sceneId", sceneId));
                    achieveE.Add(new XAttribute("sceneLimitId", sceneLimitId));
                    achieveE.Add(new XAttribute("sceneFuncId", sceneFuncId));
                    achieveE.Add(new XAttribute("completeLimitId", completeLimitId));
                    achieveE.Add(new XAttribute("honor", honor));

                    AchieveConfig c = new AchieveConfig();
                    c.Id = id;
                    c.NameMessageId = nameMessageId;
                    c.DescMessageId = descMessageId;
                    c.Type = type;
                    c.ForwardId = forwardId;
                    c.Icon = icon;
                    c.ShowLimitId = showLimitId;
                    c.Honor = honor;
                    c.Order = order;
                    c.Color = color;
                    c.Resource = resource;
                    config.AchieveConfigMap.Add(id, c);

                    c.AttrMap = new Dictionary<int, int>();
                    for (int j = 0; j < attrList.Count(); j++)
                    {
                        int attrId = 0;
                        int value = 0;
                        if ((j & 1) == 0)
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
                            achieveE.Add(attributeE);
                        }
                    }

                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.ACHIEVE_CONFIG;
        }
    }
}
