using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATPTRun_Wall : MonoBehaviour {

	public float _SpdThres = 2.0f;
	public UnityEvent _Broken;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay2D(Collider2D other)
	{
		ATPT_BrushSprite brs = other.GetComponent<ATPT_BrushSprite> ();
		if (brs == null) {
			return;
		}

		float spd = brs._Runner._Speed;
		if (spd < _SpdThres) {
			brs.Die ();
		} else {
			_Broken.Invoke ();
			Destroy (gameObject);
		}
	}
}
