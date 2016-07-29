using GameConfigTools.AIForm.Action;
using GameConfigTools.AIForm.Composite;
using GameConfigTools.AIForm.Condition;
using GameConfigTools.AIForm.Decorator;
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

    public enum OperType
    {
        Add,
        Update
    }

    public partial class AddNodeForm : Form
    {
        private TreeNode parent;

        private BTParam btParam;

        private OperType operType;

        public AddNodeForm(TreeNode parent, OperType operType)
        {
            InitializeComponent();
            this.parent = parent;
            this.operType = operType;
        }

        private void AddNodeForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void nodeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodeNameComboBox.Items.Clear();
            int selectIndex = nodeTypeComboBox.SelectedIndex;
            if (selectIndex == -1)
            {
                return;
            }
            string[] items = BTConstants.NODE_NAMES[selectIndex];
            if (items.Length == 0)
            {
                return;
            }
            nodeNameComboBox.Items.AddRange(items);
            if (operType == OperType.Update)
            {
                int index = 0;
                foreach (var item in nodeNameComboBox.Items)
                {
                    if (parent is BTNode)
                    {
                        BTNode n = parent as BTNode;
                        if (item as string == n.GetNodeDesc())
                        {
                            nodeNameComboBox.SelectedIndex = index;
                            break;
                        }
                    }
                    index++;
                }
            }
            else
            {
                nodeNameComboBox.SelectedIndex = 0;
            }
        }

        private void nodeNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            btParam = null;
            int selectIndex = nodeTypeComboBox.SelectedIndex;
            if (selectIndex == -1)
            {
                return;
            }
            
            int selectNodeNameIndex = nodeNameComboBox.SelectedIndex;
            if (selectNodeNameIndex == -1)
            {
                return;
            }
            switch(selectIndex)
            {
                case 0:
                    {
                        if (selectNodeNameIndex == 0)
                        {
                            this.AddParamPanelToGroupBox(new SelectorPanel());
                        }
                        else if (selectNodeNameIndex == 1)
                        {
                            this.AddParamPanelToGroupBox(new SequencePanel());
                        }
                        else if (selectNodeNameIndex == 2)
                        {
                            this.AddParamPanelToGroupBox(new ParallelPanel());
                        }
                        else if(selectNodeNameIndex == 3)
                        {
                            this.AddParamPanelToGroupBox(new PrioritySelectorPanel());
                        }
                        break;
                    }
                case 1:
                    {
                        int index = 0;
                        if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new InverterDecoratorPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new InverterByframeDecoratorPanel());
                        }
                        break;
                    }
                case 2:   //条件
                    {
                        this.AddParamPanelToGroupBox(new ConditionPanel());
                        break;
                    }
                case 3:   //行为
                    {
                        int index = 0;
                        if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new DeadActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            AddParamPanelToGroupBox(new SkillAttackActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new RunActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new AttackActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new IdleStaticActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new IdleRegularityActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new IdleRandomActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new MoveActionPanel());
                        }
                        else if (selectNodeNameIndex == index++)
                        {
                            this.AddParamPanelToGroupBox(new JumptoActionPanel());
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 添加参数面板
        /// </summary>
        public void AddParamPanelToGroupBox(UserControl panel)
        {
            btParam = panel as BTParam;
            if (operType == OperType.Update)
            {
                btParam.UpdateUI(parent);
            }
            groupBox1.Controls.Add(panel);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(nodeTypeComboBox.SelectedIndex == -1 || nodeNameComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, "必须选择节点类型", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(operType == OperType.Add)
            {
                if (parent is RootNode)
                {
                    if (nodeTypeComboBox.SelectedIndex == 2 || nodeTypeComboBox.SelectedIndex == 3)
                    {
                        MessageBox.Show(this, "root节点下只能添加复合节点或者装饰节点", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //验证参数
                if (btParam != null)
                {          
                    string errMsg = btParam.ValidateParam();
                    if (errMsg != null)
                    {
                        MessageBox.Show(this, errMsg, "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    TreeNode node = btParam.GenNode();
                    parent.Nodes.Add(node);
                    parent.ExpandAll();
                }
            }
            else
            {
                if (btParam != null)
                {
                    string errMsg = btParam.ValidateParam();
                    if (errMsg != null)
                    {
                        MessageBox.Show(this, errMsg, "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    btParam.UpdateNode(parent);
                }
            }
            this.Dispose();
        }

        private void AddNodeForm_Load(object sender, EventArgs e)
        {
            if(operType == OperType.Update)
            {
                addButton.Text = "修改";
                
                if(parent is CompositeNode)
                {
                    nodeTypeComboBox.SelectedIndex = 0;
                }
                else if(parent is DecoratorNode)
                {
                    nodeTypeComboBox.SelectedIndex = 1;
                }
                else if(parent is ConditionNode)
                {
                    nodeTypeComboBox.SelectedIndex = 2;
                }
                else if(parent is ActionNode)
                {
                    nodeTypeComboBox.SelectedIndex = 3;
                }
                nodeTypeComboBox.Enabled = false;
                nodeNameComboBox.Enabled = false;
            }
            else
            {
                addButton.Text = "添加";
            }
        }
    }
}
