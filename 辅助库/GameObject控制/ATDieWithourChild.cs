using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATDieWithourChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.childCount == 0) {
			Destroy (gameObject);
		}
		
	}
}
