using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class AIActionLookAtTarget : AIActionNode
    {
        public string TargetTag;


        GameObject _target;

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            _target = GameObject.FindGameObjectWithTag(TargetTag);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            _target = null;
        }

        public override void Tick()
        {
            LookAtTarget();
        }

        void LookAtTarget()
        {
            if(_target == null)
            {
                return;
            }

            brain.transform.LookAt(_target.transform);
        }



    }

}
