using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class AIDecisionDistanceToTarget : AIDecisionNode
    {
        public enum CompareModes { Less, Equal, Greater }

        public Color GizmoColour;
        public CompareModes Compare;
        public float Distance;
        public string TargetTag;

        GameObject _target;
        float _distance;

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

        public override bool Decide()
        {
            return CompareDistance();
        }

        public override void OnDrawGimoz()
        {
            base.OnDrawGimoz();

            Gizmos.color = GizmoColour;
            Gizmos.DrawWireSphere(brain.transform.position, Distance);
        }

        bool CompareDistance()
        {
            if(_target == null)
            {
                return false;
            }

            _distance = (_target.transform.position - brain.transform.position).magnitude;

            switch (Compare)
            {
                case CompareModes.Equal: return Distance == _distance;
                case CompareModes.Less: return Distance > _distance;
                case CompareModes.Greater: return Distance < _distance;
            }

            return false;
        }
    }
}
