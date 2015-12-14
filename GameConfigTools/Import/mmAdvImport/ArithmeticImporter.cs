using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using Common.Config;
using Common.Config.Table;

namespace GameConfigTools.Import.mmAdvImport
{
    class ArithmeticImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            root = new XElement("root");

            ArithmeticConfigTable config = new ArithmeticConfigTable();
            tbase = config;
            config.TimerList = new List<ArithmeticTimer>();
            config.QuestionList = new List<ArithmeticQuestion>();
            string[] sheetNames = this.GetSheetNames();

            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                if (sheetIndex.Equals(0))
                {
                    if (!QuestionList(config, sheetName, values, ref errMsg))
                    {
                        return;
                    }
                }else{
                    if (!TimerList(config, sheetName, values, ref errMsg))
                    {
                        return;
                    } 
                }
            }
        }

        bool TimerList(ArithmeticConfigTable config, string sheetName, string[][] values, ref string errMsg)
        {
            for (int i = 0; i < values.Length; i++)
            {
                ArithmeticTimer arithmeticTimer = new ArithmeticTimer();
                if (!this.IsLineNotNull(values[i]))
                {
                    continue;
                }
                int row = i + 1;
                int index = 0;

                float difficulty;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out difficulty))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度级别(ID)必须为0 - {4}浮点型", this.GetConfigName(), sheetName, row, index, float.MaxValue);
                    return false;
                }
                int timer;
                if (!VaildUtil.TryConvertInt(values[i][index++] ,out timer))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度级别(ID)必须为0 - {4}整数型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                    return false;
                }
                arithmeticTimer.Difficulty = difficulty;
                arithmeticTimer.Timer = timer;
                config.TimerList.Add(arithmeticTimer);
            }
            return true;
        }

        bool QuestionList(ArithmeticConfigTable config, string sheetName, string[][] values, ref string errMsg)
        {
            for (int i = 0; i < values.Length; i++)
            {
                ArithmeticQuestion arithmeticQuestion = new ArithmeticQuestion();
                arithmeticQuestion.ItemList = new List<ArithmeticItem>();
                if (!this.IsLineNotNull(values[i]))
                {
                    continue;
                }
                int row = i + 1;
                int index = 0;

                float difficulty;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out difficulty))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度级别(ID)必须为0 - {4}浮点型", this.GetConfigName(), sheetName, row, index, float.MaxValue);
                    return false;
                }
                string optionContent = values[i][index++];
                if (optionContent.Equals(""))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误", this.GetConfigName(), sheetName, row, index) + optionContent + "为空";
                    return false;
                }
                
                while (true)
                {
                    int expression;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out expression))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，表达式必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return false;
                    }
                    if (index >= values[i].Length)
                    {
                        ArithmeticItem item = new ArithmeticItem();
                        item.Expression = expression;
                        item.Operation = "";
                        arithmeticQuestion.ItemList.Add(item);
                        break;
                    }
                       
                    string operation = values[i][index++];
                   
                    if (!operation.Equals("+") && !operation.Equals("-"))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误", this.GetConfigName(), sheetName, row, index) + operation + "为非法符号";
                        return false;
                    }

                    ArithmeticItem item1 = new ArithmeticItem();
                    item1.Expression = expression;
                    item1.Operation = operation;
                    arithmeticQuestion.ItemList.Add(item1);
                    if (string.IsNullOrEmpty(operation))
                    {
                        break;
                    }
                }
                arithmeticQuestion.Difficulty = difficulty;
                config.QuestionList.Add(arithmeticQuestion);
            }
            return true;
        }
        protected override string GetConfigName()
        {
            return SysConstant.ARITHMETIC_CONFIG;
        }
    }
}
