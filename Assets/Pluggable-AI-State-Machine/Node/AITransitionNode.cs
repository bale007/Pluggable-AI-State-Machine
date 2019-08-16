using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[NodeTint("#c0392b")]
public class AITransitionNode : AINode
{
    [Input] public TransitionPort Decision;

    public string StateName;
}
