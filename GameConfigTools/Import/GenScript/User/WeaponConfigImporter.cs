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
    public partial class WeaponConfigImporter : AbstractExcelImporter
    {
        private XElement m_ServerConfig;
        private WeaponConfigTable m_ClientConfig;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = m_ServerConfig;
            tbase = m_ClientConfig;
        }

        protected override string GetConfigName()
        {
            return SysConstant.WEAPON_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if (m_ClientConfig.WeaponConfigMap.ContainsKey(id))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，id 重复", this.GetConfigName(), sheetName, row);
                return;
            }

            XElement weapon = new XElement("weapon");
            m_ServerConfig.Add(weapon);
            weapon.Add(new XAttribute("id", id));
            weapon.Add(new XAttribute("name", name));
            weapon.Add(new XAttribute("decomposeId", decomposeId));
            weapon.Add(new XAttribute("firstType", firstType));
            weapon.Add(new XAttribute("secondType", secondType));
            weapon.Add(new XAttribute("quality", quality));
            weapon.Add(new XAttribute("activeConsumeId", activeConsumeId));
            weapon.Add(new XAttribute("sortId", sortId));
            weapon.Add(new XAttribute("showLimitId", showLimitId));
            weapon.Add(new XAttribute("showTipType", showTipType));
            weapon.Add(new XAttribute("showEventType", showEventType));
            weapon.Add(new XAttribute("activeEnterType", activeEnterType));
            weapon.Add(new XAttribute("activeIconTip", activeIconTip));
            weapon.Add(new XAttribute("activeTipType", activeTipType));
            XElement motions = new XElement("mothions");
            weapon.Add(motions);
            foreach (var elem in motionList)
            {
                motions.Add(new XElement("motion", elem));
            }

            XElement textures = new XElement("textures");
            weapon.Add(textures);
            foreach (var elem in textureList)
            {
                textures.Add(new XElement("texture", elem));
            }

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
            c.ActiveCostId = activeConsumeId;
            c.SortId = sortId;
            c.ShowLimitId = showLimitId;
            c.ShowTipType = showTipType;
            c.ShowEventType = showEventType;
            c.ActiveEnterType = activeEnterType;
            c.ActiveIconTip = activeIconTip;
            c.ActiveTipType = activeTipType;
            c.MotionList = motionList;
            c.TextureList = textureList;
            m_ClientConfig.WeaponConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            m_ServerConfig = new XElement("root");

            m_ClientConfig = new WeaponConfigTable();
            m_ClientConfig.WeaponConfigMap = new Dictionary<int, WeaponConfig>();
        }
    }
}
