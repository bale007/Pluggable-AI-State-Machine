﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class AIActionFleeFromTarget : AIActionNode
    {
        public string TargetTag;
        public float MoveSpeed;

        GameObject _target;
        Vector3 _movement;
        Vector3 _pos;

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
            Flee();
        }

        void Flee()
        {
            if (_target == null)
            {
                return;
            }

            _movement = -1 * (_target.transform.position - brain.transform.position).normalized;

            _pos = brain.transform.position;

            _pos += _movement * MoveSpeed * Time.deltaTime;

            brain.transform.position = _pos;
        }
    }

}
