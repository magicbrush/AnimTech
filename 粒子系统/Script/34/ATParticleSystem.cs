using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATParticleSystem : MonoBehaviour {

	public float _Chance = 0.01f;
	public GameObject _Prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Random.value < _Chance) {
			GameObject newParticle = Instantiate (_Prefab) as GameObject;
			newParticle.transform.SetParent (transform);
			newParticle.transform.position = transform.position;
		}
		
	}
}
