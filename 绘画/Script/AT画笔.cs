using UnityEngine;
using System.Collections;

public class AT画笔 : MonoBehaviour {

	public Camera _观画摄像头, _曝光摄像头;
	public float _颜料深度 = 5.0f;
	public GameObject _颜料;
	public Transform _颜料空间;

	public float _时间权重 = 1.0f;
	public float _位移权重 = 1.0f;

	public float _涂颜料间隔 = 1.0f;

	private float _剩余间隔 = 1.0f;
	private Vector2 _上一次位置 = Vector2.zero;
	private bool _上一帧在绘制 = false;

	public float _旋转量 = 0.0f;

	// Use this for initialization
	void Start () {
		_剩余间隔 = _涂颜料间隔;
	}
	
	// Update is called once per frame
	void Update () {
		bool bDrawing = 
			Input.GetMouseButton (0);
		Vector2 鼠标位置 = Input.mousePosition;

		if (bDrawing && _上一帧在绘制) {
			float 经过时间 = Time.deltaTime;
			float 经过距离 = (鼠标位置 - _上一次位置).magnitude;
			float 经过间隔 = _时间权重 * 经过时间 + _位移权重 * 经过距离;
			_剩余间隔 -= 经过间隔;
			if (_剩余间隔 <= 0.0f) {
				根据鼠标位置赋以颜料 (鼠标位置);
				_剩余间隔 = _涂颜料间隔;
			}
		}
		_上一次位置 = 鼠标位置;
		_上一帧在绘制 = bDrawing;
	}

	private void 根据鼠标位置赋以颜料 (Vector2 鼠标位置)
	{
		Ray 从鼠标向画布出发的射线 = _观画摄像头.ScreenPointToRay (鼠标位置);
		float 两个摄像头的深度差 = (_曝光摄像头.transform.position - 
			_观画摄像头.transform.position).z;
		Vector3 颜料位置 = 从鼠标向画布出发的射线.GetPoint (_颜料深度 + 两个摄像头的深度差);
		GameObject newPaintObj = Instantiate (_颜料) as GameObject;
		newPaintObj.transform.SetParent (_颜料空间);
		newPaintObj.transform.position = 颜料位置;

		newPaintObj.transform.Rotate (Vector3.forward, _旋转量);
	}

	public void 设置旋转量(float 旋转)
	{
		_旋转量 = 旋转;
	}


}
