using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Model;
using GameConfigTools.Util;
using System.IO;

namespace GameConfigTools.Export
{
    public abstract class AbstractXmlExporter : Exporter
    {
        public string GetExportType()
        {
            return "xml";
        }

        public bool Export(string xml)
        {
            SysConfig config = Context.instance.GetSysConfig();

            string path = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion();
            string xmlName = this.GetConfigName() + ".xml";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream fs = new FileStream(path + @"\" + xmlName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(xml);
                }
            }

            return true;
        }

        protected abstract string GetConfigName();
    }
}
