using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandImpluse : MonoBehaviour {

	public float _ImpluseMagMin =1.0f;
	public float _ImpluseMagMax = 10.0f;

	public void MakeImpluse()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Vector2 impluse = Random.insideUnitCircle * Random.Range (_ImpluseMagMin, _ImpluseMagMax);
		rb.AddForce (impluse, ForceMode2D.Impulse);
	}

}
