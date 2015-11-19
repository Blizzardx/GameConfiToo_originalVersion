namespace GameConfigTools.AIForm
{
    partial class AddNodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nodeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.nodeNameComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nodeTypeComboBox
            // 
            this.nodeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nodeTypeComboBox.FormattingEnabled = true;
            this.nodeTypeComboBox.Items.AddRange(new object[] {
            "复合节点",
            "装饰节点",
            "条件节点",
            "行为节点"});
            this.nodeTypeComboBox.Location = new System.Drawing.Point(12, 12);
            this.nodeTypeComboBox.Name = "nodeTypeComboBox";
            this.nodeTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.nodeTypeComboBox.TabIndex = 0;
            this.nodeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.nodeTypeComboBox_SelectedIndexChanged);
            // 
            // nodeNameComboBox
            // 
            this.nodeNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nodeNameComboBox.FormattingEnabled = true;
            this.nodeNameComboBox.Items.AddRange(new object[] {
            "复合节点",
            "装饰节点",
            "条件节点",
            "行为节点"});
            this.nodeNameComboBox.Location = new System.Drawing.Point(169, 12);
            this.nodeNameComboBox.Name = "nodeNameComboBox";
            this.nodeNameComboBox.Size = new System.Drawing.Size(133, 20);
            this.nodeNameComboBox.TabIndex = 1;
            this.nodeNameComboBox.SelectedIndexChanged += new System.EventHandler(this.nodeNameComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 241);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(165, 296);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "添加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 331);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nodeNameComboBox);
            this.Controls.Add(this.nodeTypeComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加节点";
            this.Load += new System.EventHandler(this.AddNodeForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddNodeForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox nodeTypeComboBox;
        private System.Windows.Forms.ComboBox nodeNameComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addButton;
    }
}