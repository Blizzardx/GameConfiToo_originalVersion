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
    public partial class ScenePreloadAssetConfigImporter : AbstractExcelImporter
    {
        private ScenePreloadAssetConfigTable m_Config;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = m_Config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.SCENE_PRELOAD_ASSET_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if (!m_Config.PreloadAssetList.ContainsKey(sceneClassType))
            {
                m_Config.PreloadAssetList.Add(sceneClassType,new List<string>());
            }
            if (m_Config.PreloadAssetList[sceneClassType].Contains(preloadAssetName))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，资源重复", this.GetConfigName(), sheetName, row);
                return;
            }
            var tmpS = preloadAssetName.Split(' ');
            if (null != tmpS && tmpS.Length > 1)
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，资源包含空格", this.GetConfigName(), sheetName, row);
                return;
            }
            m_Config.PreloadAssetList[sceneClassType].Add(preloadAssetName);
        }

        protected override void OnAutoParasBegin()
        {
            m_Config = new ScenePreloadAssetConfigTable();
            m_Config.PreloadAssetList = new Dictionary<string, List<string>>();
        }
    }
}
