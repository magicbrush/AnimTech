using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerMgr : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Changer[] changers = 
			GetComponentsInChildren<Changer> ();
		foreach (var c in changers) {
			c.Change ();
		}

		//Changer_Rolling [] rs = GetComponentsInChildren<
		//Changer_ShakeScale [] ss = 


	}
}
