using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ATParticleBase12 : MonoBehaviour {

	public KeyCode _Key = KeyCode.A;
	public float _ForceMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (_Key)) {
			RandomAction ();
		}
		
	}

	public virtual void RandomAction()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (
			Random.insideUnitCircle * _ForceMultiplier);
	}

}
