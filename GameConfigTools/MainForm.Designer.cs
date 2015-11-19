namespace GameConfigTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑客户端资源版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.特殊配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.importAllButton = new System.Windows.Forms.Button();
            this.importSingleButton = new System.Windows.Forms.Button();
            this.versionComboBox = new System.Windows.Forms.ComboBox();
            this.exportAllButton = new System.Windows.Forms.Button();
            this.exportSingleButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.configComboBox = new System.Windows.Forms.ComboBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.getGameBgw = new System.ComponentModel.BackgroundWorker();
            this.exportAllBgw = new System.ComponentModel.BackgroundWorker();
            this.importAllBwg = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem,
            this.特殊配置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具配置ToolStripMenuItem,
            this.编辑客户端资源版本ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // 工具配置ToolStripMenuItem
            // 
            this.工具配置ToolStripMenuItem.Name = "工具配置ToolStripMenuItem";
            this.工具配置ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.工具配置ToolStripMenuItem.Text = "工具配置";
            this.工具配置ToolStripMenuItem.Click += new System.EventHandler(this.工具配置ToolStripMenuItem_Click);
            // 
            // 编辑客户端资源版本ToolStripMenuItem
            // 
            this.编辑客户端资源版本ToolStripMenuItem.Name = "编辑客户端资源版本ToolStripMenuItem";
            this.编辑客户端资源版本ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.编辑客户端资源版本ToolStripMenuItem.Text = "编辑客户端资源版本";
            this.编辑客户端资源版本ToolStripMenuItem.Click += new System.EventHandler(this.编辑客户端资源版本ToolStripMenuItem_Click);
            // 
            // 特殊配置ToolStripMenuItem
            // 
            this.特殊配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aIToolStripMenuItem});
            this.特殊配置ToolStripMenuItem.Name = "特殊配置ToolStripMenuItem";
            this.特殊配置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.特殊配置ToolStripMenuItem.Text = "特殊配置";
            // 
            // aIToolStripMenuItem
            // 
            this.aIToolStripMenuItem.Enabled = false;
            this.aIToolStripMenuItem.Name = "aIToolStripMenuItem";
            this.aIToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.aIToolStripMenuItem.Text = "编辑AI";
            this.aIToolStripMenuItem.Click += new System.EventHandler(this.编辑AIToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.importAllButton);
            this.panel1.Controls.Add(this.importSingleButton);
            this.panel1.Controls.Add(this.versionComboBox);
            this.panel1.Controls.Add(this.exportAllButton);
            this.panel1.Controls.Add(this.exportSingleButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.configComboBox);
            this.panel1.Controls.Add(this.loadButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gameComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 93);
            this.panel1.TabIndex = 1;
            // 
            // importAllButton
            // 
            this.importAllButton.Location = new System.Drawing.Point(715, 51);
            this.importAllButton.Name = "importAllButton";
            this.importAllButton.Size = new System.Drawing.Size(92, 23);
            this.importAllButton.TabIndex = 11;
            this.importAllButton.Text = "导入全部配置";
            this.importAllButton.UseVisualStyleBackColor = true;
            this.importAllButton.Click += new System.EventHandler(this.importAllButton_Click);
            // 
            // importSingleButton
            // 
            this.importSingleButton.Location = new System.Drawing.Point(617, 51);
            this.importSingleButton.Name = "importSingleButton";
            this.importSingleButton.Size = new System.Drawing.Size(92, 23);
            this.importSingleButton.TabIndex = 10;
            this.importSingleButton.Text = "导入选择配置";
            this.importSingleButton.UseVisualStyleBackColor = true;
            this.importSingleButton.Click += new System.EventHandler(this.importSingleButton_Click);
            // 
            // versionComboBox
            // 
            this.versionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionComboBox.FormattingEnabled = true;
            this.versionComboBox.Location = new System.Drawing.Point(354, 16);
            this.versionComboBox.Name = "versionComboBox";
            this.versionComboBox.Size = new System.Drawing.Size(121, 20);
            this.versionComboBox.TabIndex = 9;
            // 
            // exportAllButton
            // 
            this.exportAllButton.Location = new System.Drawing.Point(481, 51);
            this.exportAllButton.Name = "exportAllButton";
            this.exportAllButton.Size = new System.Drawing.Size(92, 23);
            this.exportAllButton.TabIndex = 8;
            this.exportAllButton.Text = "导出全部配置";
            this.exportAllButton.UseVisualStyleBackColor = true;
            this.exportAllButton.Visible = false;
            this.exportAllButton.Click += new System.EventHandler(this.exportBatchButton_Click);
            // 
            // exportSingleButton
            // 
            this.exportSingleButton.Location = new System.Drawing.Point(383, 51);
            this.exportSingleButton.Name = "exportSingleButton";
            this.exportSingleButton.Size = new System.Drawing.Size(92, 23);
            this.exportSingleButton.TabIndex = 7;
            this.exportSingleButton.Text = "导出选择配置";
            this.exportSingleButton.UseVisualStyleBackColor = true;
            this.exportSingleButton.Visible = false;
            this.exportSingleButton.Click += new System.EventHandler(this.exportSingleButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "配置文件列表:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // configComboBox
            // 
            this.configComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configComboBox.FormattingEnabled = true;
            this.configComboBox.Location = new System.Drawing.Point(116, 54);
            this.configComboBox.Name = "configComboBox";
            this.configComboBox.Size = new System.Drawing.Size(261, 20);
            this.configComboBox.TabIndex = 5;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(481, 16);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(92, 23);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "加载配置列表";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(283, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "游戏版本:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gameComboBox
            // 
            this.gameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameComboBox.FormattingEnabled = true;
            this.gameComboBox.Location = new System.Drawing.Point(116, 19);
            this.gameComboBox.Name = "gameComboBox";
            this.gameComboBox.Size = new System.Drawing.Size(121, 20);
            this.gameComboBox.TabIndex = 1;
            this.gameComboBox.SelectedIndexChanged += new System.EventHandler(this.gameComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择游戏:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logRichTextBox.Location = new System.Drawing.Point(0, 118);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(1016, 616);
            this.logRichTextBox.TabIndex = 2;
            this.logRichTextBox.Text = "";
            // 
            // getGameBgw
            // 
            this.getGameBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getGameBgw_DoWork);
            this.getGameBgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getGameBgw_RunWorkerCompleted);
            // 
            // exportAllBgw
            // 
            this.exportAllBgw.WorkerReportsProgress = true;
            this.exportAllBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exportAllBgw_DoWork);
            this.exportAllBgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.exportAllBgw_ProgressChanged);
            this.exportAllBgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exportAllBgw_RunWorkerCompleted);
            // 
            // importAllBwg
            // 
            this.importAllBwg.WorkerReportsProgress = true;
            this.importAllBwg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.importAllBwg_DoWork);
            this.importAllBwg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.importAllBwg_ProgressChanged);
            this.importAllBwg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.importAllBwg_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置管理工具1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具配置ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox gameComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.ComboBox configComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportSingleButton;
        private System.Windows.Forms.Button exportAllButton;
        private System.Windows.Forms.ComboBox versionComboBox;
        private System.ComponentModel.BackgroundWorker getGameBgw;
        private System.ComponentModel.BackgroundWorker exportAllBgw;
        private System.Windows.Forms.Button importSingleButton;
        private System.Windows.Forms.Button importAllButton;
        private System.ComponentModel.BackgroundWorker importAllBwg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 编辑客户端资源版本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 特殊配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aIToolStripMenuItem;
    }
}

