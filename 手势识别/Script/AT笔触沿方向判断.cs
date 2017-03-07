using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT笔触沿方向判断 : MonoBehaviour {

	private List<Vector3> _操作轨迹 = new List<Vector3>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void OnMouseDrag()
	{
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		float 相机到此物体的z距离 = 
			transform.position.z - 
			Camera.main.transform.position.z;
		Vector3 mousePosInWorld = 
			mouseRay.GetPoint (相机到此物体的z距离);

		_操作轨迹.Add (mousePosInWorld);

		Collider2D 碰撞体 = GetComponent<Collider2D> ();
		bool 是否在碰撞体内拖动  = 碰撞体.OverlapPoint (mousePosInWorld);
		if (!是否在碰撞体内拖动) {
			_操作轨迹.Clear ();
		}

		int 记录点数量 = _操作轨迹.Count;
		if (记录点数量 < 2)
			return;
		
		Vector3 前一次位置 = _操作轨迹 [记录点数量 - 2];
		Vector3 当前位置 = _操作轨迹 [记录点数量 - 1];
		Vector3 最近一次位移 = 当前位置 - 前一次位置;

		Vector3 右方InWorld = 
			transform.TransformDirection (Vector3.right);
		float 位移在向右方向上的投影=
			Vector3.Dot (最近一次位移, 右方InWorld);

		Debug.Log ("位移在向右方向上的投影" + 位移在向右方向上的投影);
	}

	void OnMouseEnter()
	{
		_操作轨迹.Clear ();
	}
}
