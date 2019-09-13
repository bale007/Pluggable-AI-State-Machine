using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Bale007.PASM;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Bale007.PASM
{
    public class AIBrain : MonoBehaviour
    {
        public AIBevaiourGraph behaviourTemplate;

        public Hashtable sharedParam { get; protected set; }

        public AIBevaiourGraph behaviour { get; protected set; }

        private void Start()
        {
            BuildAIBrain();

            behaviour.Init();
        }

        public void Update()
        {
            behaviour.Tick();
        }

        public void StoreParam(string key, object value, bool overwrite)
        {
            if (sharedParam.ContainsKey(key))
            {
                if (overwrite)
                {
                    sharedParam[key] = value;
                }
                else
                {
                    Debug.LogErrorFormat("Key {0} Occupied By Object {1}", key, sharedParam[key]);
                }
            }
            else
            {
                sharedParam.Add(key, value);
            }
        }

        public object GetParam(string key, bool force)
        {
            if (sharedParam.ContainsKey(key))
            {
                return sharedParam[key];
            }
            else
            {
                if (force)
                {
                    Debug.LogErrorFormat("Object Not Found With Key {0}", key);
                }

                return null;
            }
        }

        public void BuildAIBrain()
        {
            sharedParam = new Hashtable();

            behaviour = behaviourTemplate.Copy() as AIBevaiourGraph;

            behaviour.name = gameObject.name;

            behaviour.BuildConnection(this);
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (behaviour != null)
            {
                foreach (Node node in behaviour.nodes)
                {
                    (node as AINode)?.OnDrawGimoz();
                }
                Handles.Label(transform.position, behaviour.currentState?.StateName.ToString());
            }
#endif
        }
    }
}


