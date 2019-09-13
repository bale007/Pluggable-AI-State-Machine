using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bale007.PASM;
namespace Demo
{
    public class AIActionFleeFromTarget : AIActionNode
    {
        public SharedGameObject target;
        public float moveSpeed;

        Vector3 _movement;
        Vector3 _pos;

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
            Flee();
        }

        void Flee()
        {
            if (target.value == null)
            {
                return;
            }

            _movement = -1 * (target.value.transform.position - brain.transform.position).normalized;

            _pos = brain.transform.position;

            _pos += _movement * moveSpeed * Time.deltaTime;

            brain.transform.position = _pos;
        }
    }

}
