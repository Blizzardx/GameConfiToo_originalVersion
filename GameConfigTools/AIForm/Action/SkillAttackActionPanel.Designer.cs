namespace GameConfigTools.AIForm.Action
{
    partial class SkillAttackActionPanel
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
            this.skillIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // skillIdTextBox
            // 
            this.skillIdTextBox.Location = new System.Drawing.Point(101, 67);
            this.skillIdTextBox.Name = "skillIdTextBox";
            this.skillIdTextBox.Size = new System.Drawing.Size(100, 21);
            this.skillIdTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "技能id";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SkillAttackActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skillIdTextBox);
            this.Controls.Add(this.label2);
            this.Name = "SkillAttackActionPanel";
            this.Size = new System.Drawing.Size(204, 152);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox skillIdTextBox;
        private System.Windows.Forms.Label label2;
    }
}
