using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (BorderControl))]
public class BorderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BorderControl borders = target as BorderControl;
        
        if (DrawDefaultInspector())
            borders.Generate();
        
        if (GUILayout.Button("Generate borders"))
            borders.Generate();
    }
}