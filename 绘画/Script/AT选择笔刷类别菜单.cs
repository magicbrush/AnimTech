using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT选择笔刷类别菜单 : MonoBehaviour {

	public GameObject _随机行为菜单,_周期行为菜单,_牛顿力学菜单,_其他菜单;
	private List<GameObject> _菜单们 = new List<GameObject> () ;

	void Start()
	{
		_菜单们.Add (_随机行为菜单);
		_菜单们.Add (_周期行为菜单);
		_菜单们.Add (_牛顿力学菜单);
		_菜单们.Add (_其他菜单);
	}

	void 禁掉所有菜单 ()
	{
		foreach (GameObject 菜单 in _菜单们) {
			菜单.SetActive(false);
		}
	}

	public void 选择随机行为()
	{
		禁掉所有菜单 ();
		_随机行为菜单.SetActive(true);
	}

	public void 选择周期行为()
	{
		禁掉所有菜单 ();
		_周期行为菜单.SetActive(true);
	}

	public void 选择牛顿力学()
	{
		禁掉所有菜单 ();
		_牛顿力学菜单.SetActive(true);
	}

	public void 选择其他()
	{
		禁掉所有菜单 ();
		_其他菜单.SetActive(true);
	}

	public void 选择菜单(int id)
	{
		if (id == 0) {
			选择随机行为 ();
		} else if (id == 1) {
			选择周期行为 ();
		} else if (id == 2) {
			选择牛顿力学 ();
		} else if (id == 3) {
			选择其他 ();
		}
	}



}
