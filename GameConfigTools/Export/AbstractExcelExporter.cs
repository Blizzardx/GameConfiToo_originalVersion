using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using GameConfigTools.Model;
using GameConfigTools.Util;

namespace GameConfigTools.Export
{
    public abstract class AbstractExcelExporter : Exporter
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AbstractExcelExporter));

        public string GetExportType()
        {
            return "xlsx";
        }

        public bool Export(string xml)
        {
            Application excel = new Application();
            Workbook workBook = null;
            Worksheet sheet = null;
            try
            {
                workBook = excel.Application.Workbooks.Add(Missing.Value);
                //sheet = workBook.ActiveSheet as Worksheet;

                sheet = workBook.Sheets[1];
                Console.WriteLine(workBook.Sheets.Count);

                //设置Excel不可见
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //设置Excel字段类型全部为字符串
                sheet.Cells.NumberFormat = "@";
                if (this.GetSheetName() != null)
                {
                    sheet.Name = this.GetSheetName();
                }
                string[] columns = this.GetColumns();

                if (columns != null && columns.Length > 0)
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        excel.Cells[1, i + 1] = columns[i];
                    }
                }
                string[][] values = this.GetValues(xml);
                if (values != null && values.Length > 0)
                {
                    int row = (columns != null && columns.Length > 0) ? 2 : 1;
                    for (int i = 0; i < values.Length; i++)
                    {
                        string[] ss = values[i];
                        for (int j = 0; j < ss.Length; j++)
                        {
                            excel.Cells[i + row, j + 1] = ss[j];
                        }
                    }
                }

                SysConfig config = Context.instance.GetSysConfig();

                string path = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion();
                string excelName = this.GetConfigName() + ".xlsx";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                workBook.SaveAs(path + @"\" + excelName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                return true;
            }
            catch (Exception e)
            {
                logger.Error("export excel:" + this.GetConfigName() + " error.", e);
                return false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(Missing.Value, Missing.Value, Missing.Value);
                }
                excel.Workbooks.Close();
                excel.Quit();

                ProcessUtil.KillProcess("Excel");
                excel = null;
                sheet = null;
                workBook = null;
            }
        }

        protected abstract string GetSheetName();

        protected abstract string GetConfigName();

        /// <summary>
        /// 返回excel的列名
        /// </summary>
        /// <returns></returns>
        protected abstract string[] GetColumns();

        protected abstract string[][] GetValues(string xml);

    }
}
