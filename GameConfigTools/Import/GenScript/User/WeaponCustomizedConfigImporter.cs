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
    public partial class WeaponCustomizedConfigImporter : AbstractExcelImporter
    {
        private WeaponCustomizedConfigTable m_ClientConfig;
        private XElement m_ServerConfig;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = m_ServerConfig;
            tbase = m_ClientConfig;
        }

        protected override string GetConfigName()
        {
            return SysConstant.WEAPON_CUSTOMIZED_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            XElement weaponAttributeE = new XElement("weaponCustomized");
            m_ServerConfig.Add(weaponAttributeE);
            weaponAttributeE.Add(new XAttribute("id", id));
            weaponAttributeE.Add(new XAttribute("costId", costId));
            weaponAttributeE.Add(new XAttribute("name", name));

            WeaponCustomizedConfig c = new WeaponCustomizedConfig();
            c.Id = id;
            c.TextureName = textureName;
            c.CostId = costId;
            c.NameMessageId = nameMessageId;

            if (m_ClientConfig.WeaponMap.ContainsKey(id))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，id 重复", this.GetConfigName(), sheetName, row);
                return;
            }
            m_ClientConfig.WeaponMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            m_ServerConfig = new XElement("root");
            m_ClientConfig  = new WeaponCustomizedConfigTable();
            m_ClientConfig.WeaponMap = new Dictionary<int, WeaponCustomizedConfig>();
        }
    }
}
