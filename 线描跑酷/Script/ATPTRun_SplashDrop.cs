using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_SplashDrop : MonoBehaviour {
	public float _ForceMultiplier = 1.0f;
	public float _ForcePosDist = 1.0f;
	// Use this for initialization
	public ATPT_ResetPlay _Player;
	//public ATPT_BrushSprite _brs;
	public float _ForceMulitSpd = 1.0f;

	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		ATPT_BrushSprite brs = _Player.GetBrushSprite ();
		if (brs == null) {
			return;
		}

		float force = _ForceMultiplier * brs._Runner.GetSpeed () * _ForceMulitSpd;

		Vector2 Force = force*Random.insideUnitCircle;

		rb.AddForceAtPosition (
			Force,
			_ForcePosDist*Random.insideUnitCircle,
			ForceMode2D.Impulse);
	}
}
