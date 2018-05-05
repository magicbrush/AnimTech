using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPReact_RandomScale : MousePressReaction {

	public Bounds _ScaleBounds;

	public override void ReactToMouse (Vector2 MousePos)
	{
		Vector3 SMin = _ScaleBounds.min;
		Vector3 SMax = _ScaleBounds.max;
		Vector3 scale = Vector3.one;
		for (int i = 0; i < 3; i++) {
			scale [i] = Random.Range (SMin [i], SMax [i]);
		}
		transform.localScale = scale;
	}

}
