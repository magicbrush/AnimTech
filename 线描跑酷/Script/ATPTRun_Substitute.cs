using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_Substitute : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		ATPT_BrushSprite brs = 
			other.GetComponent<ATPT_BrushSprite>();
		if (brs == null)
			return;

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		int 长 = sr.sprite.texture.width;
		int 宽 = sr.sprite.texture.height;

		SpriteRenderer srTgt = 
			brs.GetComponent<SpriteRenderer> ();
		srTgt.sprite = Sprite.Create (
			sr.sprite.texture, 
			new Rect (0, 0, 长, 宽),
			0.5f*Vector2.one);
		srTgt.color = sr.color;

		Destroy (gameObject);
	}
}
