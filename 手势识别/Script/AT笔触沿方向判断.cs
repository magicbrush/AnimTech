using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT笔触沿方向判断 : MonoBehaviour {

	private List<Vector3> _操作轨迹 = 
		new List<Vector3>();

	void OnMouseDrag()
	{
		Vector3 鼠标操作位置InWorld = 
			AT_Utils.鼠标位置从屏幕转换到世界参考系(transform);

		_操作轨迹.Add (鼠标操作位置InWorld);

		Collider2D 碰撞体 = 
			GetComponent<Collider2D> ();
		bool 是否在碰撞体内拖动  = 
			碰撞体.OverlapPoint (鼠标操作位置InWorld);
		if (!是否在碰撞体内拖动) {
			_操作轨迹.Clear ();
		}

		int 记录点数量 = _操作轨迹.Count;
		if (记录点数量 < 2)
			return;

		Vector3 最近一次位移 = 
			计算最近一次位移 ();

		Vector3 右方InWorld = 
			transform.TransformDirection (Vector3.right);
		float 位移在向右方向上的投影=
			Vector3.Dot (最近一次位移, 右方InWorld);

		Debug.Log ("位移在向右方向上的投影" + 
			1000.0f*位移在向右方向上的投影);
	}

	Vector3 计算最近一次位移 ()
	{
		int 记录点数量 = _操作轨迹.Count;
		Vector3 最近一次位移;
		Vector3 前一次位置 = _操作轨迹 [记录点数量 - 2];
		Vector3 当前位置 = _操作轨迹 [记录点数量 - 1];
		最近一次位移 = 当前位置 - 前一次位置;
		return 最近一次位移;
	}

	void OnMouseEnter()
	{
		_操作轨迹.Clear ();
	}
}
