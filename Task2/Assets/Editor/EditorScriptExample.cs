using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EditorScriptExample : EditorWindow
{
    public ScriptableObjectExample scriptableObject;
    public Texture checkMark;
    public Texture crossMark;
    private int result;
    private int lastValidated;

    [MenuItem("Window/Validator")]
    public static void ShowWindow()
    {
        GetWindow<EditorScriptExample>("Validator");
    }

    private void OnEnable()
    {
        // Load all of the object names and resources
        scriptableObject = Resources.Load<ScriptableObjectExample>("ScriptableObjects/GameObjects");
        checkMark = Resources.Load<Texture>("Sprites/check_mark");
        crossMark = Resources.Load<Texture>("Sprites/cross_mark");
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginScrollView(Vector2.zero, GUILayout.ExpandWidth(true));
        for (int i = 0; i < scriptableObject.objectNames.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // Display entry's name
            GUILayout.Label("     " + scriptableObject.objectNames[i]);

            // Assign a validate button to each entry
            if (GUILayout.Button("VALIDATE", GUILayout.Width(90)))
            {
                result = Validate(scriptableObject.objectNames[i]);
                lastValidated = i;
            }

            // Draw the green checkmark or the red crossmark
            if (result == 1 && lastValidated == i)
            {
                GUI.DrawTexture(new Rect(0, 1 + (21 * i), 20, 20), checkMark, ScaleMode.ScaleToFit, true, 0.0F);
            }
            else if (result == -1 && lastValidated == i)
            {
                GUI.DrawTexture(new Rect(0, 1 + (21 * i), 20, 20), crossMark, ScaleMode.ScaleToFit, true, 0.0F);
            }
            else
            {
                // Remove the checkmark/crossmark from other entries
                GUI.DrawTexture(new Rect(0, 1 + (21 * i), 20, 20), null, ScaleMode.ScaleToFit, true, 0.0F);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();
    }

    private int Validate(string objectName)
    {
        if (GameObject.Find(objectName) == null)
        {
            // Prompt the user to allow Unity to create the object for them
            bool option = EditorUtility.DisplayDialog("Object Not Validated",
                $"{objectName} could not be validated. Would you like to create this object?",
                "Yes",
                "No");
            switch (option)
            {
                case true:
                    new GameObject(objectName);
                    return 1;
                case false:
                    return -1;
            }
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
