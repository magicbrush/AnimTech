using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteColorOnColor : MonoBehaviour {
	public ColorModel _colorModel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	[ContextMenu("Update")]
	void Update () {
		Color cr = _colorModel.GetDispColor ();
		SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		spr.color = cr;
	}




}
