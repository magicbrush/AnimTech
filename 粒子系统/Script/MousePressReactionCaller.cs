using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePressReactionCaller : MonoBehaviour {
	public int _MouseBtn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (_MouseBtn)) {
			MousePressReaction[] reacts = 
				GetComponentsInChildren<MousePressReaction> ();
			foreach (var r in reacts) {
				r.ReactToMouse (Input.mousePosition);
			}
		}

	}
}
