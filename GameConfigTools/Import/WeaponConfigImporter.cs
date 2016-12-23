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
    public class WeaponConfigImporter : AbstractExcelImporter
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

            WeaponConfigTable config = new WeaponConfigTable();
            tbase = config;
            config.WeaponConfigMap = new Dictionary<int, WeaponConfig>();


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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，武器ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int decomposeId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out decomposeId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，分解ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，名称ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，描述ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int firstType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out firstType, 1, 3))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，一级分类必须为1 - 3整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int secondType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out secondType, 1, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，二级分类必须为1 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string model = values[i][index++];
                    string prefab = values[i][index++];
                    string icon = values[i][index++];
                    int quality;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out quality))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，品质必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string attachPoint = values[i][index++];

                    XElement weapon = new XElement("weapon");
                    root.Add(weapon);
                    weapon.Add(new XAttribute("id", id));
                    weapon.Add(new XAttribute("name", name));
                    weapon.Add(new XAttribute("decomposeId", decomposeId));
                    weapon.Add(new XAttribute("firstType", firstType));
                    weapon.Add(new XAttribute("secondType", secondType));
                    weapon.Add(new XAttribute("quality", quality));

                    WeaponConfig c = new WeaponConfig();
                    c.Id = id;
                    c.DecomposeId = decomposeId;
                    c.NameMessageId = nameMessageId;
                    c.DescMessageId = descMessageId;
                    c.FirstType = firstType;
                    c.SecondType = secondType;
                    c.Model = model;
                    c.Prefab = prefab;
                    c.Icon = icon;
                    c.Quality = quality;
                    c.AttachPoint = attachPoint;
                    config.WeaponConfigMap.Add(id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.WEAPON_CONFIG;
        }
    }
}
