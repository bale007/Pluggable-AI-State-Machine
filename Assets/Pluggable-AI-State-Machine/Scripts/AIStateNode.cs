using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Bale007.PASM
{
    [NodeTint("#2980b9")]
    [NodeWidth(300)]
    public class AIStateNode : AINode
    {
        public string StateName;
        [Multiline] public string Desctiption;
        public bool IsEntryState;

        public float ActionFrequency = 0f;
        public float DecisionFrequency = 1f;

        [Output] public ActionPort Action1;
        [Output] public ActionPort Action2;
        [Output] public ActionPort Action3;
        [Output] public DecisionPort Decision1;
        [Output] public DecisionPort Decision2;
        [Output] public DecisionPort Decision3;

        float lastActionTimestamp;
        float lastDecisionTimestamp;
        List<AIActionNode> actions = new List<AIActionNode>();
        List<AIDecisionNode> decisions = new List<AIDecisionNode>();

        public override void BuildConnection(AIBrain brain)
        {
            base.BuildConnection(brain);

            FecthAllConnectedNode();
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            lastActionTimestamp = Time.time;
            lastDecisionTimestamp = Time.time;

            foreach (AIActionNode node in actions)
            {
                node.OnStateEnter();
            }

            foreach (AIDecisionNode node in decisions)
            {
                node.OnStateEnter();
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            foreach (AIActionNode node in actions)
            {
                node.OnStateExit();
            }

            foreach (AIDecisionNode node in decisions)
            {
                node.OnStateExit();
            }
        }

        public virtual void Tick()
        {
            if (Time.time - lastActionTimestamp >= ActionFrequency)
            {
                PerformActions();

                lastActionTimestamp = Time.time;
            }

            if (Time.time - lastDecisionTimestamp >= DecisionFrequency)
            {
                EvaluateConditions();

                lastDecisionTimestamp = Time.time;
            }
        }

        protected virtual void PerformActions()
        {
            foreach (AIActionNode node in actions)
            {
                node.Tick();
            }
        }

        protected virtual void EvaluateConditions()
        {
            foreach (AIDecisionNode node in decisions)
            {
                if (node.CheckTransition() == true)
                {
                    return;
                }
            }
        }

        protected virtual void FecthAllConnectedNode()
        {

            AIActionNode node1 = null;
            AIDecisionNode node2 = null;

            actions.Clear();
            decisions.Clear();

            node1 = GetNode<AIActionNode>("Action1", Port.Output);
            if (node1 != null) actions.Add(node1);

            node1 = GetNode<AIActionNode>("Action2", Port.Output);
            if (node1 != null) actions.Add(node1);

            node1 = GetNode<AIActionNode>("Action3", Port.Output);
            if (node1 != null) actions.Add(node1);

            node2 = GetNode<AIDecisionNode>("Decision1", Port.Output);
            if (node2 != null) decisions.Add(node2);

            node2 = GetNode<AIDecisionNode>("Decision2", Port.Output);
            if (node2 != null) decisions.Add(node2);

            node2 = GetNode<AIDecisionNode>("Decision3", Port.Output);
            if (node2 != null) decisions.Add(node2);
        }
    }

}
