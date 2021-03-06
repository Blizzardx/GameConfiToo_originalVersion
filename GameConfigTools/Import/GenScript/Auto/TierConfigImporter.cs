/**
 * Autogenerated by script gen tool
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
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
    public partial class TierConfigImporter : AbstractExcelImporter
    {
		private int type;
		private string name;
		private string nameResource;
		private string bedgeResource;
		private int star;
		private int nextSeasonTierType;
		private int nextSeasonStar;
		private int nextMessageId;
    
        protected override void AutoParasTable(List<string[][]> sheetValues, ref string errMsg)
        {
            OnAutoParasBegin();

            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            
            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int row = i + 1;
                    int index = 0;

if (!VaildUtil.TryConvert(values[i][0], out type,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,0+1, type,int.MinValue,int.MaxValue,"int","type");
	return;
}
if (!VaildUtil.TryConvert(values[i][1], out name,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,1+1, name,string.Empty,string.Empty,"string","name");
	return;
}
if (!VaildUtil.TryConvert(values[i][2], out nameResource,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,2+1, nameResource,string.Empty,string.Empty,"string","nameResource");
	return;
}
if (!VaildUtil.TryConvert(values[i][3], out bedgeResource,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,3+1, bedgeResource,string.Empty,string.Empty,"string","bedgeResource");
	return;
}
if (!VaildUtil.TryConvert(values[i][4], out star,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,4+1, star,int.MinValue,int.MaxValue,"int","star");
	return;
}
if (!VaildUtil.TryConvert(values[i][5], out nextSeasonTierType,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,5+1, nextSeasonTierType,int.MinValue,int.MaxValue,"int","nextSeasonTierType");
	return;
}
if (!VaildUtil.TryConvert(values[i][6], out nextSeasonStar,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,6+1, nextSeasonStar,int.MinValue,int.MaxValue,"int","nextSeasonStar");
	return;
}
if (!VaildUtil.TryConvert(values[i][7], out nextMessageId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,7+1, nextMessageId,int.MinValue,int.MaxValue,"int","nextMessageId");
	return;
}
                    
                    
                    OnAutoParasLine(sheetName,row,values[i],ref errMsg);
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        return;
                    }
                }
            }
        }
    }
}