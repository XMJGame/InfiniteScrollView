using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIInfiniteTable), true)]
public class UIInfiniteTableTool : Editor
{
    UIInfiniteTable table;
    void OnEnable()
    {
        table = target as UIInfiniteTable;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.Space();
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mTempDataCount"));
        if (GUILayout.Button("Reposition"))
        {
            table.Reposition();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
