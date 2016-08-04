namespace GameConfigTools.AIForm.Action
{
    partial class IdleRandomActionPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xMinBox = new System.Windows.Forms.TextBox();
            this.xMaxBox = new System.Windows.Forms.TextBox();
            this.yMinBox = new System.Windows.Forms.TextBox();
            this.duringtimeMaxBox = new System.Windows.Forms.TextBox();
            this.duringtimeMinBox = new System.Windows.Forms.TextBox();
            this.yMaxBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "x轴速度min*10000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "x轴速度max*10000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "y轴速度min*10000";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "持续时间帧数max";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "持续时间帧数min";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "y轴速度max*10000";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xMinBox
            // 
            this.xMinBox.Location = new System.Drawing.Point(150, 3);
            this.xMinBox.Name = "xMinBox";
            this.xMinBox.Size = new System.Drawing.Size(100, 21);
            this.xMinBox.TabIndex = 12;
            // 
            // xMaxBox
            // 
            this.xMaxBox.Location = new System.Drawing.Point(150, 25);
            this.xMaxBox.Name = "xMaxBox";
            this.xMaxBox.Size = new System.Drawing.Size(100, 21);
            this.xMaxBox.TabIndex = 13;
            // 
            // yMinBox
            // 
            this.yMinBox.Location = new System.Drawing.Point(150, 48);
            this.yMinBox.Name = "yMinBox";
            this.yMinBox.Size = new System.Drawing.Size(100, 21);
            this.yMinBox.TabIndex = 14;
            // 
            // duringtimeMaxBox
            // 
            this.duringtimeMaxBox.Location = new System.Drawing.Point(150, 113);
            this.duringtimeMaxBox.Name = "duringtimeMaxBox";
            this.duringtimeMaxBox.Size = new System.Drawing.Size(100, 21);
            this.duringtimeMaxBox.TabIndex = 17;
            // 
            // duringtimeMinBox
            // 
            this.duringtimeMinBox.Location = new System.Drawing.Point(150, 90);
            this.duringtimeMinBox.Name = "duringtimeMinBox";
            this.duringtimeMinBox.Size = new System.Drawing.Size(100, 21);
            this.duringtimeMinBox.TabIndex = 16;
            // 
            // yMaxBox
            // 
            this.yMaxBox.Location = new System.Drawing.Point(150, 68);
            this.yMaxBox.Name = "yMaxBox";
            this.yMaxBox.Size = new System.Drawing.Size(100, 21);
            this.yMaxBox.TabIndex = 15;
            // 
            // IdleRandomActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.duringtimeMaxBox);
            this.Controls.Add(this.duringtimeMinBox);
            this.Controls.Add(this.yMaxBox);
            this.Controls.Add(this.yMinBox);
            this.Controls.Add(this.xMaxBox);
            this.Controls.Add(this.xMinBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IdleRandomActionPanel";
            this.Size = new System.Drawing.Size(253, 165);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox xMinBox;
        private System.Windows.Forms.TextBox xMaxBox;
        private System.Windows.Forms.TextBox yMinBox;
        private System.Windows.Forms.TextBox duringtimeMaxBox;
        private System.Windows.Forms.TextBox duringtimeMinBox;
        private System.Windows.Forms.TextBox yMaxBox;
    }
}
