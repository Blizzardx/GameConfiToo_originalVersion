namespace GameConfigTools.AIForm.Action
{
    partial class RunActionPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.runSpeedTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "逃跑速度*10000：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // runSpeedTextBox
            // 
            this.runSpeedTextBox.Location = new System.Drawing.Point(118, 57);
            this.runSpeedTextBox.Name = "runSpeedTextBox";
            this.runSpeedTextBox.Size = new System.Drawing.Size(100, 21);
            this.runSpeedTextBox.TabIndex = 4;
            // 
            // RunActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.runSpeedTextBox);
            this.Controls.Add(this.label2);
            this.Name = "RunActionPanel";
            this.Size = new System.Drawing.Size(238, 137);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox runSpeedTextBox;
    }
}
