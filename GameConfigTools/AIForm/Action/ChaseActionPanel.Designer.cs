namespace GameConfigTools.AIForm.Action
{
    partial class ChaseActionPanel
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.canChaseCheckBox = new System.Windows.Forms.CheckBox();
            this.hasBeenChaseCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chaseTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canChaseCheckBox
            // 
            this.canChaseCheckBox.AutoSize = true;
            this.canChaseCheckBox.Location = new System.Drawing.Point(32, 15);
            this.canChaseCheckBox.Name = "canChaseCheckBox";
            this.canChaseCheckBox.Size = new System.Drawing.Size(96, 16);
            this.canChaseCheckBox.TabIndex = 0;
            this.canChaseCheckBox.Text = "是否可以追击";
            this.canChaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // hasBeenChaseCheckBox
            // 
            this.hasBeenChaseCheckBox.AutoSize = true;
            this.hasBeenChaseCheckBox.Location = new System.Drawing.Point(29, 38);
            this.hasBeenChaseCheckBox.Name = "hasBeenChaseCheckBox";
            this.hasBeenChaseCheckBox.Size = new System.Drawing.Size(84, 16);
            this.hasBeenChaseCheckBox.TabIndex = 1;
            this.hasBeenChaseCheckBox.Text = "是否一直追";
            this.hasBeenChaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chaseTimeTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.hasBeenChaseCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置可以追击后，以下配置才生效";
            // 
            // chaseTimeTextBox
            // 
            this.chaseTimeTextBox.Location = new System.Drawing.Point(130, 72);
            this.chaseTimeTextBox.Name = "chaseTimeTextBox";
            this.chaseTimeTextBox.Size = new System.Drawing.Size(100, 21);
            this.chaseTimeTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(27, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "追击时间(毫秒):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChaseActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canChaseCheckBox);
            this.Name = "ChaseActionPanel";
            this.Size = new System.Drawing.Size(274, 170);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox canChaseCheckBox;
        private System.Windows.Forms.CheckBox hasBeenChaseCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox chaseTimeTextBox;
        private System.Windows.Forms.Label label2;



    }
}
