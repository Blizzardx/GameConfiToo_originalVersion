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
    public partial class FashionConfigImporter : AbstractExcelImporter
    {
		private int id;
		private string name;
		private int nameMessageId;
		private int descMessageId;
		private int decomposeId;
		private string icon;
		private int firstType;
		private string resource;
		private int activeLimitId;
		private int activeCostId;
		private string animation;
		private int dyeingCostId;
		private List<int> dyeingIdList;
		private List<int> CustomizedIdList;
    
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

if (!VaildUtil.TryConvert(values[i][0], out id,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,0+1, id,int.MinValue,int.MaxValue,"int","id");
	return;
}
if (!VaildUtil.TryConvert(values[i][1], out name,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,1+1, name,string.Empty,string.Empty,"string","name");
	return;
}
if (!VaildUtil.TryConvert(values[i][2], out nameMessageId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,2+1, nameMessageId,int.MinValue,int.MaxValue,"int","nameMessageId");
	return;
}
if (!VaildUtil.TryConvert(values[i][4], out descMessageId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,4+1, descMessageId,int.MinValue,int.MaxValue,"int","descMessageId");
	return;
}
if (!VaildUtil.TryConvert(values[i][5], out decomposeId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,5+1, decomposeId,int.MinValue,int.MaxValue,"int","decomposeId");
	return;
}
if (!VaildUtil.TryConvert(values[i][6], out icon,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,6+1, icon,string.Empty,string.Empty,"string","icon");
	return;
}
if (!VaildUtil.TryConvert(values[i][7], out firstType,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,7+1, firstType,int.MinValue,int.MaxValue,"int","firstType");
	return;
}
if (!VaildUtil.TryConvert(values[i][8], out resource,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,8+1, resource,string.Empty,string.Empty,"string","resource");
	return;
}
if (!VaildUtil.TryConvert(values[i][9], out activeLimitId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,9+1, activeLimitId,int.MinValue,int.MaxValue,"int","activeLimitId");
	return;
}
if (!VaildUtil.TryConvert(values[i][10], out activeCostId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,10+1, activeCostId,int.MinValue,int.MaxValue,"int","activeCostId");
	return;
}
if (!VaildUtil.TryConvert(values[i][11], out animation,string.Empty,string.Empty))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,11+1, animation,string.Empty,string.Empty,"string","animation");
	return;
}
if (!VaildUtil.TryConvert(values[i][12], out dyeingCostId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,12+1, dyeingCostId,int.MinValue,int.MaxValue,"int","dyeingCostId");
	return;
}
 try
{
    dyeingIdList = VaildUtil.SplitToList_int(values[i][13]);
}
catch (Exception e)
{
    errMsg = string.Format("{4} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误 ", this.GetConfigName(), sheetName, row,13+1, "dyeingIdList");
    errMsg += " " + e.Message;
    return;
}     try
{
    CustomizedIdList = VaildUtil.SplitToList_int(values[i][14]);
}
catch (Exception e)
{
    errMsg = string.Format("{4} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误 ", this.GetConfigName(), sheetName, row,14+1, "CustomizedIdList");
    errMsg += " " + e.Message;
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