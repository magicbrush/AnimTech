using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKeyFrameDemo0 : MonoBehaviour {

	public AnimationCurve YPos,XPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float 当前时刻 = Time.realtimeSinceStartup;
		float Y位置 = YPos.Evaluate (当前时刻);
		float X位置 = XPos.Evaluate (当前时刻);

		Vector3 局域位置 = new Vector3 (X位置, Y位置, 0);
		transform.localPosition = 局域位置;
		
	}
}
