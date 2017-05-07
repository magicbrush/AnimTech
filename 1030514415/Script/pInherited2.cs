using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pInherited2 : pBase  {

	private Vector3 ori_scale ;
	//改变尺寸
	// Use this for initialization
	void Start () {
		ori_scale = transform.localScale;
	}
	
	// Update is called once per frame
	public override void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		base.Update ();

		float time = Time.realtimeSinceStartup;
		float bh = Mathf.Sin (time);
		transform.localScale = ori_scale * bh;
		
	}
}
