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
    public partial class DiyFaceDataConfigImporter : AbstractExcelImporter
    {
		private int positionId;
		private int modeId;
		private int faceDataMin;
		private int faceDataNormal;
		private int faceDataMax;
		private List<List<string>> faceCmdValueInfo;
    
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

if (!VaildUtil.TryConvert(values[i][0], out positionId,1,11))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,0+1, positionId,1,11,"int","positionId");
	return;
}
if (!VaildUtil.TryConvert(values[i][1], out modeId,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,1+1, modeId,int.MinValue,int.MaxValue,"int","modeId");
	return;
}
if (!VaildUtil.TryConvert(values[i][2], out faceDataMin,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,2+1, faceDataMin,int.MinValue,int.MaxValue,"int","faceDataMin");
	return;
}
if (!VaildUtil.TryConvert(values[i][3], out faceDataNormal,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,3+1, faceDataNormal,int.MinValue,int.MaxValue,"int","faceDataNormal");
	return;
}
if (!VaildUtil.TryConvert(values[i][4], out faceDataMax,int.MinValue,int.MaxValue))
{
	errMsg = string.Format("{8} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，{4}必须为{5} - {6} {7}型", this.GetConfigName(), sheetName, row,4+1, faceDataMax,int.MinValue,int.MaxValue,"int","faceDataMax");
	return;
}
try
{
    
    faceCmdValueInfo = VaildUtil.ParseBracket(5,values[i]);
    if (null == faceCmdValueInfo)
    {
		errMsg = string.Format("{4} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误 ", this.GetConfigName(), sheetName, row,5+1, "faceCmdValueInfo");
        return;
    }
}
catch (Exception e)
{
    errMsg = string.Format("{4} {0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误 ", this.GetConfigName(), sheetName, row,5+1, "faceCmdValueInfo");              
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