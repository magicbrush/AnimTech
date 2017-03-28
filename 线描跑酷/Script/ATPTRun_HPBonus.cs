using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATPTRun_HPBonus : MonoBehaviour {

	public float HP = 5.0f;
	public UnityEvent _Aid;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		ATPT_BrushSprite brSp = other.GetComponent<ATPT_BrushSprite> ();
		if (brSp == null) {
			return;
		} else {
			brSp._Runner._Status.AddHP (HP);
			_Aid.Invoke ();
			Destroy (gameObject);
		}
	}
}
