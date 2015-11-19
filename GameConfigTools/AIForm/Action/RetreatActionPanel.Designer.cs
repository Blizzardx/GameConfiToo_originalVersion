namespace GameConfigTools.AIForm.Action
{
    partial class RetreatActionPanel
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
            this.rangeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxCountTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rangeTextBox
            // 
            this.rangeTextBox.Location = new System.Drawing.Point(139, 45);
            this.rangeTextBox.Name = "rangeTextBox";
            this.rangeTextBox.Size = new System.Drawing.Size(100, 21);
            this.rangeTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "逃跑距离(厘米):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maxCountTextBox
            // 
            this.maxCountTextBox.Location = new System.Drawing.Point(139, 11);
            this.maxCountTextBox.Name = "maxCountTextBox";
            this.maxCountTextBox.Size = new System.Drawing.Size(100, 21);
            this.maxCountTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "最多逃跑次数:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RetreatActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.maxCountTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeTextBox);
            this.Controls.Add(this.label2);
            this.Name = "RetreatActionPanel";
            this.Size = new System.Drawing.Size(274, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rangeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxCountTextBox;
        private System.Windows.Forms.Label label1;

    }
}
