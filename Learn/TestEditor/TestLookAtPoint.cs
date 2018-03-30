using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLookAtPoint : MonoBehaviour {

	public Vector3 lookAtPoint = Vector3.zero;

	public void Update()
	{
		transform.LookAt(lookAtPoint);
	}
}
