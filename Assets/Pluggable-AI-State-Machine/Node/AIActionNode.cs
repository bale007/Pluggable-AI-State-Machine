using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeTint("#27ae60")]
public abstract class AIActionNode : AINode
{
    [Input]public ActionPort ConnectedState;

    public abstract void Tick();

}