using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm.Condition
{
    public partial class ConditionPanel : UserControl, BTParam
    {
        private int targetId = -1;
        private int limitId = -1;

        public ConditionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            if(!int.TryParse(targetIdTextBox.Text.Trim(), out targetId))
            {
                return "目标函数ID必须为整型";
            }
            if (!int.TryParse(limitIdTextBox.Text.Trim(), out limitId))
            {
                return "条件函数ID必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new ConditionNode(targetId, limitId);
        }

        public void UpdateUI(TreeNode node)
        {
            ConditionNode cn = node as ConditionNode;
            targetIdTextBox.Text = cn.TargetId.ToString();
            limitIdTextBox.Text = cn.LimitId.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            ConditionNode cn = node as ConditionNode;
            cn.TargetId = targetId;
            cn.LimitId = limitId;
        }
    }
}
