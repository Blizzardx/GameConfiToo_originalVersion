using GameConfigTools.AIForm.Action;
using GameConfigTools.AIForm.Decorator;
using GameConfigTools.Model;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GameConfigTools.AIForm
{
    public partial class EditAIConfigForm : Form
    {
        private TreeNode copyTreeNode;

        public EditAIConfigForm()
        {
            InitializeComponent();
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem == expandAllStripMenuItem)
            {
                treeView1.SelectedNode.ExpandAll();
                return;
            }
            
            //添加节点
            if(e.ClickedItem == addRootToolStripMenuItem1)
            {
                AddBTRootForm addBTForm = new AddBTRootForm(treeView1);
                addBTForm.ShowDialog(this);
                if (addBTForm.RootNode != null)
                {
                    treeView1.Nodes.Add(addBTForm.RootNode);
                }
                return;
            }

            if(e.ClickedItem == addToolStripMenuItem1)
            {
                AddNodeForm addNodeForm = new AddNodeForm(treeView1.SelectedNode, OperType.Add);
                addNodeForm.ShowDialog(this);
                
                return;
            }
            if(e.ClickedItem == updateToolStripMenuItem1)
            {
                AddNodeForm addNodeForm = new AddNodeForm(treeView1.SelectedNode, OperType.Update);
                addNodeForm.ShowDialog(this);
                return;
            }
            if(e.ClickedItem == delToolStripMenuItem1)
            {
                treeView1.SelectedNode.Remove();
                return;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                addToolStripMenuItem1.Enabled = false;
                updateToolStripMenuItem1.Enabled = false;
                delToolStripMenuItem1.Enabled = false;
            }
            else
            {
                addToolStripMenuItem1.Enabled = true;
                updateToolStripMenuItem1.Enabled = true;
                delToolStripMenuItem1.Enabled = true;
            }

            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode != null)
            {
                if (selectNode.Parent == null && selectNode.Nodes.Count > 0)
                {
                    addToolStripMenuItem1.Enabled = false;
                    return;
                }
                else
                {
                    addToolStripMenuItem1.Enabled = true;
                }
                if(selectNode is DecoratorNode)
                {
                    if (selectNode.Nodes.Count > 0)
                    {
                        addToolStripMenuItem1.Enabled = false;
                        return;
                    }
                    else
                    {
                        addToolStripMenuItem1.Enabled = true;
                    }
                }
                
                if (selectNode is ConditionNode)
                {
                    addToolStripMenuItem1.Enabled = false;
                    return;
                }
                else
                {
                    addToolStripMenuItem1.Enabled = true;
                }
                if (selectNode is ActionNode)
                {
                    addToolStripMenuItem1.Enabled = false;
                    return;
                }
                else
                {
                    addToolStripMenuItem1.Enabled = true;
                }
            }
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(treeView1, e.Location);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button != System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }
            treeView1.SelectedNode = e.Node;
            e.Node.Expand();
        }

        private void EditAIConfigForm_Load(object sender, EventArgs e)
        {
            this.SaveAIConfig(new XElement("root"), false);
            try
            {
                XElement root = this.LoadAIConfig();
                this.GenTreeViewDataByXml(root);

            }
            catch (Exception es)
            {
                string msg = es.Message;
                throw;
            }
        }

        /// <summary>
        /// 根据xml生成行为树显示
        /// </summary>
        /// <param name="root"></param>
        public void GenTreeViewDataByXml(XElement root)
        {
            var behaviorTreeEList = root.Elements("behaviorTree");
            if(behaviorTreeEList == null || behaviorTreeEList.Count() == 0)
            {
                return;
            }
            foreach(XElement behaviorTreeE in behaviorTreeEList)
            {
                int id = int.Parse(behaviorTreeE.Attribute("id").Value);
                string desc = behaviorTreeE.Attribute("desc").Value;
                RootNode rootNode = new RootNode(id, desc);
                treeView1.Nodes.Add(rootNode);

                this.GenNode(rootNode, behaviorTreeE);
            }
        }

        private void GenNode(TreeNode parent, XElement btNode)
        {
            var btNodeEList = btNode.Elements("btNode");
            if (btNodeEList == null || btNodeEList.Count() == 0)
            {
                return;
            }
            foreach (XElement btNodeE in btNodeEList)
            {
                TreeNode node = this.GetTreeNode(btNodeE);
                if(node != null)
                {
                    parent.Nodes.Add(node);
                }

                this.GenNode(node, btNodeE);
            }
        }

        private TreeNode GetTreeNode(XElement btNodeE)
        {
            string nodeType = btNodeE.Attribute("nodeType").Value;

            if(nodeType == BTConstants.NODE_TYPE_SELECTOR)
            {
                
                return new SelectorNode();

            }
            else if(nodeType == BTConstants.NODE_TYPE_SEQUENCE)
            {
                return new SequenceNode();
            }
            else if(nodeType == BTConstants.NODE_TYPE_PARALLEL)
            {
                return new ParallelNode();
            }
            else if (nodeType == BTConstants.NODE_TYPE_PARALLEL_SELECTOR)
            {
                return new ParallelSelectorNode();
            }
            else if (nodeType == BTConstants.NODE_TYPE_PARALLEL_SEQUENCE)
            {
                return new ParallelSequenceNode();
            }
            else if(nodeType == BTConstants.NODE_TYPE_PRIORITY_SELECTOR)
            {
                return new PrioritySelectorNode();
            }
            else if (nodeType == BTConstants.NODE_TYPE_DECORATOR)           //装饰节点
            {
                string nodeName = btNodeE.Attribute("name").Value;
                //间隔装饰节点
                if(nodeName == BTConstants.NODE_NAME_INVERTER)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);

                    return new InverterDecoratorNode(int.Parse(dic["interval"]));
                }
                else if (nodeName == BTConstants.Node_NAME_INVERTER_FRAME)
                {

                    Dictionary<string, string> dic = this.GetProperty(btNodeE);

                    return new InverterByframeDecoratorNode(int.Parse(dic["interval"]));
                }
            }
            else if(nodeType == BTConstants.NODE_TYPE_CONDITION)
            {
                Dictionary<string, string> dic = this.GetProperty(btNodeE);
                return new ConditionNode(int.Parse(dic["targetId"]), int.Parse(dic["limitId"]));
            }
            else if(nodeType == BTConstants.NODE_TYPE_ACTION)
            {
                string nodeName = btNodeE.Attribute("name").Value;
                if (nodeName == BTConstants.NODE_NAME_DEAD)
                {
                    return new DeadActionNode();
                }
                else if(nodeName == BTConstants.NODE_NAME_IDLE_STATIC)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("pathid"))
                    {
                        // fix 
                        dic.Add("pathid", "0");
                    }
                    if (!dic.ContainsKey("range"))
                    {
                        // fix 
                        dic.Add("range", "0");
                    }
                    if (!dic.ContainsKey("rate"))
                    {
                        // fix 
                        dic.Add("rate", "0");
                    }
                    return new IdleStaticActionNode
                        (int.Parse(dic["range"]),
                        int.Parse(dic["rate"]),
                        int.Parse(dic["pathid"]));
                }
                else if (nodeName == BTConstants.NODE_NAME_IDLE_REGULARITY)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("pathid"))
                    {
                        // fix 
                        dic.Add("pathid", "0");
                    }
                    if (!dic.ContainsKey("speed"))
                    {
                        // fix 
                        dic.Add("speed", "0");
                    }
                    return new IdleRegualrityActionNode(int.Parse(dic["speed"]),int.Parse(dic["pathid"]));
                }
                else if (nodeName == BTConstants.NODE_NAME_IDLE_RANDOM)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("xspeedmin"))
                    {
                        // fix 
                        dic.Add("xspeedmin", "0");
                    }
                    if (!dic.ContainsKey("xspeedmax"))
                    {
                        // fix 
                        dic.Add("xspeedmax", "0");
                    }
                    if (!dic.ContainsKey("yspeedmin"))
                    {
                        // fix 
                        dic.Add("yspeedmin", "0");
                    }
                    if (!dic.ContainsKey("yspeedmax"))
                    {
                        // fix 
                        dic.Add("yspeedmax", "0");
                    }
                    if (!dic.ContainsKey("timemin"))
                    {
                        // fix 
                        dic.Add("timemin", "0");
                    }
                    if (!dic.ContainsKey("timemax"))
                    {
                        // fix 
                        dic.Add("timemax", "0");
                    }
                    return new IdleRandomActionNode
                           (int.Parse(dic["xspeedmin"]),
                            int.Parse(dic["xspeedmax"]),
                            int.Parse(dic["yspeedmin"]),
                            int.Parse(dic["yspeedmax"]),
                            int.Parse(dic["timemin"]),
                            int.Parse(dic["timemax"]));
                }
                else if(nodeName == BTConstants.NODE_NAME_ATTACK)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("moveSpeed"))
                    {
                        // fix 
                        dic.Add("moveSpeed", "0");
                    }
                    return new AttackActionNode(int.Parse(dic["moveSpeed"]));
                }
                else if (nodeName == BTConstants.NODE_NAME_SKILLATTACK)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("skillid"))
                    {
                        // fix 
                        dic.Add("skillid", "0");
                    }
                    return new SkillAttackActionNode(int.Parse(dic["skillid"]));
                }
                else if (nodeName == BTConstants.NODE_NAME_RUN)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("moveSpeed"))
                    {
                        // fix 
                        dic.Add("moveSpeed", "0");
                    }
                    return new RunActionNode(int.Parse(dic["moveSpeed"]));
                }
                else if (nodeName == BTConstants.Node_Name_MOVE)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("pathid"))
                    {
                        // fix 
                        dic.Add("pathid", "0");
                    }
                    if (!dic.ContainsKey("moveSpeed"))
                    {
                        // fix 
                        dic.Add("moveSpeed", "0");
                    }
                    return new MoveActionNode(int.Parse(dic["moveSpeed"]), int.Parse(dic["pathid"]));
                }
                else if (nodeName == BTConstants.NODE_NAME_JUMPTO)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    if (!dic.ContainsKey("moveSpeed"))
                    {
                        // fix 
                        dic.Add("moveSpeed", "0");
                    }
                    if (!dic.ContainsKey("grivity"))
                    {
                        // fix 
                        dic.Add("grivity", "0");
                    }
                    return new JumpToActionNode(int.Parse(dic["moveSpeed"]), int.Parse(dic["grivity"]));
                }
            }
            return null;
        }

        private Dictionary<string, string> GetProperty(XElement btNodeE)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var propertyEList = btNodeE.Elements("property");
            if (propertyEList == null || propertyEList.Count() == 0)
            {
                return dic;
            }
            foreach(XElement propertyE in propertyEList)
            {
                dic.Add(propertyE.Attribute("key").Value, propertyE.Attribute("value").Value);
            }
            return dic;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            XElement root = new XElement("root");
            if(treeView1.Nodes.Count > 0)
            {
                foreach(TreeNode node in treeView1.Nodes)
                {
                    RootNode rootNode = node as RootNode;
                    XElement behaviorTreeE = new XElement("behaviorTree");
                    root.Add(behaviorTreeE);
                    behaviorTreeE.Add(new XAttribute("id", rootNode.Id));
                    behaviorTreeE.Add(new XAttribute("desc", rootNode.Desc));

                    if(rootNode.Nodes.Count > 0)
                    {
                        this.GenXml(rootNode, behaviorTreeE);
                    }
                }
            }
            this.SaveAIConfig(root, true);
            MessageBox.Show("保存AI配置到本地成功");
        }

        private void GenXml(TreeNode parent, XElement btNodeE)
        {
            if (parent.Nodes.Count == 0)
            {
                return;
            }
            foreach(TreeNode node in parent.Nodes)
            {
                XElement xe = new XElement("btNode");
                btNodeE.Add(xe);

                if(node is SelectorNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_SELECTOR));
                }
                else if(node is SequenceNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_SEQUENCE));
                }
                else if (node is ParallelSequenceNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_PARALLEL_SEQUENCE));
                }
                else if (node is ParallelSelectorNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_PARALLEL_SELECTOR));
                }
                else if (node is ParallelNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_PARALLEL));
                }
                else if(node is PrioritySelectorNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_PRIORITY_SELECTOR));
                }
                else if(node is DecoratorNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_DECORATOR));
                    if(node is InverterDecoratorNode)
                    {
                        InverterDecoratorNode n = node as InverterDecoratorNode;
                        
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_INVERTER));
                        xe.Add(this.GetPropertyElement("interval", n.Interval));
                    }
                    else if (node is InverterByframeDecoratorNode)
                    {
                        InverterByframeDecoratorNode n = node as InverterByframeDecoratorNode;

                        xe.Add(new XAttribute("name", BTConstants.Node_NAME_INVERTER_FRAME));
                        xe.Add(this.GetPropertyElement("interval", n.Interval));
                    }
                }
                else if(node is ConditionNode)
                {
                    ConditionNode n = node as ConditionNode;
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_CONDITION));
                    xe.Add(this.GetPropertyElement("targetId", n.TargetId));
                    xe.Add(this.GetPropertyElement("limitId", n.LimitId));
                }
                else if(node is ActionNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_ACTION));
                    if (node is DeadActionNode)
                    {
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_DEAD));
                    }
                    else if(node is IdleStaticActionNode)
                    {
                        IdleStaticActionNode n = node as IdleStaticActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_IDLE_STATIC));
                        xe.Add(this.GetPropertyElement("range", n.m_iRange));
                        xe.Add(this.GetPropertyElement("rate", n.m_iRate));
                        xe.Add(this.GetPropertyElement("pathid", n.m_iPositionId));
                    }
                    else if (node is IdleRandomActionNode)
                    {
                        IdleRandomActionNode n = node as IdleRandomActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_IDLE_RANDOM));
                        xe.Add(this.GetPropertyElement("xspeedmin", n.m_iMinX));
                        xe.Add(this.GetPropertyElement("xspeedmax", n.m_iMaxX));
                        xe.Add(this.GetPropertyElement("yspeedmin", n.m_iMinY));
                        xe.Add(this.GetPropertyElement("yspeedmax", n.m_iMaxY));
                        xe.Add(this.GetPropertyElement("timemin", n.m_iMinDuringTime));
                        xe.Add(this.GetPropertyElement("timemax", n.m_iMaxDuringTime));
                    }
                    else if (node is IdleRegualrityActionNode)
                    {
                        IdleRegualrityActionNode n = node as IdleRegualrityActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_IDLE_REGULARITY));
                        xe.Add(this.GetPropertyElement("speed", n.m_iSpeed));
                        xe.Add(this.GetPropertyElement("pathid", n.m_iPathId));
                    }
                    else if(node is AttackActionNode)
                    {
                        AttackActionNode n = node as AttackActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_ATTACK));
                        xe.Add(this.GetPropertyElement("moveSpeed", n.m_iSpeed));
                    }
                    else if (node is SkillAttackActionNode)
                    {
                        SkillAttackActionNode n = node as SkillAttackActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_SKILLATTACK));
                        xe.Add(this.GetPropertyElement("skillid", n.m_iSkillId));
                    }
                    else if (node is RunActionNode)
                    {
                        RunActionNode n = node as RunActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_RUN));
                        xe.Add(this.GetPropertyElement("moveSpeed", n.m_iRunSpeed));
                    }
                    else if (node is MoveActionNode)
                    {
                        MoveActionNode n = node as MoveActionNode;
                        xe.Add(new XAttribute("name", BTConstants.Node_Name_MOVE));
                        xe.Add(this.GetPropertyElement("pathid", n.m_iPathId));
                        xe.Add(this.GetPropertyElement("moveSpeed", n.m_iMoveSpeed));
                    }
                    else if (node is JumpToActionNode)
                    {
                        JumpToActionNode n = node as JumpToActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_JUMPTO));
                        xe.Add(this.GetPropertyElement("moveSpeed", n.m_iSpeed));
                        xe.Add(this.GetPropertyElement("grivity", n.m_iGrivity));
                    }
                }

                if(node.Nodes.Count > 0)
                {
                    this.GenXml(node, xe);
                }
            }
        }

        private XElement GetPropertyElement(string key, object value)
        {
            XElement e = new XElement("property");
            e.Add(new XAttribute("key", key));
            e.Add(new XAttribute("value", value));
            return e;
        }

        private void SaveAIConfig(XElement root, bool force)
        {
            SysConfig config = Context.instance.GetSysConfig();

            string filePath = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\aiConfig.xml";
            if (!File.Exists(filePath) || force)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    XmlWriterSettings setting = new XmlWriterSettings();
                    setting.Indent = true;
                    setting.IndentChars = "\t";
                    setting.NewLineChars = "\n";
                    setting.Encoding = Encoding.UTF8;
                    using (XmlWriter xw = XmlWriter.Create(fs, setting))
                    {
                        root.WriteTo(xw);
                    }
                }
            }
        }

        private XElement LoadAIConfig()
        {
            SysConfig config = Context.instance.GetSysConfig();

            string filePath = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\aiConfig.xml";

            return XElement.Load(filePath);
        }

        private bool CanAddNode(TreeNode source, TreeNode target)
        {

            return true;
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if(selectNode == null)
            {
                MessageBox.Show(this, "请先选择要移动的节点", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNode parent = selectNode.Parent;
            int currIndex = selectNode.Index;
            if (currIndex == 0)
            {
                treeView1.Focus();
                return;
            }
            selectNode.Remove();
            parent.Nodes.Insert(currIndex - 1, selectNode);
            treeView1.SelectedNode = selectNode;
            treeView1.Focus();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode == null)
            {
                MessageBox.Show(this, "请先选择要移动的节点", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNode parent = selectNode.Parent;
            if(selectNode.NextNode == null)
            {
                treeView1.Focus();
                return;
            }
            int currIndex = selectNode.Index;
            selectNode.Remove();
            parent.Nodes.Insert(currIndex + 1, selectNode);
            treeView1.SelectedNode = selectNode;
            treeView1.Focus();
        }
    }
}
