using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_SpringForce : MonoBehaviour {

	[Header("另一个物体")]
	public Rigidbody2D _Other;
	[Header("弹簧无形变的长度")]
	private float _StaticLength = 0.0f;
	[Header("弹性系数K： F = K * (Length - StaticLength)")]
	public float _K = 1.0f;

	public float _ForceAngleDeg = 0.0f;

	// Use this for initialization
	void Start () {
		GetStaticLength ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 force = GetSpringForce ();
		_Other.AddForce (force);

		Rigidbody2D rbThis = GetComponent<Rigidbody2D> ();
		rbThis.AddForce (-force);

	}

	void GetStaticLength ()
	{
		Vector3 PosThis = transform.position;
		Vector3 PosOther = _Other.transform.position;
		Vector3 ThisToOther = PosOther - PosThis;
		_StaticLength = ThisToOther.magnitude;
	}

	Vector2 GetSpringForce()
	{
		float forcePower = GetSpringForcePower ();
		Vector2 forcedir = GetVector_Other2ThisDir ();

		Quaternion rot =
			Quaternion.AngleAxis (_ForceAngleDeg, Vector3.forward);
		forcedir = rot * forcedir;

		Vector2 force = forcePower * forcedir;
		return force;
	}

	float GetSpringForcePower()
	{
		Vector2 Other2This = GetVector_Other2This ();
		float SpringLength = Other2This.magnitude;
		float deltaSpringLength = SpringLength - _StaticLength;

		float forcePower = _K * deltaSpringLength;
		return forcePower;
	}

	Vector2 GetVector_Other2ThisDir()
	{
		Vector2 Other2This = GetVector_Other2This ();
		return Other2This.normalized;
	}

	Vector2 GetVector_Other2This()
	{
		Vector3 PosThis = transform.position;
		Vector3 PosOther = _Other.transform.position;
		Vector2 Other2This = (Vector2)(PosThis - PosOther);
		return Other2This;
	}



}
