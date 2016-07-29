using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Decorator
{
    public class InverterDecoratorNode : DecoratorNode
    {
        private int interval;

        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public InverterDecoratorNode(int interval)
        {
            this.interval = interval;
        }

        public override string GetNodeDesc()
        {
            return "间隔时间装饰节点";
        }
    }
}
