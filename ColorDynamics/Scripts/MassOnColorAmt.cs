using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MassOnColorAmt : MonoBehaviour {
	public ColorModel _colorModel;
	public float _Mulitiplier = 1.0f;
	public float _MinMass = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	[ContextMenu("Update")]
	void Update () {
		float amt = _colorModel.GetColorAmount ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.mass = _Mulitiplier * amt + _MinMass;
		
	}
}
