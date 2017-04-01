using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPopInfoTest : MonoBehaviour {
	public KeyCode _Key;
	public string _Info = "信息";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (_Key)) {
			AT文本信息反馈.PushTextInfo (
				_Info, transform.position,0,5.0f,5.0f,5.0f);
		}
	}


}
