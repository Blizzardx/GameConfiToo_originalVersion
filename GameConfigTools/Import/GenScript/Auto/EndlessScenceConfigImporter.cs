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
    public partial class EndlessScenceConfigImporter : AbstractExcelImporter
    {
		private string resource;
		private int styleId;
		private int difficulty;
		private int direction;
    
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

if (!VaildUtil.TryConvert(values[i][0], out resource,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,0+1, resource,string.Empty,string.Empty,"string","resource");
	return;
}
if (!VaildUtil.TryConvert(values[i][1], out styleId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,1+1, styleId,int.MinValue,int.MaxValue,"int","styleId");
	return;
}
if (!VaildUtil.TryConvert(values[i][2], out difficulty,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,2+1, difficulty,int.MinValue,int.MaxValue,"int","difficulty");
	return;
}
if (!VaildUtil.TryConvert(values[i][3], out direction,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,3+1, direction,int.MinValue,int.MaxValue,"int","direction");
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