using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(PickUpItem))]
[CanEditMultipleObjects]
public class PickUpItemEditor : Editor {
	SerializedProperty itemTypeProperty;
	SerializedProperty nameProperty;
	SerializedProperty weightProperty;
	SerializedProperty doorIdProperty;
	SerializedProperty bonusPointsProperty;
	SerializedProperty part;
	void OnEnable () {
		itemTypeProperty = serializedObject.FindProperty ("itemType");
		nameProperty = serializedObject.FindProperty ("name");
		weightProperty = serializedObject.FindProperty ("weight");
		doorIdProperty = serializedObject.FindProperty ("doorId");
		bonusPointsProperty = serializedObject.FindProperty ("bonusPoints");
		part = serializedObject.FindProperty ("part");
	}

	public override void OnInspectorGUI() {
		
		serializedObject.Update ();

		EditorGUILayout.PropertyField (itemTypeProperty);
		EditorGUILayout.PropertyField (nameProperty);
		EditorGUILayout.PropertyField (weightProperty);
		if (itemTypeProperty.intValue == 1)
		{
			EditorGUILayout.PropertyField (bonusPointsProperty);
		}
		else if (itemTypeProperty.intValue == 0)
		{
			EditorGUILayout.PropertyField (doorIdProperty);
		}
		else
		{
			EditorGUILayout.PropertyField (part);
		}
		serializedObject.ApplyModifiedProperties ();
	}

}
