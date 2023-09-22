#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using EzTrigger;
using UnityEngine;
[CustomEditor(typeof(Trigger))]

public class TriggerEditor : Editor
{

    private SerializedProperty anyTagProperty;
    private SerializedProperty targetTagProperty;
    private BoxCollider triggerCollider;

    private void OnEnable()
    {
        targetTagProperty = serializedObject.FindProperty("_targetTag");
        anyTagProperty = serializedObject.FindProperty("_anyTag");

    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Trigger Tag Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(anyTagProperty, new GUIContent("Any Tag"));

        if (!anyTagProperty.boolValue)
        {
            EditorGUILayout.PropertyField(targetTagProperty, new GUIContent("Target Tag"), true);

        }
        serializedObject.ApplyModifiedProperties();

    }

}
#endif
