using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AT文本信息反馈 : MonoBehaviour {
	public Text _TxtPrefab;
	public Camera _Cam;
	public GameObject _Decoration;
	public bool _KeepInfrontOfCam = true;

	private Stack<GameObject> _DecoStack = new Stack<GameObject>();
	private List<GameObject> _ExistingInfoObjs = new List<GameObject> ();

	static private AT文本信息反馈 _信息反馈器;


	[System.Serializable]
	public class PredefineDecoration
	{
		public string _Name;
		public GameObject _DecoObj;
	}

	public List<PredefineDecoration> _LPredefineDecos = 
		new List<PredefineDecoration>();
	private Dictionary<string,GameObject> _DPredefineDecos = 
		new Dictionary<string,GameObject>();

	// 单例模式： 只能用 Instance()获取单例对象
	public static AT文本信息反馈 Instance()
	{
		if (_信息反馈器 == null) {
			_信息反馈器 = new AT文本信息反馈 ();
		}
		return _信息反馈器;
	}

	private AT文本信息反馈()
	{
		if (_信息反馈器 == null) {
			_信息反馈器 = this;
		} else {
			Destroy (this);
		}
	}

	// Use this for initialization
	void Start () {
		if (_Cam == null) {
			_Cam = Camera.main;
		}
	}

	void Update()
	{
		List<GameObject>.Enumerator it = 
			_ExistingInfoObjs.GetEnumerator();
		while(it.MoveNext ())
		{
			if(it.Current==null)
			{
				_ExistingInfoObjs.Remove(it.Current);
				//Debug.Log("_ExistingInfoObjs.Remove(it.Current)");
				//it.Dispose();
				break;
			}
		}

		if (_KeepInfrontOfCam) {
			PlaceInFrontCamera ();
		}
	}

	[ContextMenu("PlaceInFrontCamera")]
	public void PlaceInFrontCamera()
	{
		PlaceInFrontCamera (_Cam);
	}

	[ExecuteInEditMode]
	//[ContextMenu("AddPredefineDecosIntoDictionary")]
	private void AddPredefineDecosIntoDictionary()
	{
		foreach (PredefineDecoration ddeco in _LPredefineDecos) {
			if (!_DPredefineDecos.ContainsKey (ddeco._Name)) {
				_DPredefineDecos.Add (ddeco._Name, ddeco._DecoObj);
			} else {
				if (_DPredefineDecos [ddeco._Name] != ddeco._DecoObj) {
					_DPredefineDecos [ddeco._Name] = ddeco._DecoObj;
				}
			}
		}
	}

	public void PushTextInfo(
		string InfoText, 
		Vector3 PosWorld,
		float XShiftInScreenPercent = 0.0f,
		float YShiftInScreenPercent = 5.0f,
		float Duration = 1.5f, 
		float SizeToScreenPercent = 5)
	{
		GameObject InfoObj = Instantiate (
			_TxtPrefab.gameObject, 
			transform.position, 
			Quaternion.identity) as GameObject;
		InfoObj.transform.SetParent (transform);

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

		_ExistingInfoObjs.Add (InfoObj);

		AttachDecoration (InfoObj);
	}

	public void PushTextInfo(
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
		SetNewInfoTextColor (TextColor);
	}

	public void SetDecoration(GameObject decoObj)
	{
		_Decoration = decoObj;
	}

	public bool SetDecoration(string PredefineDecoName)
	{
		if (!_DPredefineDecos.ContainsKey (PredefineDecoName)) {
			return false;
		}

		_Decoration = _DPredefineDecos [PredefineDecoName];
		return true;
	}

	public void PushDecoration()
	{
		if (_Decoration != null) {
			GameObject DecoRep = Instantiate (_Decoration) as GameObject;
			DecoRep.transform.SetParent (_Decoration.transform.parent);
			_DecoStack.Push (_Decoration);
			Destroy (_Decoration);
		}
	}

	public void PopDecoration()
	{
		if (_DecoStack.Count > 0) {
			_Decoration = _DecoStack.Pop ();
		}
	}

	// ************************* private ***************************************//
	private void SetNewInfoTextColor (Color TextColor)
	{
		_ExistingInfoObjs [_ExistingInfoObjs.Count - 1].GetComponent<Text> ().color = TextColor;
	}

	private void AttachDecoration (GameObject InfoObj)
	{
		GameObject newDeco = Instantiate (_Decoration) as GameObject;
		newDeco.transform.SetParent (InfoObj.transform);
		newDeco.SetActive (true);
	}

	private void PoseText (
		Vector3 PosWorld, 
		float XShiftInScreenPercent, 
		float YShiftInScreenPercent, 
		GameObject InfoObj, 
		float screenSquareWidth)
	{
		// pose the text in right position
		Vector2 ScnPos = _Cam.WorldToScreenPoint (PosWorld);
		Vector2 ScnBias = new Vector2 (
			0.01f*XShiftInScreenPercent * screenSquareWidth, 
			0.01f*YShiftInScreenPercent * screenSquareWidth);
		Vector2 ScnPosBiased = ScnPos + ScnBias;
		Ray PosRay = _Cam.ScreenPointToRay (ScnPosBiased);
		Vector3 DispPosWorld = PosRay.GetPoint (_Cam.nearClipPlane);
		InfoObj.transform.position = DispPosWorld;
	}

	private void ScaleText (
		float SizeToScreenPercent, 
		GameObject InfoObj, 
		Text uiTxt, 
		float screenSquareWidth)
	{
		// scale text
		int fontSize = uiTxt.fontSize;
		RectTransform rtf = GetComponent<RectTransform> ();
		float sqWd = Mathf.Min (rtf.sizeDelta.x, rtf.sizeDelta.y);
		float tgtSize = sqWd * SizeToScreenPercent*0.01f;
		float scl = tgtSize / fontSize;
		Vector3 scl3 = new Vector3 (scl, scl, 1.0f);
		InfoObj.transform.localScale = scl3;
	}

	private void SetTextLifeSpan (
		float Duration, 
		GameObject InfoObj)
	{
		// set duration
		AT定时死亡 dier = InfoObj.AddComponent<AT定时死亡> ();
		dier.SetLifeSpan (Duration);
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
		//Debug.Log ("Parent:" + parent);
	}

	private void ResizeRectFillingCamView (Camera Cam)
	{
		RectTransform rt = GetComponent<RectTransform> ();
		bool bOrtho = Cam.orthographic;
		if (bOrtho) {
			float orthoSize = Cam.orthographicSize;
			float CenterSquareSize = Mathf.Min ((float)Screen.width, (float)Screen.height);
			rt.sizeDelta = new Vector2 ((float)Screen.width / CenterSquareSize, (float)Screen.height / CenterSquareSize) * orthoSize * 2.0f;
		}
		else {
			float viewAngleDegs = Cam.fieldOfView;
			float RectHt = 2.0f * Mathf.Tan ( 0.5f * viewAngleDegs * Mathf.Deg2Rad) * Cam.nearClipPlane;
			float RectWd =  RectHt * Cam.aspect;
			rt.sizeDelta = new Vector2 (RectWd, RectHt);
		}
	}
}
