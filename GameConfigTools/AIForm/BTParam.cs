using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm
{
    public interface BTParam
    {
        string ValidateParam();

        TreeNode GenNode();

        void UpdateUI(TreeNode node);

        void UpdateNode(TreeNode node);
    }
}
