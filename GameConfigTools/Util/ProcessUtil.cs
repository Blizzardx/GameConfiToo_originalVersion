using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GameConfigTools.Util
{
    public class ProcessUtil
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProcessUtil));
        public static void KillProcess(string processName)
        {
            try
            {
                Process[] procs = Process.GetProcessesByName(processName);
                foreach (Process p in procs)
                {
                    if (!p.CloseMainWindow())
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("kill process:" + processName + " fail.", e);
            }
        }
    }
}
