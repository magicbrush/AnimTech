using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_Servant : MonoBehaviour {

	public GameObject _SpriteObj;
	public float _Power = 1.0f;

	private ATPT_BrushSprite _BrSp = null;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity *= 0.96f;
		
		if (_BrSp == null)
			return;

		Vector3 posThis = transform.position;
		Vector3 posBrSp = _BrSp.transform.position;


		Vector3 vel = rb.velocity;
		Vector3 thisToBrSp = (posBrSp - posThis);
		Vector3 ForceDir = (thisToBrSp - vel).normalized;
		Vector3 force = _Power * ForceDir;

		//ATTraceRunner Runner = 
		//	_BrSp.GetComponentInParent<ATTraceRunner> ();

		rb.AddForce (force);

	}

	void OnTriggerStay2D(Collider2D other)
	{
		//Debug.Log ("Trigger!");
		if (_BrSp != null)
			return;
		
		ATPT_BrushSprite brs = 
			other.GetComponent<ATPT_BrushSprite>();
		if (brs == null)
			return;
		_BrSp = brs;

		_SpriteObj.SetActive (true);

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.enabled = false;
	}
}
