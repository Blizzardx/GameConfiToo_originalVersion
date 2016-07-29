using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm.Action
{
    public partial class DeadActionPanel : UserControl, BTParam
    {
        public DeadActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            return null;
        }

        public TreeNode GenNode()
        {
            return new DeadActionNode();
        }

        public void UpdateUI(TreeNode node)
        {
        }

        public void UpdateNode(TreeNode node)
        {
        }
    }
}
