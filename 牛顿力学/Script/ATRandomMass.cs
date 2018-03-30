using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATRandomMass : MonoBehaviour {
	public float _MassMin = 0.5f, _MassMax = 5.0f;

	public void Randomize()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.mass = Random.Range (_MassMin, _MassMax);
	}
}
