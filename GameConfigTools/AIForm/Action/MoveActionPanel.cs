using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameConfigTools.AIForm.Action;

namespace GameConfigTools.AIForm.Action
{
    public partial class MoveActionPanel : UserControl, BTParam
    {

        public MoveActionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {

            return null;
        }

        public TreeNode GenNode()
        {
            return new MoveNode();
        }

        public void UpdateUI(TreeNode node)
        {

        }

        public void UpdateNode(TreeNode node)
        {

        }
    }
}
