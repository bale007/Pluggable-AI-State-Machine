using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu]
[Serializable]
public class AIBevaiourGraph : NodeGraph {

    public AIBrain brain;
    public List<AIStateNode> StateMap = new List<AIStateNode>();
    public AIStateNode currentState;

    public void BuildConnection(AIBrain owner)
    {
        this.brain = owner;

        foreach(AINode node in nodes)
        {
            node.BuildConnection(owner);
        }
    }

    public void Init()
    {
        InitStateMap();
        currentState = GetEntryState();
        currentState.OnStateEnter();
    }

    public void Tick()
    {
        currentState.Tick();
    }

    public bool ChangeState(string newState)
    {
        if(newState == currentState.StateName)
        {
            Debug.Log("Origin State:" + newState);
            return true;
        }

        foreach(AIStateNode state in StateMap)
        {
            if(state.StateName == newState)
            {
                Debug.Log("Enter New State:" + newState);
                currentState.OnStateExit();
                currentState = state;
                currentState.OnStateEnter();
                return true;
            }
        }

        Debug.LogErrorFormat("State Name {0} Not Found",newState);

        return false;
    }

    private void InitStateMap()
    {
        StateMap.Clear();

        foreach (AINode node in nodes)
        {
            if (node as AIStateNode)
            {
                StateMap.Add(node as AIStateNode);
            }
        }
    }

    private AIStateNode GetEntryState()
    {
        foreach (AIStateNode state in StateMap)
        {
            if (state.IsEntryState)
            {
                return state;
            }
        }

        Debug.LogError("ERROR -> Etnry State Not Found");
        return null;
    }

    protected override void OnDestroy()
    {
        // do nothing
    }
}