using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIBrain))]
public class AIBrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var script = (AIBrain)target;

        if(GUILayout.Button("Draw Gimoz"))
        {
            script.BuildAIBrain();
        }
    }
}
