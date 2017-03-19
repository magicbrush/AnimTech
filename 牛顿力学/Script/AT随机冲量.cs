using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT随机冲量 : MonoBehaviour {

	public float _Power = 1.0f;

	public void AddImpluse()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		if (rb == null)
			return;

		rb.AddForce (0.01f*Random.insideUnitCircle * _Power, ForceMode2D.Impulse);
	}
}
