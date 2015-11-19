using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class ChaseActionNode : ActionNode
    {
        private bool canChase;

        private bool hasBeenChase;

        private int chaseTime;

        public int ChaseTime
        {
            get { return chaseTime; }
            set { chaseTime = value; }
        }

        public bool HasBeenChase
        {
            get { return hasBeenChase; }
            set { hasBeenChase = value; }
        }

        public bool CanChase
        {
            get { return canChase; }
            set { canChase = value; }
        }

        public ChaseActionNode(bool canChase, bool hasBeenChase, int chaseTime)
        {
            this.canChase = canChase;
            this.hasBeenChase = hasBeenChase;
            this.chaseTime = chaseTime;
        }

        public override string GetNodeDesc()
        {
            return "追击行为";
        }
    }
}
