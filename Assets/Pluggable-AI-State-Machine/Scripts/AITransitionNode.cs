using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bale007.PASM
{
    [NodeTint("#c0392b")]
    [NodeWidth(300)]
    public class AITransitionNode : AINode
    {
        [Input] public TransitionPort Decision;

        public string StateName;
    }

}
