using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomVec3 : MonoBehaviour {

	[System.Serializable]
	public class EventVec3: UnityEvent<Vector3>{};
	public EventVec3 _RandVec3;

	public float _MinSpd = 0.5f,_MaxSpd = 2.0f;

	// Use this for initialization
	void Start () {
		RandVec3 ();
	}

	public void RandVec3()
	{
		Vector3 v3 = Random.insideUnitCircle * 
			Random.Range (_MinSpd, _MaxSpd);
		_RandVec3.Invoke (v3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
