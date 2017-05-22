using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pComponent3 : MonoBehaviour {

	public float maxRotate = 5.0f;
	public float _ForceMultiplier = 1.0f;
	pComponent1 p1=new pComponent1();

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		p1.RandomAction (rb);
		p1.ChangeColor (sr);

		float rotate = Random.Range (-maxRotate, maxRotate);
		transform.Rotate (0, 0, rotate );
	}
}
