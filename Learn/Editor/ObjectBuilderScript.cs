using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectBuilderScript))]
public class ObjectBuilderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		ObjectBuilderScript myScript = (ObjectBuilderScript)target;
		if(GUILayout.Button("Build Object"))
		{
			myScript.BuildObject();
		}

		EditorGUILayout.TextArea ("hahaha");

		if (GUILayout.Toggle (myScript._bON,myScript._Tex)) {
			EditorGUILayout.TextArea (myScript._Text0);
		}

		EditorGUILayout.TextArea (myScript._Text1);
	}
}