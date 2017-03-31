using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TestLevelScript))]
public class LevelScriptEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		TestLevelScript myTarget = (TestLevelScript)target;

		myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
		EditorGUILayout.LabelField("Level", myTarget.Level.ToString());

	}
}
