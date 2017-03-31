using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AT文本信息反馈 : MonoBehaviour {
	static private AT文本信息反馈 _信息反馈器;
	private RectTransform _RTF=null;
	public Dictionary<string,GameObject> _InfoPrefabs = 
		new Dictionary<string,GameObject>();

	public Camera _Cam;

	// Use this for initialization
	void Start () {
		if (_信息反馈器 == null) {
			_信息反馈器 = this;
		} else {
			Destroy (this);
		}

		if (_RTF == null) {
			_RTF = GetComponent<RectTransform> ();
		}
	}

	[ContextMenu("PlaceInFrontCamera")]
	public void PlaceInFrontCamera()
	{
		PlaceInFrontCamera (_Cam);
	}

	private void PlaceInFrontCamera(Camera Cam)
	{
		PlaceAtCamNearClipPlane (Cam);

		bool bOrtho = Cam.orthographic;
		if (bOrtho) {
			float orthoSize = Cam.orthographicSize;

			RectTransform rt = GetComponent<RectTransform> ();
			//float whRatio = (float)Screen.width / (float)Screen.height;
			float CenterSquareSize = Mathf.Min ((float)Screen.width, (float)Screen.height);
			//float centerSquareRatio = whRatio > 1.0f ? 1.0f / whRatio : whRatio;

			rt.sizeDelta = new Vector2 (
				(float)Screen.height/CenterSquareSize, 
				(float)Screen.width/CenterSquareSize) * orthoSize * 2.0f;
			
		} else {
			
		}
	}

	private void PlaceAtCamNearClipPlane (Camera Cam)
	{
		RectTransform rt = GetComponent<RectTransform> ();
		Transform parent = rt.parent;
		rt.SetParent (_Cam.transform);
		rt.localScale = Vector3.one;
		rt.localRotation = Quaternion.identity;
		rt.localPosition = new Vector3 (0, 0, Cam.nearClipPlane);
		rt.SetParent (parent, true);
		Debug.Log ("Parent:" + parent);
	}

	public static void PushTextInfo(
		string InfoText, 
		Vector3 Pos,
		string StyleName, 
		float XShiftInScreenPercent = 0.0f,
		float YShiftInScreenPercent = 5.0f,
		float Duration = 1.5f, 
		float SizeToScreenPercent = 5)
	{
		
	}

	public static void PushTextInfo(
		string InfoText, 
		Vector3 Pos,
		string StyleName, 
		Color TextColor,
		float XShiftInScreenPercent = 0.0f,
		float YShiftInScreenPercent = 5.0f,
		float Duration = 1.5f, 
		float SizeToScreenPercent = 5)
	{
		PushTextInfo (InfoText, Pos, StyleName,
			XShiftInScreenPercent,YShiftInScreenPercent, 
			Duration, SizeToScreenPercent);
	}

	/*
	static void 生成文本信息对象 (string Info, Vector3 Pos, InfoItem item, float Duration, int Size)
	{
		GameObject newInfoObj = Instantiate (item._Prefab) as GameObject;
		newInfoObj.transform.SetParent (_信息反馈器._RTF);
		newInfoObj.transform.position = Pos;

		设置定时死亡 (Duration, newInfoObj);
		设置文本信息及尺寸 (Info, Size, newInfoObj);
	}

	static void 设置定时死亡 (float Duration, GameObject newInfoObj)
	{
		AT触发器_定时 定时器 = newInfoObj.GetComponent<AT触发器_定时> ();
		定时器._剩余时间 = Duration;
	}

	static void 设置文本信息及尺寸 (string Info, int Size, GameObject newInfoObj)
	{
		Text text = newInfoObj.GetComponent<Text> ();
		text.text = Info;
		text.fontSize = Size;
	}
	*/

}
