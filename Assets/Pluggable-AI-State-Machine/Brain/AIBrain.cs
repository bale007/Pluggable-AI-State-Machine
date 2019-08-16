using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class AIBrain : MonoBehaviour
{
    public AIBevaiourGraph BehaviourTemplate;

    private AIBevaiourGraph BehaviourGraph;

    private void Awake()
    {
        BuildAIBrain();

        BehaviourGraph.Init();
    }

    public void Update()
    {
        BehaviourGraph.Tick();
    }

    public void BuildAIBrain()
    {
        BehaviourGraph = BehaviourTemplate.Copy() as AIBevaiourGraph;

        BehaviourGraph.name = gameObject.name;

        BehaviourGraph.BuildConnection(this);
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR

        if (BehaviourGraph == null)
        {
            return;
        }

        foreach (Node node in BehaviourGraph.nodes)
        {
            (node as AINode)?.OnDrawGimoz();
        }
#endif
    }

}
