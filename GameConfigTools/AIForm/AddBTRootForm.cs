using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm
{
    public partial class AddBTRootForm : Form
    {
        private TreeView parent;
        private TreeNode rootNode;
        public TreeNode RootNode
        {
            get { return rootNode; }
        }

        public AddBTRootForm(TreeView parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if(!int.TryParse(idTextBox.Text.Trim(), out id))
            {
                MessageBox.Show(this, "方案ID必须为整型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (TreeNode node in parent.Nodes)
            {
                RootNode rn = node as RootNode;
                if(rn.Id == id)
                {
                    MessageBox.Show(this, "方案ID重复", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string desc = descTextBox.Text.Trim();
            rootNode = new RootNode(id, desc);
            this.Dispose();
        }

        private void AddBTRootForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
