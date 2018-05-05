using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public List<GameObject> _Prefabs = 
		new List<GameObject>();

	public void Spawn()
	{
		int id = 
			(int)Random.Range (0, _Prefabs.Count);
		GameObject newObj = 
			GameObject.Instantiate (_Prefabs[id], transform, false);;
	}
}
