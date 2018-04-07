using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AT_Absorbit))]
public class AT_AbsorbitRandomize : MonoBehaviour {

	public float _CMin = 0.1f,_CMax = 10.0f;
	public float _RhoMin = 0.1f, _RhoMax = 1.0f;

	public void Randomize()
	{
		AT_Absorbit ab = GetComponent<AT_Absorbit> ();
		ab.SetC (Random.Range (_CMin, _CMax));
		ab.SetRho (Random.Range (_RhoMin, _RhoMax));
	}
}
