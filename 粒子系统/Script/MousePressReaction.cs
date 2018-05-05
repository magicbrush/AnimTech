using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePressReaction : MonoBehaviour {
	//public int _MouseBtn = 0;
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetMouseButton (_MouseBtn)) {
			ReactToMouse (Input.mousePosition);
		}*/
	}

	virtual public void ReactToMouse(Vector2 MousePos)
	{
		print ("MousePressReaction:" + MousePos.ToString ());
	}
}
