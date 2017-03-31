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
        private DiyFaceDataConfigTable m_Config;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = m_Config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.DIY_FACE_DATA_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            DiyFaceDataConfig c = new DiyFaceDataConfig();
            c.Id = positionId;
            c.ModeId = modeId;
            c.UiNormalValue =
                (int) ((faceDataNormal*1.0f - faceDataMin*1.0f)/(faceDataMax * 1.0f - faceDataMin*1.0f)*10000);
            c.UiValueMin = faceDataMin;
            c.UiValuePow = (faceDataMax - faceDataMin);

            if (faceCmdValueInfo.Count == 0)
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，没有找到命令数组", this.GetConfigName(), sheetName, row);
                return;
            }
            c.CmdValueInfoList = new List<DiyFaceDataCmdValueInfo>();

            for (int i = 0; i < faceCmdValueInfo.Count; ++i)
            {
                var elem = faceCmdValueInfo[i];
                DiyFaceDataCmdValueInfo data = new DiyFaceDataCmdValueInfo();

                if (null == elem || elem.Count != 4)
                {
                    errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，第{3}组 命令数组读取出现错误，为空或者不为4", this.GetConfigName(), sheetName, row,i + 1);
                    return;
                }
                data.CmdName = elem[0];
                if (string.IsNullOrEmpty(data.CmdName))
                {
                    errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，第{3}组 命令数组读取出现错误 name", this.GetConfigName(), sheetName, row, i + 1);
                    return;
                }
                int tmpValue = 0;
                if (!VaildUtil.TryConvert(elem[1], out tmpValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，第{3}组 命令数组读取出现错误 CmdValueMin", this.GetConfigName(), sheetName, row, i + 1);
                    return;
                }
                data.CmdValueMin = tmpValue;
                if (!VaildUtil.TryConvert(elem[2], out tmpValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，第{3}组 命令数组读取出现错误 CmdValueNormal", this.GetConfigName(), sheetName, row, i + 1);
                    return;
                }
                data.CmdValueNormal = tmpValue;
                if (!VaildUtil.TryConvert(elem[3], out tmpValue))
                {
                    errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，第{3}组 命令数组读取出现错误 CmdValueMax", this.GetConfigName(), sheetName, row, i + 1);
                    return;
                }
                data.CmdValueMax = tmpValue;
                c.CmdValueInfoList.Add(data);
            }
            if (m_Config.DiyFaceDataConfigMap.ContainsKey(c.Id))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，id 重复", this.GetConfigName(), sheetName, row);
                return;
            }
            m_Config.DiyFaceDataConfigMap.Add(c.Id,c);
        }

        protected override void OnAutoParasBegin()
        {
            m_Config = new DiyFaceDataConfigTable();
            m_Config.DiyFaceDataConfigMap = new Dictionary<int, DiyFaceDataConfig>();
        }
    }
}
