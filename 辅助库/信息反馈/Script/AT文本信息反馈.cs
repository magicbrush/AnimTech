using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AT文本信息反馈 : MonoBehaviour {
	public Text _TxtPrefab;
	public Camera _Cam;

	static private AT文本信息反馈 _信息反馈器;
	private static RectTransform _RTF=null;
	private static Text _TxtPrefabS = null;
	private static Camera _CamS;

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

		if (_TxtPrefabS != _TxtPrefab) {
			_TxtPrefabS = _TxtPrefab;
		}

		if (_CamS != _Cam) {
			_CamS = _Cam;
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
		ResizeRectFillingCamView (Cam);
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

	private void ResizeRectFillingCamView (Camera Cam)
	{
		RectTransform rt = GetComponent<RectTransform> ();
		bool bOrtho = Cam.orthographic;
		if (bOrtho) {
			float orthoSize = Cam.orthographicSize;
			float CenterSquareSize = Mathf.Min ((float)Screen.width, (float)Screen.height);
			rt.sizeDelta = new Vector2 ((float)Screen.height / CenterSquareSize, (float)Screen.width / CenterSquareSize) * orthoSize * 2.0f;
		}
		else {
			float viewAngleDegs = Cam.fieldOfView;
			float RectHt = 2.0f * Mathf.Tan ( 0.5f * viewAngleDegs * Mathf.Deg2Rad) * Cam.nearClipPlane;
			float RectWd =  RectHt * Cam.aspect;
			rt.sizeDelta = new Vector2 (RectWd, RectHt);
		}
	}

	public static void PushTextInfo(
		string InfoText, 
		Vector3 PosWorld,
		float XShiftInScreenPercent = 0.0f,
		float YShiftInScreenPercent = 5.0f,
		float Duration = 1.5f, 
		float SizeToScreenPercent = 5)
	{
		GameObject InfoObj = Instantiate (
			_TxtPrefabS.gameObject, 
			_RTF.position, 
			Quaternion.identity) as GameObject;
		InfoObj.transform.SetParent (_RTF);

		Text uiTxt = InfoObj.GetComponent<Text> ();
		uiTxt.enabled = true;
		uiTxt.text = InfoText;

		float screenSquareWidth = Mathf.Min (
			(float)Screen.width, (float)Screen.height);

		PoseText (
			PosWorld, 
			XShiftInScreenPercent, 
			YShiftInScreenPercent, 
			InfoObj, 
			screenSquareWidth);
		ScaleText (
			SizeToScreenPercent, 
			InfoObj, 
			uiTxt, 
			screenSquareWidth);
		SetTextLifeSpan (
			Duration, 
			InfoObj);
	}

	private static void PoseText (
		Vector3 PosWorld, 
		float XShiftInScreenPercent, 
		float YShiftInScreenPercent, 
		GameObject InfoObj, 
		float screenSquareWidth)
	{
		// pose the text in right position
		Vector2 ScnPos = _CamS.WorldToScreenPoint (PosWorld);
		Vector2 ScnBias = new Vector2 (
			0.01f*XShiftInScreenPercent * screenSquareWidth, 
			0.01f*YShiftInScreenPercent * screenSquareWidth);
		Vector2 ScnPosBiased = ScnPos + ScnBias;
		Ray PosRay = _CamS.ScreenPointToRay (ScnPosBiased);
		Vector3 DispPosWorld = PosRay.GetPoint (_CamS.nearClipPlane);
		InfoObj.transform.position = DispPosWorld;
	}

	private static void ScaleText (
		float SizeToScreenPercent, 
		GameObject InfoObj, 
		Text uiTxt, 
		float screenSquareWidth)
	{
		// scale text
		int fontSize = uiTxt.fontSize;
		float sqWd = Mathf.Min (_RTF.sizeDelta.x, _RTF.sizeDelta.y);
		float tgtSize = sqWd * SizeToScreenPercent*0.01f;
		float scl = tgtSize / fontSize;
		Vector3 scl3 = new Vector3 (scl, scl, 1.0f);
		InfoObj.transform.localScale = scl3;
	}

	private static void SetTextLifeSpan (
		float Duration, 
		GameObject InfoObj)
	{
		// set duration
		AT定时死亡 dier = InfoObj.AddComponent<AT定时死亡> ();
		dier.SetLifeSpan (Duration);
	}

	public static void PushTextInfo(
		string InfoText, 
		Vector3 PosWorld,
		Color TextColor,
		float XShiftInScreenPercent = 0.0f,
		float YShiftInScreenPercent = 5.0f,
		float Duration = 1.5f, 
		float SizeToScreenPercent = 5)
	{
		PushTextInfo (InfoText, PosWorld,
			XShiftInScreenPercent,YShiftInScreenPercent, 
			Duration, SizeToScreenPercent);
	}
}
