using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPReact_Move2MousePos : MousePressReaction {

	public float _LerpSpd = 0.1f;
	public override void ReactToMouse (Vector2 MousePos)
	{
		transform.localPosition = Vector3.Lerp (
			transform.localPosition, 
			Vector3.zero, 
			_LerpSpd * Time.deltaTime);
	}
}
