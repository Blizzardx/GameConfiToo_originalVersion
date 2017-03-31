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
    public partial class BattleColorConfigImporter : AbstractExcelImporter
    {
        private XElement e;
        private BattleColorConfigTable m_Config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = m_Config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_COLOR_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if (!VaildUtil.IsColor(color1))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，颜色1配置不合法", this.GetConfigName(), sheetName, row);
                return;
            }
            if (!VaildUtil.IsColor(color2))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，颜色2配置不合法", this.GetConfigName(), sheetName, row);
                return;
            }
            if (!VaildUtil.IsColor(effectcolor1))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，颜色2配置不合法", this.GetConfigName(), sheetName, row);
                return;
            }
            if (!VaildUtil.IsColor(effectcolor2))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，颜色2配置不合法", this.GetConfigName(), sheetName, row);
                return;
            }

            XElement battleColorE = new XElement("battleColor");
            e.Add(battleColorE);
            battleColorE.Add(new XAttribute("id", id));
            battleColorE.Add(new XAttribute("color1", "#" + color1));
            battleColorE.Add(new XAttribute("color2", "#" + color2));

            BattleColorConfig c = new BattleColorConfig();
            c.Id = id;
            c.BattleColor1 = color1;
            c.BattleColor2 = color2;
            c.EffectColor1 = effectcolor1;
            c.EffectColor2 = effectcolor2;
            if (m_Config.BattleColorConfigMap.ContainsKey(id))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，id重复", this.GetConfigName(), sheetName, row);
                return;
            }
            m_Config.BattleColorConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            e = new XElement("root");
            m_Config = new BattleColorConfigTable();
            m_Config.BattleColorConfigMap = new Dictionary<int, BattleColorConfig>();
        }
    }
}
