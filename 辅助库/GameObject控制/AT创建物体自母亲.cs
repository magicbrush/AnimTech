using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT创建物体自母亲 : MonoBehaviour {
	public Transform _MotherObj;
	public Transform _Parent;
	public GameObject _Prefab;
	public bool _ActivateOnStart = true;
	public bool _keepZ = true;
	public void 创建物体()
	{
		GameObject newObj = Instantiate (_Prefab) as GameObject;
		Vector3 pos = _MotherObj.position;
		if (_keepZ) {
			pos.z = _Prefab.transform.position.z;
		}
		newObj.transform.position = pos;
		newObj.transform.SetParent (_Parent);
		if (_ActivateOnStart) {
			newObj.SetActive (true);
		}
	}
}
