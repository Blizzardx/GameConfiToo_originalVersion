using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class LimitFuncSceneImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            LimitConfigTable limitConfig = ImporterManager.instance.GetCacheConfig(SysConstant.LIMIT_CONFIG, ref errMsg) as LimitConfigTable;
            if (limitConfig == null)
            {
                return;
            }

            FuncConfigTable funcConfig = ImporterManager.instance.GetCacheConfig(SysConstant.FUNC_CONFIG, ref errMsg) as FuncConfigTable;
            if (funcConfig == null)
            {
                return;
            }

            root = new XElement("limitFuncSceneConfig");
            LimitFuncSceneConfigTable config = new LimitFuncSceneConfigTable();
            config.LimitFuncSceneConfigMap = new Dictionary<int, List<LimitFuncSceneConfig>>();
            tbase = config;

            string[] sheetNames = this.GetSheetNames();
            ISet<int> sceneIdSet = new HashSet<int>();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                
                for (int i = 0; i < values.Length; i++)
                {
                    int row = i + 1;
                    int index = 0;
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int sceneId;
                    if (!int.TryParse(values[i][index++], out sceneId))
                    {
                        errMsg = string.Format("[{0}] sheet:[{1}] [{2},{3}]错误，场景Id:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, sceneId);
                        return;
                    }
                    if (!sceneIdSet.Add(sceneId))
                    {
                        errMsg = string.Format("[{0}] sheet:[{1}] [{2},{3}]错误，场景Id:[{4}]", this.GetConfigName(), sheetName, row, index, sceneId);
                        return;
                    }
                    //跳过描述列
                    index++;


                    List<int> list = new List<int>();
                    for (int j = index; index < values[i].Length; index++)
                    {
                        int column = index + 1;
                        string v = values[i][index];
                        if (v == null || v.Trim() == "")
                        {
                            continue;
                        }
                        int id;
                        if (!int.TryParse(values[i][index], out id))
                        {
                            errMsg = string.Format("[{0}] sheet:[{1}] [{2},{3}]错误，条件/功能的ID:[{4}]必须为整型", this.GetConfigName(), sheetName, row, column, values[i][index]);
                            return;
                        }
                        list.Add(id);
                    }

                    if (list.Count % 3 != 0)
                    {
                        errMsg = string.Format("[{0}] sheet:[{1}] 第{2}行错误，目标函数/条件函数/功能函数的ID必须成对出现", this.GetConfigName(), sheetName, row);
                        return;
                    }
                    if (list.Count == 0)
                    {
                        continue;
                    }

                    XElement sceneElement = new XElement("scene", new XAttribute("id", sceneId));
                    root.Add(sceneElement);

                    List<LimitFuncSceneConfig> sceneList = new List<LimitFuncSceneConfig>();

                    config.LimitFuncSceneConfigMap.Add(sceneId, sceneList);

                    for (int j = 0; j < list.Count / 3; j++)
                    {
                        int targetId = list[j * 3];
                        int limitId = list[j * 3 + 1];
                        int funcId = list[j * 3 + 2];
                        if (limitId == 0 && funcId == 0)
                        {
                            continue;
                        }
                        //if (limitId > 0 && !limitConfig.LimitMap.ContainsKey(limitId))
                        //{
                        //    errMsg = string.Format("sheet:[{0}] 第[{1}]行错误，条件组ID:[{2}]在" + SysConstant.LIMIT_CONFIG + "中不存在", sheetName, row, limitId);
                        //    return;
                        //}
                        //if (funcId > 0 && !funcConfig.FuncMap.ContainsKey(funcId))
                        //{
                        //    errMsg = string.Format("sheet:[{0}] 第[{1}]行错误，功能组ID:[{2}]在" + SysConstant.FUNC_CONFIG + "中不存在", sheetName, row, funcId);
                        //    return;
                        //}

                        XElement limitFuncScene = new XElement("limitFuncScene");
                        limitFuncScene.Add(new XAttribute("targetId", targetId));
                        limitFuncScene.Add(new XAttribute("limitId", limitId));
                        limitFuncScene.Add(new XAttribute("funcId", funcId));
                        sceneElement.Add(limitFuncScene);

                        LimitFuncSceneConfig c = new LimitFuncSceneConfig();
                        c.TargetId = targetId;
                        c.LimitId = limitId;
                        c.FuncId = funcId;

                        sceneList.Add(c);
                    }
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.LIMIT_FUNC_SCENE_CONFIG;
        }
    }
}
