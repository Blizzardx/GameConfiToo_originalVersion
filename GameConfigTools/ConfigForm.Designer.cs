namespace GameConfigTools
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.serverConfigPathTextBox = new System.Windows.Forms.TextBox();
            this.selectServerConfigPathButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.configPathFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.configCenterUrlTextBox = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.selectExcelPathButton = new System.Windows.Forms.Button();
            this.excelPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectClientConfigPathButton = new System.Windows.Forms.Button();
            this.clientConfigPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.test2Button = new System.Windows.Forms.Button();
            this.uploadUrlTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏配置导出路径(服务器):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverConfigPathTextBox
            // 
            this.serverConfigPathTextBox.Location = new System.Drawing.Point(179, 9);
            this.serverConfigPathTextBox.Name = "serverConfigPathTextBox";
            this.serverConfigPathTextBox.ReadOnly = true;
            this.serverConfigPathTextBox.Size = new System.Drawing.Size(353, 21);
            this.serverConfigPathTextBox.TabIndex = 1;
            // 
            // selectServerConfigPathButton
            // 
            this.selectServerConfigPathButton.Location = new System.Drawing.Point(538, 7);
            this.selectServerConfigPathButton.Name = "selectServerConfigPathButton";
            this.selectServerConfigPathButton.Size = new System.Drawing.Size(70, 23);
            this.selectServerConfigPathButton.TabIndex = 2;
            this.selectServerConfigPathButton.Text = "选择目录";
            this.selectServerConfigPathButton.UseVisualStyleBackColor = true;
            this.selectServerConfigPathButton.Click += new System.EventHandler(this.selectConfigPathButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(114, 284);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(360, 284);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "关闭";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(57, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "配置中心地址:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // configCenterUrlTextBox
            // 
            this.configCenterUrlTextBox.Location = new System.Drawing.Point(179, 114);
            this.configCenterUrlTextBox.Name = "configCenterUrlTextBox";
            this.configCenterUrlTextBox.Size = new System.Drawing.Size(353, 21);
            this.configCenterUrlTextBox.TabIndex = 1;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(538, 113);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(70, 23);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "测试连接";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // selectExcelPathButton
            // 
            this.selectExcelPathButton.Location = new System.Drawing.Point(538, 75);
            this.selectExcelPathButton.Name = "selectExcelPathButton";
            this.selectExcelPathButton.Size = new System.Drawing.Size(70, 23);
            this.selectExcelPathButton.TabIndex = 7;
            this.selectExcelPathButton.Text = "选择目录";
            this.selectExcelPathButton.UseVisualStyleBackColor = true;
            this.selectExcelPathButton.Click += new System.EventHandler(this.selectExcelPathButton_Click);
            // 
            // excelPathTextBox
            // 
            this.excelPathTextBox.Location = new System.Drawing.Point(179, 79);
            this.excelPathTextBox.Name = "excelPathTextBox";
            this.excelPathTextBox.ReadOnly = true;
            this.excelPathTextBox.Size = new System.Drawing.Size(353, 21);
            this.excelPathTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(57, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Excel导出路径:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectClientConfigPathButton
            // 
            this.selectClientConfigPathButton.Location = new System.Drawing.Point(538, 42);
            this.selectClientConfigPathButton.Name = "selectClientConfigPathButton";
            this.selectClientConfigPathButton.Size = new System.Drawing.Size(70, 23);
            this.selectClientConfigPathButton.TabIndex = 10;
            this.selectClientConfigPathButton.Text = "选择目录";
            this.selectClientConfigPathButton.UseVisualStyleBackColor = true;
            this.selectClientConfigPathButton.Click += new System.EventHandler(this.selectClientConfigPathButton_Click);
            // 
            // clientConfigPathTextBox
            // 
            this.clientConfigPathTextBox.Location = new System.Drawing.Point(179, 44);
            this.clientConfigPathTextBox.Name = "clientConfigPathTextBox";
            this.clientConfigPathTextBox.ReadOnly = true;
            this.clientConfigPathTextBox.Size = new System.Drawing.Size(353, 21);
            this.clientConfigPathTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "游戏配置导出路径(客户端):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // test2Button
            // 
            this.test2Button.Location = new System.Drawing.Point(538, 150);
            this.test2Button.Name = "test2Button";
            this.test2Button.Size = new System.Drawing.Size(70, 23);
            this.test2Button.TabIndex = 13;
            this.test2Button.Text = "测试连接";
            this.test2Button.UseVisualStyleBackColor = true;
            this.test2Button.Click += new System.EventHandler(this.test2Button_Click);
            // 
            // uploadUrlTextBox
            // 
            this.uploadUrlTextBox.Location = new System.Drawing.Point(179, 151);
            this.uploadUrlTextBox.Name = "uploadUrlTextBox";
            this.uploadUrlTextBox.Size = new System.Drawing.Size(353, 21);
            this.uploadUrlTextBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "客户端资源上传地址:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 344);
            this.Controls.Add(this.test2Button);
            this.Controls.Add(this.uploadUrlTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.selectClientConfigPathButton);
            this.Controls.Add(this.clientConfigPathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectExcelPathButton);
            this.Controls.Add(this.excelPathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.selectServerConfigPathButton);
            this.Controls.Add(this.configCenterUrlTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverConfigPathTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverConfigPathTextBox;
        private System.Windows.Forms.Button selectServerConfigPathButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog configPathFolderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox configCenterUrlTextBox;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button selectExcelPathButton;
        private System.Windows.Forms.TextBox excelPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectClientConfigPathButton;
        private System.Windows.Forms.TextBox clientConfigPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button test2Button;
        private System.Windows.Forms.TextBox uploadUrlTextBox;
        private System.Windows.Forms.Label label5;
    }
}