using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AT傅里叶振子按钮 : MonoBehaviour {
	
	private AT振子原型 [] _振子原型们;
	private Text _数量显示文本;

	private AT振子原型 _激活的振子原型 = null;

	private Transform _振子原型Parent;
	public Transform _主角;
	private static Transform _上级 = null;



	// Use this for initialization
	void Start () {
		初始化 ();

		_数量显示文本 = GetComponentInChildren<Text> ();
		_振子原型Parent = _振子原型们 [0].transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		int 剩余数量 = _振子原型们.Length;
		_数量显示文本.text = 剩余数量.ToString ();
	}

	public void 激活一个原型()
	{
		int cnt = _振子原型们.Length;
		_激活的振子原型 = _振子原型们 [cnt - 1];
		if (_上级 != null) {
			_激活的振子原型.transform.SetParent (_上级,false);
		} else {
			_激活的振子原型.transform.SetParent (_主角,false);
		}
		_上级 = _振子原型们 [cnt - 1].transform;

		初始化 ();
	}

	public void 收回激活的原型()
	{
		_上级 = _激活的振子原型.transform.parent;
		_激活的振子原型.transform.SetParent (_振子原型Parent,false);
		_激活的振子原型.transform.localPosition = Vector3.zero;
		_激活的振子原型 = null;
		初始化 ();
	}

	public void 确认激活的原型()
	{
		_激活的振子原型 = null;
	}

	void 初始化 ()
	{
		_振子原型们 = GetComponentsInChildren<AT振子原型> (true);

	}
}
