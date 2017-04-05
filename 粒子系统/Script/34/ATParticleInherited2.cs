using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATParticleInherited2 : ATParticleBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = Random.ColorHSV ();
	}
}
