using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicSpawn : MonoBehaviour {

	public GameObject _Prefab;
	public float _Period = 1.0f;
	private float _LeftTime ;

	// Use this for initialization
	void Start () {
		_LeftTime = _Period;
	}
	
	// Update is called once per frame
	void Update () {
		if (_LeftTime <= 0) {
			// spawn
			Spawn();

			// set lefttime
			_LeftTime += _Period;
		}

		_LeftTime -= Time.deltaTime;
	}

	public void Spawn()
	{
		GameObject newObj = 
			GameObject.Instantiate (_Prefab, transform, false);;
	}
}
