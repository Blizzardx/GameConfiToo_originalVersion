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
    public partial class SeasonAwardConfigImporter : AbstractExcelImporter
    {
        private XElement e;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = null;
        }

        protected override string GetConfigName()
        {
            return SysConstant.SEASON_AWARD_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            DateTime? beginDateTime;
            if (!VaildUtil.VaildDateTime(beginTime, out beginDateTime))
            {
                errMsg = string.Format("{0}.xlsx id:{1} 开始时间格式不合法", this.GetConfigName(), id);
                return;
            }
            DateTime? endDateTime;
            if (!VaildUtil.VaildDateTime(endTime, out endDateTime))
            {
                errMsg = string.Format("{0}.xlsx id:{1} 结束时间格式不合法", this.GetConfigName(), id);
                return;
            }
            XElement awardE = new XElement("award");
            e.Add(awardE);
            awardE.Add(new XAttribute("id", id));
            awardE.Add(new XAttribute("beginTime", beginDateTime.ToFormatString()));
            awardE.Add(new XAttribute("endTime", endDateTime.ToFormatString()));
            awardE.Add(new XAttribute("awardFuncId", awardFuncId));

        }

        protected override void OnAutoParasBegin()
        {
            e = new XElement("root");
        }
    }
}
