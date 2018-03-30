using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInBounds : MonoBehaviour {
	public GameObject _prefab;
	public Bounds _bound;
	public int _BatchCount = 10;
	public Transform _TFParent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnBatch()
	{
		for (int i = 0; i < _BatchCount; i++) {
			Spawn ();
		}
	}

	public void Spawn()
	{
		Vector3 randVec = 
			new Vector3 (Random.value-0.5f, Random.value-0.5f, Random.value-0.5f) * 2.0f;
		Vector3 Ctr = _bound.center;
		Vector3 Ext = _bound.extents;
		Vector3 pos = Ctr;
		for (int i = 0; i < 3; i++) {
			pos [i] = Ctr [i] + Ext [i] * randVec[i];
		}

		GameObject newObj = Instantiate (_prefab, _TFParent) as GameObject;
		newObj.transform.localPosition = pos;
	}
}
