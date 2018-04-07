using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AT_Absorbit))]
public class AT_DestroyOnAbsorbitAmtExhaust : MonoBehaviour {

	public float _AmountThres = 0.01f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float c = GetComponent<AT_Absorbit> ().GetC ();
		if (c<=_AmountThres) {
			Destroy (gameObject);
		}
		
	}
}
