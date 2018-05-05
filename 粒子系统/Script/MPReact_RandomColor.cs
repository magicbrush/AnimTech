using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPReact_RandomColor : MousePressReaction {

	public override void ReactToMouse (Vector2 MousePos)
	{
		SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		spr.color = RandomColor ();
	}

	public Color RandomColor()
	{
		Color cr = Color.white;
		for (int i = 0; i < 3; i++) {
			cr [i] = Random.value;
		}
		return cr;
	}

}
