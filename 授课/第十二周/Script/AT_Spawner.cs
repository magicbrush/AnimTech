using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Spawner : MonoBehaviour {
	public KeyCode _Key = KeyCode.A;
	public GameObject _Prefab;
	public int _Count = 10;

	public float _Radius = 5.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (_Key)) {
			Spawn ();
		}
		
	}

	[ContextMenu("Spawn")]
	public void Spawn()
	{
		for (int i = 0; i < _Count; i++) {
			GameObject newObj = 
				Instantiate (_Prefab) as GameObject;
			newObj.transform.SetParent (transform);
			newObj.transform.localPosition = 
				Random.insideUnitCircle * _Radius;
		}

	}
}
