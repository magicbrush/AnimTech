using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ColorModel))]
[RequireComponent(typeof(Rigidbody2D))]
public class BForce : MonoBehaviour {
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
		float b = rgb.z;
		float bo = rgbO.z;
		float db = b - bo;

		// 力的方向
		Vector3 posThis = transform.position;
		Vector3 posOther = other.transform.position;
		Vector3 thisToOther = posOther - posThis;
		Vector2 forceDir = thisToOther.normalized;
		forceDir = Quaternion.AngleAxis (-90.0f, Vector3.forward) * forceDir;

		// 力的大小
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Rigidbody2D rbO = other.GetComponent<Rigidbody2D> ();
		Vector2 vel = rb.velocity;
		Vector2 velO = rbO.velocity;
		float cross = Vector3.Cross ((Vector3)vel, (Vector3)velO).magnitude;

		float forceMag = 
			_ForceMultiplier * cross * db /
			Mathf.Pow(thisToOther.magnitude,_DistPower);
		Vector3 force = forceMag * forceDir;

		rb.AddForce (force);
	}
}
