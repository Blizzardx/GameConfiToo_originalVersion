namespace GameConfigTools.AIForm.Action
{
    partial class IdleRegularityActionPanel
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
            this.moveSpeedBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pathIdBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // moveSpeedBox
            // 
            this.moveSpeedBox.Location = new System.Drawing.Point(96, 68);
            this.moveSpeedBox.Name = "moveSpeedBox";
            this.moveSpeedBox.Size = new System.Drawing.Size(100, 21);
            this.moveSpeedBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "移动速度*1000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pathIdBox
            // 
            this.pathIdBox.Location = new System.Drawing.Point(101, 95);
            this.pathIdBox.Name = "pathIdBox";
            this.pathIdBox.Size = new System.Drawing.Size(100, 21);
            this.pathIdBox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "路径方案ID：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IdleRegularityActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pathIdBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.moveSpeedBox);
            this.Controls.Add(this.label1);
            this.Name = "IdleRegularityActionPanel";
            this.Size = new System.Drawing.Size(218, 154);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox moveSpeedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathIdBox;
        private System.Windows.Forms.Label label2;
    }
}
