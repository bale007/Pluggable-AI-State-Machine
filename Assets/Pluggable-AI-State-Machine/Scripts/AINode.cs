using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Bale007.PASM
{
    public class AINode : Node
    {
        [System.Serializable]
        public class ActionPort { }

        [System.Serializable]
        public class DecisionPort { }

        [System.Serializable]
        public class TransitionPort { }

        [System.Serializable]
        public class StatePort { }

        public enum Port { Input, Output };

        public bool IsActive { get; protected set; }

        public AIBrain brain { get; protected set; }

        public virtual void OnStateEnter() { IsActive = true; }

        public virtual void OnStateExit() { IsActive = false; }

        public virtual void OnDrawGimoz() { }

        public virtual void BuildConnection(AIBrain brain)
        {
            this.brain = brain;
        }

        public virtual T GetNode<T>(string portName, Port port) where T : AINode
        {
            NodePort otherPort = null;

            if (port == Port.Input)
            {
                otherPort = GetInputPort(portName).Connection;
            }
            else if (port == Port.Output)
            {
                otherPort = GetOutputPort(portName).Connection;
            }

            if (otherPort != null)
            {
                return otherPort.node as T;
            }

            return null;
        }
    }
}

