using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class DarkCloudConfigImporter:AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            //root = new XElement("root");

            DarkCloudConfigTable config = new DarkCloudConfigTable();
            tbase = config;
            config.DarkcloudConfigMap = new Dictionary<int, DarkCloudConfig>();

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

                    int id;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];

                    int begintimemin;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out begintimemin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，开始时间min必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int begintimemax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out begintimemax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，开始时间max必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int duringtimemin;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out duringtimemin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，持续时间min必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int duringtimemax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out duringtimemax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，持续时间max必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int firstTaskFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out firstTaskFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，firstTaskFucId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int secondTaskFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out secondTaskFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，secondTaskFuncId必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int secondTaskWaitTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out secondTaskWaitTime, 0, 1024))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，后置任务等待时间必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, 1024);
                        return;
                    }
                    int positionId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out positionId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，位置id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string beginAction = values[i][index++];
                    string thunderAction = values[i][index++];
                    string endAction = values[i][index++];

                    int tickTimeMin;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickTimeMin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，心跳min必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int tickTimeMax;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out tickTimeMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，心跳max必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maxCount;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxCount))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大数量必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    DarkCloudConfig c = new DarkCloudConfig();
                    c.Id = id;
                    c.BeginTimeMin = begintimemin;
                    c.BeginTimeMax = begintimemax;
                    c.DuringTimeMin = duringtimemin;
                    c.DuringTimeMax = duringtimemax;
                    c.FirstTaskFuncId = firstTaskFuncId;
                    c.SecondTaskFuncId = secondTaskFuncId;
                    c.SecondTaskWaitingTime = secondTaskWaitTime;
                    c.PositionId = positionId;
                    c.BeginAction = beginAction;
                    c.ThunderAction = thunderAction;
                    c.EndAction = endAction;
                    config.DarkcloudConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return  SysConstant.DARK_CLOUD_CONFIG;
        }
    }
}
