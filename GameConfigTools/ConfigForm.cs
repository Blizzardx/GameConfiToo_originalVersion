using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using GameConfigTools.Model;
using GameConfigTools.Util;
using GameConfigTools.Constant;

namespace GameConfigTools
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void selectConfigPathButton_Click(object sender, EventArgs e)
        {
            configPathFolderBrowserDialog.Description = "选择服务器配置文件所存在的路径";
            DialogResult result = configPathFolderBrowserDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                serverConfigPathTextBox.Text = configPathFolderBrowserDialog.SelectedPath;
            }
        }

        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverConfigPathTextBox.Text.Trim() == "")
            {
                System.Environment.Exit(System.Environment.ExitCode);
                return;
            }
            if (excelPathTextBox.Text.Trim() == "")
            {
                System.Environment.Exit(System.Environment.ExitCode);
                return;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string serverConfigPath = serverConfigPathTextBox.Text.Trim();
            if (serverConfigPath == "")
            {
                MessageBox.Show(this, "没有选择服务器配置导出的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string clientConfigPath = clientConfigPathTextBox.Text.Trim();
            if (clientConfigPath == "")
            {
                MessageBox.Show(this, "没有选择客户端配置导出的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string excelPath = excelPathTextBox.Text.Trim();
            if (excelPath == "")
            {
                MessageBox.Show(this, "没有选择Excel导出的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string configCenterUrl = configCenterUrlTextBox.Text.Trim();
            if (configCenterUrl == "")
            {
                MessageBox.Show(this, "游戏配置中心地址不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string uploadUrl = uploadUrlTextBox.Text.Trim();
            if (uploadUrl == "")
            {
                MessageBox.Show(this, "客户端资源上传地址不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SysConfig config = Context.instance.GetSysConfig();
            if (config == null)
            {
                config = new SysConfig();
            }
            config.ServerConfigPath = serverConfigPath;
            config.ClientConfigPath = clientConfigPath;
            config.ExcelPath = excelPath;
            config.ConfigCenterUrl = configCenterUrl;
            config.UploadUrl = uploadUrl;

            //如果conf文件不存在，则创建
            if (!Directory.Exists(SysConstant.SYS_CONFIG_PATH))
            {
                Directory.CreateDirectory(SysConstant.SYS_CONFIG_PATH);
            }

            //将对象写回文件中
            XmlSerializer serializer = new XmlSerializer(typeof(SysConfig));
            using (StreamWriter sw = new StreamWriter(SysConstant.SYS_CONFIG_FILE, false))
            {
                serializer.Serialize(sw, config);
            }

            MessageBox.Show(this, "保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            SysConfig config = Context.instance.GetSysConfig();
            serverConfigPathTextBox.Text = config.ServerConfigPath;
            clientConfigPathTextBox.Text = config.ClientConfigPath;
            configCenterUrlTextBox.Text = config.ConfigCenterUrl;
            excelPathTextBox.Text = config.ExcelPath;
            uploadUrlTextBox.Text = config.UploadUrl;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            string configCenterUrl = configCenterUrlTextBox.Text.Trim();
            if (configCenterUrl == "")
            {
                MessageBox.Show(this, "请输入配置中心地址再进行测试连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string html = HttpUtil.HttpGet(configCenterUrl);
            if (html == null)
            {
                MessageBox.Show(this, "连接失败!","错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(this, "连接成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void selectExcelPathButton_Click(object sender, EventArgs e)
        {
            configPathFolderBrowserDialog.Description = "选择Excel所存在的路径";
            DialogResult result = configPathFolderBrowserDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                excelPathTextBox.Text = configPathFolderBrowserDialog.SelectedPath;
            }
        }

        private void selectClientConfigPathButton_Click(object sender, EventArgs e)
        {
            configPathFolderBrowserDialog.Description = "选择客户端配置文件所存在的路径";
            DialogResult result = configPathFolderBrowserDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                clientConfigPathTextBox.Text = configPathFolderBrowserDialog.SelectedPath;
            }
        }

        private void test2Button_Click(object sender, EventArgs e)
        {
            string uploadUrl = uploadUrlTextBox.Text.Trim();
            if (uploadUrl == "")
            {
                MessageBox.Show(this, "请输入客户端资源上传地址再进行测试连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int statusCode = HttpUtil.HttpHead(uploadUrl);
            if (statusCode != 200)
            {
                MessageBox.Show(this, "连接失败, statusCode:" + statusCode, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(this, "连接成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void serverConfigPathTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
