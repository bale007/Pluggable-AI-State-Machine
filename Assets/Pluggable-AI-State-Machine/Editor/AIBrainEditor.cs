using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Bale007.PASM;
[CustomEditor(typeof(AIBrain))]
public class AIBrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var script = (AIBrain)target;

        if (GUILayout.Button("Draw Gimoz"))
        {
            script.BuildAIBrain();
        }
    }
}
