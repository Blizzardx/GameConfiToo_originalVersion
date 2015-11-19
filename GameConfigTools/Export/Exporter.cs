using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.Export
{
    public interface Exporter
    {
        /// <summary>
        /// 将配置文件导出成本地excel
        /// </summary>
        /// <param name="game"></param>
        /// <param name="version"></param>
        /// <param name="configName"></param>
        /// <param name="xml"></param>
        bool Export(string xml);

        string GetExportType();
    }
}
