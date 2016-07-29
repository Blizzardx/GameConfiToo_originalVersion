namespace GameConfigTools.AIForm.Action
{
    partial class MoveActionPanel
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
            this.PathIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.movespeedBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PathIdTextBox
            // 
            this.PathIdTextBox.Location = new System.Drawing.Point(114, 95);
            this.PathIdTextBox.Name = "PathIdTextBox";
            this.PathIdTextBox.Size = new System.Drawing.Size(100, 21);
            this.PathIdTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "移动路径id：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // movespeedBox
            // 
            this.movespeedBox.Location = new System.Drawing.Point(114, 129);
            this.movespeedBox.Name = "movespeedBox";
            this.movespeedBox.Size = new System.Drawing.Size(100, 21);
            this.movespeedBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "移动速度*10000：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoveActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.movespeedBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathIdTextBox);
            this.Controls.Add(this.label2);
            this.Name = "MoveActionPanel";
            this.Size = new System.Drawing.Size(230, 209);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathIdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox movespeedBox;
        private System.Windows.Forms.Label label1;
    }
}
