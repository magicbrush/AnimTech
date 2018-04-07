using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_RandomForceByMouse : MonoBehaviour {
	public float _Power = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		//bool bMouseDown = Input.mousePresent;
		//print ("Mouse:" + bMouseDown.ToString ());

		if (Input.GetMouseButtonDown (0))
		{
			Vector2 Origin = Vector2.zero;
			Vector2 Pos = (Vector2)transform.position;

			Vector2 ForceDir = (Origin - Pos).normalized;

			rb.AddForce (_Power * ForceDir, ForceMode2D.Impulse);
		}

		//rb.acceleration = 0
		
	}
}
