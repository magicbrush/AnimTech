using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT激活所有振子 : MonoBehaviour {

	public void 激活所有振子()
	{
		AT振子原型[] 振子们 = GetComponentsInChildren<AT振子原型> ();

		foreach (AT振子原型 振子 in 振子们) {
			振子.TurnOnExausting ();
		}

	}
		
}
