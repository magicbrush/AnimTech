using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT重置所有振子的时刻和位置 : MonoBehaviour {

	public void 重置所有振子的时刻和位置()
	{
		AT振子运动[] 振子们 = GetComponentsInChildren<AT振子运动> ();

		foreach (AT振子运动 振子 in 振子们) {
			振子.重置起始时刻和位置 ();
		}
	}
}
