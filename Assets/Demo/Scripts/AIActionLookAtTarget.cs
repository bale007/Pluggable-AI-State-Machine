using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bale007.PASM;
namespace Demo
{
    public class AIActionLookAtTarget : AIActionNode
    {
        public SharedGameObject target;

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            target.Init(brain);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            target.Dispose();
        }

        public override void Tick()
        {
            LookAtTarget();
        }

        void LookAtTarget()
        {
            if(target.value == null)
            {
                return;
            }

            brain.transform.LookAt(target.value.transform);
        }



    }

}
