using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT笔触旋转判断 : MonoBehaviour {

	private List<Vector3> _操作轨迹 = 
		new List<Vector3>();

	public UnityEvent _旋转了;

	[System.Serializable]
	public class EventWithFloat:
		UnityEvent<float>{}
	public EventWithFloat _旋转了带参数;

	void OnMouseDrag()
	{
		Vector3 鼠标操作位置InWorld;

		鼠标操作位置InWorld = 
			AT_Utils.鼠标位置从屏幕转换到世界参考系 (
				transform);

		_操作轨迹.Add (鼠标操作位置InWorld);

		Collider2D 碰撞体 = 
			GetComponent<Collider2D> ();
		bool 是否在碰撞体内拖动  = 
			碰撞体.OverlapPoint (鼠标操作位置InWorld);
		if (!是否在碰撞体内拖动) {
			_操作轨迹.Clear ();
		}

		int 记录点数量 = _操作轨迹.Count;
		if (记录点数量 < 3)
			return;

		Vector3 最近一次位移 = 
			获得位移 (0);
		Vector3 上一次位移 =
			获得位移 (1);

		Vector3 叉乘矢量 = 100000.0f* 
			Vector3.Cross (
			    最近一次位移, 上一次位移);

		Debug.Log ("叉乘矢量：" + 叉乘矢量);

		if (Mathf.Abs (叉乘矢量.z) > 50.0f) {
			_旋转了.Invoke ();
		}

		_旋转了带参数.Invoke (叉乘矢量.z);
	}


	Vector3 获得位移 (int 倒数第几 = 0)
	{
		int 记录点数量 = _操作轨迹.Count;
		Vector3 位移;
		Vector3 前一次位置 = _操作轨迹 [
			记录点数量 - 倒数第几 - 2];
		Vector3 当前位置 = _操作轨迹 [
			记录点数量 - 倒数第几 - 1];
		位移 = 当前位置 - 前一次位置;
		return 位移;
	}

	void OnMouseEnter()
	{
		_操作轨迹.Clear ();
	}

	public void ShowVector3(Vector3 Input)
	{
		Debug.Log ("Vector3:" + Input);
	}
}
