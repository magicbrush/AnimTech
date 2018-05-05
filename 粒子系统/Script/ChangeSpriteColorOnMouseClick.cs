using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColorOnMouseClick : MonoBehaviour {

	public void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			SpriteRenderer spr = 
				GetComponent<SpriteRenderer> ();
			if (spr != null) {
				spr.color = RandomColor ();
			}
		}
	}

	Color RandomColor()
	{
		Color cr = new Color ();
		for (int i = 0; i < 4; i++) {
			cr [i] = Random.value;
		}
		return cr;
	}
}
