using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ATParticleBase : MonoBehaviour {
	public float _ForcePower = 1.0f;
	public float _ForceOffset = 1.0f;
	public float _LifeSpan = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		_LifeSpan -= Time.deltaTime;
		if (_LifeSpan < 0.0f) {
			Destroy (gameObject);
		}

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForceAtPosition (
			_ForcePower * Random.insideUnitCircle, 
			_ForceOffset * Random.insideUnitCircle);

	}
}
