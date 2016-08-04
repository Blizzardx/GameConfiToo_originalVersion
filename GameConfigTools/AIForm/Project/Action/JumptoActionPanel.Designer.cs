namespace GameConfigTools.AIForm.Action
{
    partial class JumptoActionPanel
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
            this.MoveSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GrivityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MoveSpeedTextBox
            // 
            this.MoveSpeedTextBox.Location = new System.Drawing.Point(136, 70);
            this.MoveSpeedTextBox.Name = "MoveSpeedTextBox";
            this.MoveSpeedTextBox.Size = new System.Drawing.Size(100, 21);
            this.MoveSpeedTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(38, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "跃起初速度：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GrivityTextBox
            // 
            this.GrivityTextBox.Location = new System.Drawing.Point(141, 102);
            this.GrivityTextBox.Name = "GrivityTextBox";
            this.GrivityTextBox.Size = new System.Drawing.Size(100, 21);
            this.GrivityTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(43, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "重力加速度：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // JumptoActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrivityTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MoveSpeedTextBox);
            this.Controls.Add(this.label2);
            this.Name = "JumptoActionPanel";
            this.Size = new System.Drawing.Size(284, 223);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MoveSpeedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GrivityTextBox;
        private System.Windows.Forms.Label label1;
    }
}
