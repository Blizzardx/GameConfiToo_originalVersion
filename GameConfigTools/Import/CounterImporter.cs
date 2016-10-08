using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;
using GameConfigTools.Util;

namespace GameConfigTools.Import
{
    public class CounterImporter : AbstractXmlImporter
    {

        protected override bool Valid(XElement root, out TBase tbase, ref string errMsg)
        {
            CounterConfigTable config = new CounterConfigTable();
            tbase = config;
            config.CycleCounterConfigMap = new Dictionary<int, CycleCounterConfig>();
            
            if (!ValidCycleCounterConfig(root, config.CycleCounterConfigMap, ref errMsg))
            {
                return false;
            }
            return true;
        }

        private bool ValidCycleCounterConfig(XElement root, Dictionary<int, CycleCounterConfig> config, ref string errMsg)
        {
            root = root.Element("cycleCountersConfig").Element("playerCounters");

            var tmpList = root.Elements("cycleCounter");
            foreach (var elem in tmpList)
            {
                CycleCounterConfig elemInfo = new CycleCounterConfig();
                int id = 0;
                int cycleTime = 0;
                short max = 0;
                DateTime? baseDate = null;
                if (!int.TryParse(elem.Attribute("id").Value, out id))
                {
                    errMsg = "<id> 必须为整数";
                    return false;
                }
                elemInfo.Id = id;
                if (!int.TryParse(elem.Attribute("cycleTime").Value, out cycleTime))
                {
                    errMsg = "<cycleTime> 必须为整数";
                    return false;
                }
                elemInfo.CycleTime = cycleTime;
                if (!short.TryParse(elem.Attribute("max").Value, out max))
                {
                    errMsg = "<max> 必须为short";
                    return false;
                }
                elemInfo.Max = max;
                if (config.ContainsKey(id))
                {
                    errMsg = "<id> 重复 "+id;
                    return false;
                }
                if (!VaildUtil.VaildDateTime(elem.Attribute("baseDate").Value, false, out baseDate))
                {
                    errMsg = "<baseDate> 不合法";
                    return false;
                }
                elemInfo.BaseDate =
                    Convert.ToInt64((baseDate - new DateTime(1970, 1, 1, 0, 0, 0, 0)).Value.TotalMilliseconds);
                config.Add(id, elemInfo);
            }
            return true;
        }

        protected override string GetConfigName()
        {
            return SysConstant.COUNTER_CONFIG;
        }
    }
}
