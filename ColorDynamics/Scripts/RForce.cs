using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorModel))]
[RequireComponent(typeof(Rigidbody2D))]
public class RForce : MonoBehaviour {
	public float _ForceMultiplier = 1.0f;
	public float _DistPower = 1.0f;
	public void OnTriggerStay2D(Collider2D other)
	{
		ColorModel colorModelOther = other.GetComponent<ColorModel>();
		if (!colorModelOther) {
			return;
		}
		ColorModel colorModelThis = GetComponent<ColorModel>();

		Vector3 rgb = colorModelThis.GetRGB ();
		Vector3 rgbO = colorModelOther.GetRGB ();
		float r = rgb.x;
		float ro = rgbO.x;
		float dr = r - ro;

		// 力的方向
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Vector2 vel = rb.velocity;
		Vector2 forceDir = vel.normalized;

		// 力的大小
		Vector3 posThis = transform.position;
		Vector3 posOther = other.transform.position;
		Vector3 thisToOther = posOther - posThis;
		float forceMag = 
			_ForceMultiplier * vel.magnitude * dr /
			Mathf.Pow(thisToOther.magnitude,_DistPower);
		Vector2 force = forceMag * forceDir;

		rb.AddForce (force);
	}
}
