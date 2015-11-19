using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.Import
{
    public interface Importer
    {
        bool Import(ref string errMsg);

        string GetExportType();
    }
}
