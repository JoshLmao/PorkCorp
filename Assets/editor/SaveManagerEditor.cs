using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveManager))]
public class SaveManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SaveManager myScript = (SaveManager)target;
        if (GUILayout.Button("Save Game"))
        {
            myScript.OnSaveFile();
        }

        if (GUILayout.Button("Open Save Location"))
        {
            Process.Start(Application.persistentDataPath);
        }
    }
}
