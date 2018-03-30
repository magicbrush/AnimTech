using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorModel))]
[RequireComponent(typeof(Rigidbody2D))]
public class GForce : MonoBehaviour {
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
		float g = rgb.y;
		float go = rgbO.y;
		float dg = g - go;

		// 力的方向
		Rigidbody2D rbOther = other.GetComponent<Rigidbody2D> ();
		Vector2 forceDir = rbOther.velocity.normalized;
		forceDir = Quaternion.AngleAxis (90.0f, Vector3.forward) * forceDir;

		// 力的大小
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Vector2 vel = rb.velocity;
		Vector3 posThis = transform.position;
		Vector3 posOther = other.transform.position;
		Vector3 thisToOther = posOther - posThis;
		float forceMag = 
			_ForceMultiplier * vel.magnitude * dg /
			Mathf.Pow(thisToOther.magnitude,_DistPower);
		Vector3 force = forceMag * forceDir;

		rb.AddForce (force);
	}
}
