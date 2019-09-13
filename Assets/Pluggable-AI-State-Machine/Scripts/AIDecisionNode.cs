using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Bale007.PASM
{
    [NodeTint("#f39c12")]
    [NodeWidth(300)]
    public abstract class AIDecisionNode : AINode
    {
        [Input] public DecisionPort ConnectedState;

        [Output] public TransitionPort True;
        [Output] public TransitionPort False;

        AITransitionNode node;

        public bool CheckTransition()
        {
            if (Decide() == true)
            {
                node = GetNode<AITransitionNode>("True", Port.Output);
            }
            else
            {
                node = GetNode<AITransitionNode>("False", Port.Output);
            }

            if (node != null)
            {
                (graph as AIBevaiourGraph).ChangeState(node.StateName);

                return true;
            }

            return false;
        }

        public abstract bool Decide();
    }
}
