﻿namespace GameConfigTools.AIForm.Decorator
{
    partial class InverterDecoratorPanel
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
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(134, 33);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(100, 21);
            this.intervalTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(31, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "间隔时间(毫秒):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InverterDecoratorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.intervalTextBox);
            this.Controls.Add(this.label2);
            this.Name = "InverterDecoratorPanel";
            this.Size = new System.Drawing.Size(274, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label label2;

    }
}
