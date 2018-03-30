using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AT_PTRandImpluse : MonoBehaviour {
	public KeyCode _Key = KeyCode.S;
	public float _ForceMulitpler = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (_Key)) {
			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			rb.AddForce (
				_ForceMulitpler * Random.insideUnitCircle,
				ForceMode2D.Impulse);
		}

	}
}
