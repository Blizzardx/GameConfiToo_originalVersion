using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using GameConfigTools.Constant;
using System.IO;
using GameConfigTools.Util;
using GameConfigTools.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GameConfigTools.Export;
using GameConfigTools.Import;
using System.Xml.Linq;
using System.Net;
using ExcelImporter.Importer;
using GameConfigTools.AIForm;

namespace GameConfigTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "是否要关闭工具吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void 工具配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog(this);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(SysConstant.SYS_CONFIG_FILE))
            {
                MessageBox.Show(this, "第一次启动程序，需要配置必要信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ConfigForm configForm = new ConfigForm();
                configForm.ShowDialog(this);
                return;
            }
            timer1.Start();
            //读取工具的配置
            XmlSerializer serializer = new XmlSerializer(typeof(SysConfig));
            SysConfig sysConfig = null;
            using (FileStream fs = new FileStream(SysConstant.SYS_CONFIG_FILE, FileMode.Open))
            {
                sysConfig = serializer.Deserialize(fs) as SysConfig;
                //将配置放到全局上下文中
                Context.instance.SetSysConfig(sysConfig);
            }
            this.panel1.Visible = false;
            LogQueue.instance.Add("正在请求配置中心加载游戏类型，请稍等...");
            getGameBgw.RunWorkerAsync();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            configComboBox.Items.Clear();
            if (gameComboBox.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择游戏", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (versionComboBox.SelectedItem == null)
            {
                MessageBox.Show(this, "请选择版本号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SysConfig config = Context.instance.GetSysConfig();
            string url = string.Format(config.ConfigCenterUrl + SysConstant.LIST_CONFIG, gameComboBox.SelectedItem.ToString(), versionComboBox.SelectedItem.ToString());
            string html = HttpUtil.HttpGet(url);
            if (html == null)
            {
                MessageBox.Show(this, "加载配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            JObject json = JObject.Parse(html);
            int status = int.Parse(json["status"].ToString());
            if (status == -1)
            {
                MessageBox.Show(this, json["errMsg"].ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Context.instance.SetGame(gameComboBox.SelectedItem.ToString());
            Context.instance.SetVersion(versionComboBox.SelectedItem.ToString());

            var configs = json["configs"];
            if (configs.Count() > 0)
            {
                List<string> configList = new List<string>();

                foreach (var c in configs)
                {
                    configList.Add(c["config"].ToString());
                    
                }

                configList.Sort();
                foreach (string s in configList)
                {
                    configComboBox.Items.Add(s);
                }
                configComboBox.SelectedIndex = 0;
            }
            aIToolStripMenuItem.Enabled = true;
        }

        private void exportSingleButton_Click(object sender, EventArgs e)
        {
            if (configComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "请选择要导出的配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SysConfig config = Context.instance.GetSysConfig();
            string configName = configComboBox.SelectedItem.ToString();
            string url = string.Format(config.ConfigCenterUrl + SysConstant.GET_NEW_CONFIG_INFO, Context.instance.GetGame(), Context.instance.GetVersion(), configName);
            string html = HttpUtil.HttpGet(url);
            if (html == null)
            {
                MessageBox.Show(this, "请求配置中心失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            JObject json = JObject.Parse(html);
            int status = int.Parse(json["status"].ToString());
            if (status == -1)
            {
                MessageBox.Show(this, json["errMsg"].ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string xml = json["content"].ToString();
            xml = System.Web.HttpUtility.UrlDecode(xml);
            Exporter exporter = ExporterManager.instance.GetExporter(configName);
            if (exporter == null)
            {
                MessageBox.Show(this, string.Format("不支持的配置文件:{0}", configName), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //导出到本地excel
            if (exporter.Export(xml))
            {
                string path = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\" + configName + "." + exporter.GetExportType();
                MessageBox.Show(this, "导出成功，已导出到:" + path, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show(this, "导出失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void getGameBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!getGameBgw.IsBusy)
            {
                return;
            }
            SysConfig config = Context.instance.GetSysConfig();
            string url = config.ConfigCenterUrl + SysConstant.LIST_GAME_TYPE;
            string html = HttpUtil.HttpGet(url);

            e.Result = html;
        }

        private void getGameBgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string html = e.Result as string;
            if (html == null)
            {
                MessageBox.Show(this, "请求配置中心失败，请检查配置中心地址的配置，并重启程序!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (Form f in Application.OpenForms)
                {
                    if (f is ConfigForm)
                    {
                        return;
                    }
                }
                ConfigForm form = new ConfigForm();
                form.ShowDialog();
                return;
            }
            JObject json = JObject.Parse(html);
            int status = int.Parse(json["status"].ToString());
            if (status == -1)
            {
                MessageBox.Show(this, json["errMsg"].ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var gameTypes = json["gameTypes"];
            foreach (var gameType in gameTypes)
            {
                gameComboBox.Items.Add(gameType["gameType"].ToString());
            }
            this.panel1.Visible = true;
            LogQueue.instance.Add("加载游戏类型成功!");
        }

        private void gameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            versionComboBox.Items.Clear();
            ComboBox box = sender as ComboBox;
            if (box.SelectedItem == null)
            {
                return;
            }
            SysConfig config = Context.instance.GetSysConfig();
            string url = string.Format(config.ConfigCenterUrl + SysConstant.LIST_VERSION, box.SelectedItem.ToString());
            string html = HttpUtil.HttpGet(url);
            if (html == null)
            {
                MessageBox.Show(this, "获取版本失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            JObject json = JObject.Parse(html);
            int status = int.Parse(json["status"].ToString());
            if (status == -1)
            {
                MessageBox.Show(this, json["errMsg"].ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var versions = json["versions"];
            foreach (var version in versions)
            {
                versionComboBox.Items.Add(version["version"].ToString());
            }
        }

        private void exportBatchButton_Click(object sender, EventArgs e)
        {
            if (configComboBox.Items.Count == 0)
            {
                MessageBox.Show(this, "没有找到要导出的配置文件!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            exportAllButton.Enabled = false;
            exportSingleButton.Enabled = false;
            exportAllBgw.RunWorkerAsync();
            LogQueue.instance.Add("开始导出配置文件，共有配置:" + configComboBox.Items.Count + "个，请稍等...");
        }

        private void exportAllBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            SysConfig config = Context.instance.GetSysConfig();
            int index = 0;
            int successCount = 0;
            int failCount = 0;
            foreach (object item in configComboBox.Items)
            {
                exportAllBgw.ReportProgress(index, "开始导出第" + (index + 1) + "个配置:" + item.ToString());
                Exporter exporter = ExporterManager.instance.GetExporter(item.ToString());
                if (exporter == null)
                {
                    exportAllBgw.ReportProgress(index, "不支持导出配置:" + item.ToString());
                    failCount++;
                }
                else
                {
                    string url = string.Format(config.ConfigCenterUrl + SysConstant.GET_NEW_CONFIG_INFO, Context.instance.GetGame(), Context.instance.GetVersion(), item.ToString());
                    string html = HttpUtil.HttpGet(url);

                    JObject json = JObject.Parse(html);
                    int status = int.Parse(json["status"].ToString());
                    if (status == -1)
                    {
                        exportAllBgw.ReportProgress(index, "导出配置:" + item.ToString() + " 错误，errMsg:" + json["errMsg"]);
                        failCount++;
                    }
                    else
                    {
                        string xml = json["content"].ToString();
                        //urldecode
                        xml = System.Web.HttpUtility.UrlDecode(xml);
                        if (exporter.Export(xml))
                        {
                            exportAllBgw.ReportProgress(index, "导出配置:" + item.ToString() + "成功!");
                            successCount++;
                        }
                        else
                        {
                            exportAllBgw.ReportProgress(index, "导出配置:" + item.ToString() + "失败!");
                            failCount++;
                        }
                    }
                }
                index++;
            }
            e.Result = new int[] { successCount, failCount };
        }

        private void exportAllBgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string info = e.UserState as string;
            LogQueue.instance.Add(info);
        }

        private void exportAllBgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int[] result = e.Result as int[];
            LogQueue.instance.Add(string.Format("成功导出:{0}个，失败:{1}个", result[0], result[1]));

            exportAllButton.Enabled = true;
            exportSingleButton.Enabled = true;
        }

        private void importSingleButton_Click(object sender, EventArgs e)
        {

            //string clientEditDataPath = sysConfig.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\" + SysConstant.CLIENT_EDIT_DATA;
            //if (!Directory.Exists(clientEditDataPath))
            //{
            //    Directory.CreateDirectory(clientEditDataPath);
            //}

            if (configComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "请选择要导入的配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Importer importer = ImporterManager.instance.GetImporter(configComboBox.SelectedItem.ToString());
            if (importer == null)
            {
                MessageBox.Show(this, "不支持导入配置:" + configComboBox.SelectedItem.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] linkImporters = ImporterManager.instance.GetLinkImporters(configComboBox.SelectedItem.ToString());
            if (linkImporters != null)
            {
                DialogResult dr = MessageBox.Show(this, string.Format("导入该配置需要关联[{0}]配置进行验证，是否确认?", string.Join(",", linkImporters)), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }

            string errMsg = "";
            if (importer.Import(ref errMsg))
            {
                MessageBox.Show(this, "导入成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            MessageBox.Show(this, "导入失败! errMsg:" + errMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void importAllButton_Click(object sender, EventArgs e)
        {
            if (configComboBox.Items.Count == 0)
            {
                MessageBox.Show(this, "请先加载配置列表后在进行导入!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult dr = MessageBox.Show(this, string.Format("共有{0}个配置文件，确定要全部导入吗?", configComboBox.Items.Count), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                importSingleButton.Enabled = false;
                importAllButton.Enabled = false;
                importAllBwg.RunWorkerAsync();
                LogQueue.instance.Add("开始导出配置文件，共有配置:" + configComboBox.Items.Count + "个，请稍等...");
            }
        }

        private void importAllBwg_DoWork(object sender, DoWorkEventArgs e)
        {
            SysConfig config = Context.instance.GetSysConfig();
            int index = 0;
            int successCount = 0;
            int failCount = 0;
            foreach (object item in configComboBox.Items)
            {
                importAllBwg.ReportProgress(index, "开始导入第" + (index + 1) + "个配置:" + item.ToString());
                Importer exporter = ImporterManager.instance.GetImporter(item.ToString());
                if (exporter == null)
                {
                    importAllBwg.ReportProgress(index, "不支持导入配置:" + item.ToString());
                    failCount++;
                }
                else
                {
                    string errMsg = "";
                    if (exporter.Import(ref errMsg))
                    {
                        importAllBwg.ReportProgress(index, "导入配置:" + item.ToString() + "成功!");
                        successCount++;
                    }
                    else
                    {
                        importAllBwg.ReportProgress(index, "导入配置:" + item.ToString() + "失败! errMsg:" + errMsg);
                        failCount++;
                    }
                }
                index++; 
            }
            e.Result = new int[] { successCount, failCount };
        }

        private void importAllBwg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string info = e.UserState as string;
            LogQueue.instance.Add(info);
        }

        private void importAllBwg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int[] result = e.Result as int[];
            LogQueue.instance.Add(string.Format("成功导出:{0}个，失败:{1}个", result[0], result[1]));

            importSingleButton.Enabled = true;
            importAllButton.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string log = LogQueue.instance.Take();
            if (log == null)
            {
                return;
            }
            this.logRichTextBox.AppendText(log);
            this.logRichTextBox.Focus();
            this.logRichTextBox.Select(this.logRichTextBox.Text.Length, 0);
            this.logRichTextBox.ScrollToCaret();
        }

        private void 编辑客户端资源版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configComboBox.Items.Count == 0)
            {
                MessageBox.Show(this, "请先加载配置列表后在进行编辑!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        }

        private void 编辑AIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection coll = Application.OpenForms;
            foreach(Form form in coll)
            {
                if (form is EditAIConfigForm)
                {
                    form.Focus();
                    return;
                }
            }
            EditAIConfigForm aiForm = new EditAIConfigForm();
            aiForm.Show();
        }

        private void 自动生成解析代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptGenTool.GenAllScript();
        }
    }
}
