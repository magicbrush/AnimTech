using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATDieWithAntoher : MonoBehaviour {

	public GameObject _Another;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (_Another == null) {
			Destroy (gameObject);
		}
	}
}
