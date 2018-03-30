using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_SpawnInBound : MonoBehaviour {
	[Header("要生成的物体的原型")]
	public GameObject _Prefab;
	[Header("要生成的物体的数量")]
	public int _BatchCount = 10;
	[Header("要生成的物体的区域")]
	public Bounds _SpawnRegion = new Bounds ();
	[Header("要生成的物体的父Tranform")]
	public Transform _TFParent;

	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn()
	{
		for (int i = 0; i < _BatchCount; i++) {
			GameObject newObj = 
				Instantiate (_Prefab, _TFParent) as GameObject;
			Vector3 Min = _SpawnRegion.min;
			Vector3 Max = _SpawnRegion.max;
			Vector3 pos = Vector3.zero;
			for(int j=0;j<3;j++)
			{
				pos [j] = Random.Range (Min [j], Max [j]);
			}
			newObj.transform.localPosition = pos;
		}
	}
}
