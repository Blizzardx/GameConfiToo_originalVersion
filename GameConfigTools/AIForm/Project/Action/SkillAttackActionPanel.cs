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
    public partial class SkillAttackActionPanel : UserControl, BTParam
    {
        public int m_iSkillId;

        public SkillAttackActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(skillIdTextBox.Text, out m_iSkillId))
            {
                return "技能id必须为整形";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new SkillAttackActionNode(m_iSkillId);
        }

        public void UpdateUI(TreeNode node)
        {
            SkillAttackActionNode action = node as SkillAttackActionNode;
            m_iSkillId = action.m_iSkillId;
            skillIdTextBox.Text = m_iSkillId.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            SkillAttackActionNode action = node as SkillAttackActionNode;
            m_iSkillId = int.Parse(skillIdTextBox.Text);
            action.m_iSkillId = m_iSkillId;
        }
    }
}
