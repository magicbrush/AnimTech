using UnityEngine;
using System.Collections;

public class AT简单随机移动 : MonoBehaviour {

	public float _最大步长 = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x方向随机移动量 = Random.Range (-_最大步长, _最大步长);
		float y方向随机移动量 = Random.Range (-_最大步长, _最大步长);
		transform.Translate (x方向随机移动量, y方向随机移动量, 0.0f);

	}
}
