using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XNodeEditor;
using XNode;
using System;

[CustomNodeGraphEditor(typeof(AIBevaiourGraph))]
public class AIBehaviourGraphEditor : NodeGraphEditor
{
    public override string GetNodeMenuName(Type type)
    {
        if(type.IsSubclassOf(typeof(AINode)))
            return base.GetNodeMenuName(type);
        return null;
    }

    //public override void OnGUI()
    //{
    //    NodeEditorWindow.current.Repaint();
    //}
}
