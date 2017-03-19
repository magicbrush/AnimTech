using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AT文本信息反馈 : MonoBehaviour {
	static private AT文本信息反馈 _信息反馈器;
	public RectTransform _RTF=null;

	[System.Serializable]
	public class InfoItem
	{
		public string _StyleName;
		public GameObject _Prefab;
	}
	public List<InfoItem> _InfoPrefabs = 
		new List<InfoItem>();

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

	public static void 显示文本信息(
		string Info, 
		Vector3 Pos, 
		int StyleId, 
		float Duration = 1.5f, 
		int Size = 40)
	{
		InfoItem item = _信息反馈器._InfoPrefabs [StyleId];
		生成文本信息对象 (Info, Pos, item, Duration,Size);
	}

	public static void 显示文本信息(
		string Info, 
		Vector3 Pos, 
		string StyleName, 
		float Duration = 1.5f, 
		int Size = 40)
	{
		foreach (InfoItem item in _信息反馈器._InfoPrefabs) {
			if (item._StyleName == StyleName) {
				生成文本信息对象 (Info, Pos, item, Duration, Size);
				break;
			}
		}
	}

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

}
