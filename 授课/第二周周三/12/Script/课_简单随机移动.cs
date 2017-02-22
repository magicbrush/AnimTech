using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 课_简单随机移动 : MonoBehaviour {

	public float _速率 = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (
			_速率 * Random.Range(-0.03f,0.03f), 
			_速率 * Random.Range(-0.03f,0.03f), 
			0);
	}
}
