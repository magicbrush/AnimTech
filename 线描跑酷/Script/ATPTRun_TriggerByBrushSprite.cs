using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATPTRun_TriggerByBrushSprite : MonoBehaviour {
	public UnityEvent _触发;
	public ATPTRun_SplashDrop _SPDrop;

	void OnTriggerStay2D(Collider2D other)
	{
		ATPT_BrushSprite brs = other.GetComponent<ATPT_BrushSprite> ();
		if (brs == null) {
			return;
		}
		_触发.Invoke ();



	}
}
