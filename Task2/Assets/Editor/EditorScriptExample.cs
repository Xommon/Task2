using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EditorScriptExample : EditorWindow
{
    public ScriptableObjectExample scriptableObject;

    [MenuItem("Window/Validator")]
    public static void ShowWindow()
    {
        GetWindow<EditorScriptExample>("Validator");
    }

    private void OnEnable()
    {
        scriptableObject = Resources.Load<ScriptableObjectExample>("ScriptableObjects/GameObjects");
    }

    private void OnGUI()
    {
        for (int i = 0; i < scriptableObject.objectNames.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(scriptableObject.objectNames[i]);
            EditorGUILayout.EndHorizontal();
        }
    }
}
