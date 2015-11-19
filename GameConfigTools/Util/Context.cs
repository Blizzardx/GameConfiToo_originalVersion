using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Model;

namespace GameConfigTools.Util
{
    /// <summary>
    /// 程序的上下文
    /// </summary>
    public class Context
    {
        public static readonly Context instance = new Context();

        private Dictionary<string, object> contextMap = new Dictionary<string, object>();

        public void Set(string key, object value)
        {
            if (contextMap.ContainsKey(key))
            {
                contextMap.Remove(key);
            }
            contextMap.Add(key, value);
        }

        public object Get(string key)
        {
            if (contextMap.ContainsKey(key))
            {
                return contextMap[key];
            }
            return null;
        }

        public void SetSysConfig(SysConfig config)
        {
            Set("_sysConfig", config);
        }

        public SysConfig GetSysConfig()
        {
           return Get("_sysConfig") as SysConfig;
        }

        public void SetGame(string game)
        {
            Set("_game", game);
        }
        public string GetGame()
        {
            return Get("_game") as string;
        }
        public void SetVersion(string version)
        {
            Set("_version", version);
        }
        public string GetVersion()
        {
            return Get("_version") as string;
        }
    }
}
