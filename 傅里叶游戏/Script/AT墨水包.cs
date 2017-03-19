using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT墨水包 : MonoBehaviour {

	public float _Energy = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		//Debug.Log ("OnCollisionStay2D");
		AT振子原型 振子 = 
			coll.collider.GetComponent<AT振子原型> ();
		给振子加能量(振子);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		//Debug.Log ("OnTriggerStay2D");
		AT振子原型 振子 = 
			other.GetComponent<AT振子原型> ();
		//给振子加能量 (振子);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("OnTriggerEnter2D");
		AT振子原型 振子 = 
			other.GetComponent<AT振子原型> ();
		给振子加能量 (振子);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		//Debug.Log ("OnCollisionEnter2D");
	}

	void 给振子加能量 (AT振子原型 振子)
	{
		if (振子 == null) {
			return;
		}
		振子.AddEnergy (_Energy);

		Vector3 pos = 振子.transform.position;
		pos.z -= 8.0f;
		AT文本信息反馈.显示文本信息 (_Energy.ToString (), pos, "Standard_Black", 1.5f, 40);

		Destroy (gameObject);
	}
}
