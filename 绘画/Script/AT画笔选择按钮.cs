using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AT画笔选择按钮 : MonoBehaviour {

	public GameObject _颜料;
	public AT画笔 _画笔;

	public void 选择这个画笔()
	{
		_画笔._颜料 = _颜料;
	}
}
