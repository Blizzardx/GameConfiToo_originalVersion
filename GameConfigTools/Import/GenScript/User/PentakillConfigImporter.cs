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
    public partial class PentakillConfigImporter : AbstractExcelImporter
    {
        private PentaKillConfigTable m_Config;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = m_Config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.PENTAKILL_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            PentakillConfig config = new PentakillConfig();
            config.KillCount = killCount;
            config.KillAddition = killAddition;
            config.KillEffect = killEffect;
            config.BekilledAddition = bekilledAddition;
            config.BekilledRadio = bekilledRadio;

            if (m_Config.PentakillConfigMap.ContainsKey(config.KillCount))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，killcout 重复", this.GetConfigName(), sheetName, row);
                return;
            }
            m_Config.PentakillConfigMap.Add(killCount, config);
        }

        protected override void OnAutoParasBegin()
        {
            m_Config = new PentaKillConfigTable();
            m_Config.PentakillConfigMap = new Dictionary<int, PentakillConfig>();
        }
    }
}
