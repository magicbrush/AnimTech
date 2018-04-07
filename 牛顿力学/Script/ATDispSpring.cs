using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ATDispSpring : MonoBehaviour {
	public AT_SpringForce _SPringForce;

	public float _LineWidthOverLength01 = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Pos0 = _SPringForce.transform.position;
		Vector3 Pos2 = _SPringForce._Other.transform.position;
		Pos0.z = Pos0.z + 1.0f;
		Pos2.z = Pos2.z + 1.0f;
		LineRenderer lineRdr = GetComponent<LineRenderer> ();
		lineRdr.SetPosition (0, Pos0);
		lineRdr.SetPosition (1, Pos2);

		float staticLength = _SPringForce.GetStaticLength ();
		float length = _SPringForce.GetLength ();
		float length01 = length / staticLength;
		float Width = _LineWidthOverLength01 / length01;
		lineRdr.widthMultiplier = Width;
	}
}
