using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATRandPointEffector : MonoBehaviour {

	public float _ForceMagMin = -20.0f;
	public float _ForceMagMax = 20.0f;

	// Use this for initialization
	void Start () {
		Randomize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Randomize()
	{
		PointEffector2D effector = 
			GetComponent<PointEffector2D> ();
		float forceMag =
			Random.Range (_ForceMagMin, _ForceMagMax);
		effector.forceMagnitude = forceMag;
	}


}
