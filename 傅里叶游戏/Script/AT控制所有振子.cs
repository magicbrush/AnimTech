using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT控制所有振子 : MonoBehaviour {

	public void 激活所有振子Exhausting()
	{
		AT振子原型[] 振子们 = GetComponentsInChildren<AT振子原型> ();

		foreach (AT振子原型 振子 in 振子们) {
			振子.TurnOnExausting ();
		}

	}

	public void 关闭所有振子Exhausting()
	{
		AT振子原型[] 振子们 = GetComponentsInChildren<AT振子原型> ();

		foreach (AT振子原型 振子 in 振子们) {
			振子.TurnOffExausting ();
		}

	}

	public void 激活所有画笔()
	{
		AT振子原型[] 振子们 = GetComponentsInChildren<AT振子原型> ();
		foreach (AT振子原型 振子 in 振子们) {
			振子.ActivateBrush ();
		}
	}

	public void 关闭所有画笔()
	{
		AT振子原型[] 振子们 = GetComponentsInChildren<AT振子原型> ();
		foreach (AT振子原型 振子 in 振子们) {
			振子.DeactivateBrush ();
		}
	}
		
}
