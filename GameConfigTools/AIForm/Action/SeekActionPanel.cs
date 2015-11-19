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
    public partial class SeekActionPanel : UserControl, BTParam
    {
        private int range;

        private int type;

        public SeekActionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            if (!int.TryParse(rangeTextBox.Text.Trim(), out range))
            {
                return "寻敌范围必须为整型";
            }
            if (typeComboBox.SelectedIndex == -1)
            {
                return "请选择寻敌类型";
            }
            type = typeComboBox.SelectedIndex;
            return null;
        }

        public TreeNode GenNode()
        {
            return new SeekActionNode(range, type);
        }

        public void UpdateUI(TreeNode node)
        {
            SeekActionNode n = node as SeekActionNode;
            rangeTextBox.Text = n.Range.ToString();
            typeComboBox.SelectedIndex = n.Type;
        }

        public void UpdateNode(TreeNode node)
        {
            SeekActionNode n = node as SeekActionNode;
            n.Range = range;
            n.Type = type;
        }
    }
}
