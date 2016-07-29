using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class SkillAttackActionNode : ActionNode
    {
        public int m_iSkillId;

        public SkillAttackActionNode(int skillId)
        {
            m_iSkillId = skillId;
        }
        public override string GetNodeDesc()
        {
            return "技能攻击节点";
        }
    }
}
