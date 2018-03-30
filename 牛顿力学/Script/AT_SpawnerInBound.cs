using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AT_SpawnerInBound : MonoBehaviour {

	public GameObject _Prefab;
	public int _SpawnCount = 10;
	public float _MaxRadius = 10.0f;

	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn()
	{
		for (int i = 0; i < _SpawnCount; i++) {
			GameObject newBall = Instantiate (_Prefab, transform);

			Vector3 RandPos01 = (Vector3)Random.insideUnitCircle;
			Vector3 RandPos = RandPos01 * _MaxRadius;
			newBall.transform.localPosition = RandPos;
		}
	}

}
