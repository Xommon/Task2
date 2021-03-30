using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorScriptExample : EditorWindow
{
    [MenuItem("Window/Validator")]
    public static void ShowWindow()
    {
        GetWindow<EditorScriptExample>("Validator");
    }
}
