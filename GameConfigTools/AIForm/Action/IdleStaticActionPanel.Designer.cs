namespace GameConfigTools.AIForm.Action
{
    partial class IdleStaticActionPanel
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
            this.rangeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rateBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.positionIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rangeBox
            // 
            this.rangeBox.Location = new System.Drawing.Point(101, 29);
            this.rangeBox.Name = "rangeBox";
            this.rangeBox.Size = new System.Drawing.Size(100, 21);
            this.rangeBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "浮动幅度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rateBox
            // 
            this.rateBox.Location = new System.Drawing.Point(101, 62);
            this.rateBox.Name = "rateBox";
            this.rateBox.Size = new System.Drawing.Size(100, 21);
            this.rateBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "浮动频率";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // positionIdBox
            // 
            this.positionIdBox.Location = new System.Drawing.Point(101, 97);
            this.positionIdBox.Name = "positionIdBox";
            this.positionIdBox.Size = new System.Drawing.Size(100, 21);
            this.positionIdBox.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "目标点ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IdleStaticActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.positionIdBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rateBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeBox);
            this.Controls.Add(this.label1);
            this.Name = "IdleStaticActionPanel";
            this.Size = new System.Drawing.Size(213, 157);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rangeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox positionIdBox;
        private System.Windows.Forms.Label label3;
    }
}
