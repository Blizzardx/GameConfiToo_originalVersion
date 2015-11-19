using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm
{
    public abstract class BTNode : TreeNode
    {
        public BTNode()
        {
            Text = GetNodeDesc();
        }

        public abstract string GetNodeDesc();
    }
}
