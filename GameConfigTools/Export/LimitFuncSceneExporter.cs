using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using GameConfigTools.Constant;

namespace GameConfigTools.Export
{
    /// <summary>
    /// limitFuncSceneConfig配置的导出实现
    /// </summary>
    public class LimitFuncSceneExporter : AbstractExcelExporter
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LimitFuncSceneExporter));

        protected override string[] GetColumns()
        {
            return new string[] { "#场景ID", "条件1,功能1", "条件2,功能2", "条件3,功能3..." };
        }
        protected override string GetConfigName()
        {
            return SysConstant.LIMIT_FUNC_SCENE_CONFIG;
        }
        protected override string GetSheetName()
        {
            return "条件功能函数场景";
        }
        protected override string[][] GetValues(string xml)
        {
            if (xml == null || xml.Trim() == "")
            {
                return null;
            }
            try
            {
                XElement root = XElement.Parse(xml);
                var scenes = root.Elements("scene");
                string[][] values = new string[scenes.Count()][];
                int index = 0;
                foreach (var scene in scenes)
                {
                    var limitFuncScenes = scene.Elements("limitFuncScene");
                    string[] ss = values[index] = new string[limitFuncScenes.Count() + 1];
                    ss[0] = scene.Attribute("id").Value;
                    int j = 1;
                    foreach (var limitFuncScene in limitFuncScenes)
                    {
                        ss[j] = limitFuncScene.Attribute("limitId").Value + "," + limitFuncScene.Attribute("funcId").Value;
                        j++;
                    }

                    index++;
                }
                return values;
            }
            catch (Exception e)
            {
                logger.Error("export " + this.GetConfigName() + " error. xml:" + xml, e);
            }
            return null;
        }
    }
}
