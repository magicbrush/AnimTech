using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_w4_yanliao : MonoBehaviour {

	public Transform _A, _B, _C;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 PA, PB, PC;
		PA = _A.localPosition;
		PB = _B.localPosition;
		PC = _C.localPosition;
		Vector3 AB = PB - PA;
		Vector3 AC = PC - PA;
		Vector3 ACross = Vector3.Cross (AB, AC);


		
	}
}
