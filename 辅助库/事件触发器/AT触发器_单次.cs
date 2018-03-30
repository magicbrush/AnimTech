using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT触发器_单次 : MonoBehaviour {
    public UnityEvent _发生;
    public bool _即将触发 = false;
	
	// Update is called once per frame
	void Update () {

        if(_即将触发)
        {
            _发生.Invoke();
            _即将触发 = false;
        }		
	}
}
