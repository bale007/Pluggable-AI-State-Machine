using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XNodeEditor;

[CustomNodeEditor(typeof(AINode))]
public class AINodeEditor : NodeEditor
{
    public override void OnHeaderGUI()
    { 
        var node = target as AINode;

        if (node.IsActive)
        {
            GUI.color = Color.green;
        }

        if(node as AIStateNode)
        {           
            string title = (node as AIStateNode).StateName;
            GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }
        else
        {
            base.OnHeaderGUI();
        }

        GUI.color = Color.white;
    }

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();

        //var node = target as AINode;

        //if (node as AIStateNode)
        //{
        //    if (GUILayout.Button("Add Action"))
        //    {
        //        Debug.Log("Trying to add port");
        //        NodeEditorGUILayout.AddPortField(node.GetOutputPort("Action1"));
        //    }
        //    if (GUILayout.Button("Add Decision")) Debug.Log("Add Action");
        //    if (GUILayout.Button("Remove Action")) Debug.Log("Add Action");
        //    if (GUILayout.Button("Remove Decision")) Debug.Log("Add Action");

            
        //}
    }
}