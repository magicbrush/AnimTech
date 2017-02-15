using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AT触发器_开始 : MonoBehaviour {

	public UnityEvent _开始;
	// Use this for initialization
	void Start () {
		_开始.Invoke ();
	}

}
