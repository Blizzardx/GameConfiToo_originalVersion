using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;

namespace GameConfigTools.Export
{
    public class ExporterManager
    {
        public static readonly ExporterManager instance = new ExporterManager();

        private Dictionary<string, Exporter> exporterDic = new Dictionary<string, Exporter>();

        public ExporterManager()
        {
            exporterDic.Add(SysConstant.MESSAGE_CONFIG, new MessageExporter());
           // exporterDic.Add(SysConstant.CHAT_DIRTY_WORD_CONFIG, new ChatDirtyWordExporter());
           // exporterDic.Add(SysConstant.NAME_DIRTY_WORD_CONFIG, new NameDirtyWordExporter());
           // exporterDic.Add(SysConstant.COUNTER_CONFIG, new CounterExporter());
            //exporterDic.Add(SysConstant.LIMIT_FUNC_SCENE_CONFIG, new LimitFuncSceneExporter());
            exporterDic.Add(SysConstant.SYSTEM_CONFIG, new ServerSystemExporter());
        }

        public Exporter GetExporter(string configName)
        {
            if (!exporterDic.ContainsKey(configName))
            {
                return null;
            }
            return exporterDic[configName];
        }
    }
}
