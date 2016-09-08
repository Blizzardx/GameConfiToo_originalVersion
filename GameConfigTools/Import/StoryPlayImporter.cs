using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GameConfigTools.Constant;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class StoryPlayImporter:AbstractXmlImporter
    {
        protected override string GetConfigName()
        {
            return SysConstant.STORY_PLAY_CONFIG;
        }
    }
}
