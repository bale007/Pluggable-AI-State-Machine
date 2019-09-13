using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bale007.PASM;
namespace Demo
{
    public class AIDecisionDistanceToTarget : AIDecisionNode
    {
        public enum CompareModes { Less, Equal, Greater }

        public Color gimozColour;
        public CompareModes compare;
        public float distance;
        public SharedGameObject target;

        float _distance;

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

        public override bool Decide()
        {
            return CompareDistance();
        }

        public override void OnDrawGimoz()
        {
            base.OnDrawGimoz();

            Gizmos.color = gimozColour;
            Gizmos.DrawWireSphere(brain.transform.position, distance);
        }

        bool CompareDistance()
        {
            if(target.value == null)
            {
                return false;
            }

            _distance = (target.value.transform.position - brain.transform.position).magnitude;

            switch (compare)
            {
                case CompareModes.Equal: return distance == _distance;
                case CompareModes.Less: return distance > _distance;
                case CompareModes.Greater: return distance < _distance;
            }

            return false;
        }
    }
}
