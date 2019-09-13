using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Bale007.PASM
{
    [NodeTint("#27ae60")]
    [NodeWidth(300)]
    public abstract class AIActionNode : AINode
    {
        [Input] public ActionPort ConnectedState;

        public abstract void Tick();

    }
}
