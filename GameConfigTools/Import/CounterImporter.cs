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
            tbase = null;
            CounterConfigTable config = new CounterConfigTable();
            config.OrdinaryCounterConfigMap = new Dictionary<sbyte, OrdinaryCounterConfig>();

            XElement ordinaryCountersConfigE = root.Element("ordinaryCountersConfig");
            XElement playerCountersE = ordinaryCountersConfigE.Element("playerCounters");
            var ordinaryCounterEList = playerCountersE.Elements("ordinaryCounter");
            foreach (var ordinaryCounterE in ordinaryCounterEList)
            {
                int type;
                if (!VaildUtil.TryConvertInt(ordinaryCounterE.Attribute("type").Value, out type, 0, 3))
                {
                    errMsg = "计数器类型必须是0 - 3之间的整数";
                    return false;
                }
                int max;
                if (!VaildUtil.TryConvertInt(ordinaryCounterE.Attribute("type").Value, out max, 1, short.MaxValue))
                {
                    errMsg = string.Format("计数器类型必须是0 - {0}之间的整数", short.MaxValue);
                    return false;
                }

                OrdinaryCounterConfig c = new OrdinaryCounterConfig();
                c.Type = (sbyte)type;
                c.Max = (short)max;

            }

            return base.Valid(root, out tbase, ref errMsg);
        }
        protected override string GetConfigName()
        {
            return SysConstant.COUNTER_CONFIG;
        }
    }
}
