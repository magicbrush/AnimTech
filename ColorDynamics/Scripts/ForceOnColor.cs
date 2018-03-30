using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ForceOnColor : MonoBehaviour {
	public ColorModel _colorModel;
	public float _ForceMulitiplier = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public List<Collider2D> _Others = new List<Collider2D> ();

	public void OnTriggerEnter2D(Collider2D other)
	{
		_Others.Add (other);
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		//print ("OnTriggerStay2D:" + other.ToString ());
		ColorModel colorModelOther = other.GetComponent<ColorModel>();
		if (!colorModelOther) {
			return;
		}

		Color crThis = _colorModel.GetDispColor ();
		Color crOther = colorModelOther.GetDispColor ();

		float colorDelta = 0.0f;
		colorDelta += Mathf.Abs (crThis.r - crOther.r);
		colorDelta += Mathf.Abs (crThis.g - crOther.g);
		colorDelta += Mathf.Abs (crThis.b - crOther.b);

		colorDelta /= 3.0f; // 0~1的数值范围

		// 力的方向
		Vector3 posThis = transform.position;
		Vector3 posOther = other.transform.position;
		Vector3 thisToOther = posOther - posThis;
		Vector3 forceDir = thisToOther.normalized;

		// 力的大小
		float forceMag = _ForceMulitiplier * colorDelta;
		Vector3 force = forceMag * forceDir;

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (force);
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		_Others.Remove (other);
	}

}
