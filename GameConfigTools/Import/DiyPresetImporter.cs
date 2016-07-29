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
    public class DiyPresetImporter : AbstractExcelImporter
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

            DiyPresetConfigTable config = new DiyPresetConfigTable();
            tbase = config;
            config.DiyPreseConfigMap = new Dictionary<int, DiyPresetConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，预设ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    //备注
                    index++;

                    int gender;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out gender, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，性别必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    //名称
                    index++;
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，名称必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int faceItemId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out faceItemId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，脸模ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int faceParam1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out faceParam1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，脸型长必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int faceParam2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out faceParam2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，脸型宽必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int faceParam3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out faceParam3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，脸型前后必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int noseParam1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out noseParam1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，鼻型大小必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int noseParam2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out noseParam2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，鼻型上下必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int noseParam3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out noseParam3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，鼻型高低必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int eyeParam1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eyeParam1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眼型大小必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int eyeParam2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eyeParam2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眼型上下必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int eyeParam3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eyeParam3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眼型远近必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int eyeParam4;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eyeParam4))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眼型内外必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int mouthParam1;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out mouthParam1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，嘴巴大小必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int mouthParam2;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out mouthParam2))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，嘴巴上下必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int mouthParam3;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out mouthParam3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，嘴巴高低必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int skinItemId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out skinItemId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，皮肤ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string skinColor = values[i][index++];
                    if (!VaildUtil.VaildColor(skinColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，皮肤颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int lensesId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out lensesId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，美瞳ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string lensesColor = values[i][index++];
                    if (!VaildUtil.VaildColor(lensesColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，美瞳颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int eyebrowId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eyebrowId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眉毛ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string eyebrowColor = values[i][index++];
                    if (!VaildUtil.VaildColor(eyebrowColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眉毛颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int eyeShadowId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eyeShadowId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眼影ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string eyeShadowColor = values[i][index++];
                    if (!VaildUtil.VaildColor(eyeShadowColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，眼影颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int lipGlossId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out lipGlossId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，唇彩ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string lipGlossColor = values[i][index++];
                    if (!VaildUtil.VaildColor(lipGlossColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，唇彩颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int beardId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out beardId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，胡子ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string beardColor = values[i][index++];
                    if (!VaildUtil.VaildColor(beardColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，胡子颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int blusherId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out blusherId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，腮红ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string blusherColor = values[i][index++];
                    if (!VaildUtil.VaildColor(blusherColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，腮红颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int paintingId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out paintingId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，彩绘ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string paintingColor = values[i][index++];
                    if (!VaildUtil.VaildColor(paintingColor))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，彩绘颜色必须为16进制值", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    XElement presetE = new XElement("preset");
                    root.Add(presetE);
                    presetE.Add(new XAttribute("id", id));
                    presetE.Add(new XAttribute("gender", gender));
                    presetE.Add(new XAttribute("faceItemId", faceItemId));
                    presetE.Add(new XAttribute("faceParam1", faceParam1));
                    presetE.Add(new XAttribute("faceParam2", faceParam2));
                    presetE.Add(new XAttribute("faceParam3", faceParam3));
                    presetE.Add(new XAttribute("noseParam1", noseParam1));
                    presetE.Add(new XAttribute("noseParam2", noseParam2));
                    presetE.Add(new XAttribute("noseParam3", noseParam3));
                    presetE.Add(new XAttribute("eyeParam1", eyeParam1));
                    presetE.Add(new XAttribute("eyeParam2", eyeParam2));
                    presetE.Add(new XAttribute("eyeParam3", eyeParam3));
                    presetE.Add(new XAttribute("eyeParam4", eyeParam4));
                    presetE.Add(new XAttribute("mouthParam1", mouthParam1));
                    presetE.Add(new XAttribute("mouthParam2", mouthParam2));
                    presetE.Add(new XAttribute("mouthParam3", mouthParam3));
                    presetE.Add(new XAttribute("skinItemId", skinItemId));
                    presetE.Add(new XAttribute("skinColor", skinColor == "" ? "" : "#" + skinColor));
                    presetE.Add(new XAttribute("lensesId", lensesId));
                    presetE.Add(new XAttribute("lensesColor", lensesColor == "" ? "" : "#" + lensesColor));
                    presetE.Add(new XAttribute("eyebrowId", eyebrowId));
                    presetE.Add(new XAttribute("eyebrowColor", eyebrowColor == "" ? "" : "#" + eyebrowColor));
                    presetE.Add(new XAttribute("eyeShadowId", eyeShadowId));
                    presetE.Add(new XAttribute("eyeShadowColor", eyeShadowColor == "" ? "" : "#" + eyeShadowColor));
                    presetE.Add(new XAttribute("lipGlossId", lipGlossId));
                    presetE.Add(new XAttribute("lipGlossColor", lipGlossColor == "" ? "" : "#" + lipGlossColor));
                    presetE.Add(new XAttribute("beardId", beardId));
                    presetE.Add(new XAttribute("beardColor", beardColor == "" ? "" : "#" + beardColor));
                    presetE.Add(new XAttribute("blusherId", blusherId));
                    presetE.Add(new XAttribute("blusherColor", blusherColor == "" ? "" : "#" + blusherColor));
                    presetE.Add(new XAttribute("paintingId", paintingId));
                    presetE.Add(new XAttribute("paintingColor", paintingColor == "" ? "" : "#" + paintingColor));

                    DiyPresetConfig c = new DiyPresetConfig();
                    c.Id = id;
                    c.Gender = gender;
                    c.NameMessageId = nameMessageId;
                    c.FaceItemId = faceItemId;
                    c.FaceParam1 = faceParam1;
                    c.FaceParam2 = faceParam2;
                    c.FaceParam3 = faceParam3;
                    c.NoseParam1 = noseParam1;
                    c.NoseParam2 = noseParam2;
                    c.NoseParam3 = noseParam3;
                    c.EyeParam1 = eyeParam1;
                    c.EyeParam2 = eyeParam2;
                    c.EyeParam3 = eyeParam3;
                    c.EyeParam4 = eyeParam4;
                    c.MouthParam1 = mouthParam1;
                    c.MouthParam2 = mouthParam2;
                    c.MouthParam3 = mouthParam3;
                    c.SkinItemId = skinItemId;
                    c.SkinColor = skinColor == "" ? "" : "#" + skinColor;
                    c.LensesId = lensesId;
                    c.LensesColor = lensesColor == "" ? "" : "#" + lensesColor;
                    c.EyebrowId = eyebrowId;
                    c.EyebrowColor = eyebrowColor == "" ? "" : "#" + eyebrowColor;
                    c.EyeShadowId = eyeShadowId;
                    c.EyeShadowColor = eyeShadowColor == "" ? "" : "#" + eyeShadowColor;
                    c.BeardId = beardId;
                    c.BeardColor = beardColor == "" ? "" : "#" + beardColor;
                    c.BlusherId = blusherId;
                    c.BlusherColor = blusherColor == "" ? "" : "#" + blusherColor;
                    c.PaintingId = paintingId;
                    c.PaintingColor = paintingColor == "" ? "" : "#" + paintingColor;

                    config.DiyPreseConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        { 
            return SysConstant.DIY_PRESET_CONFIG;
        }
    }
}
