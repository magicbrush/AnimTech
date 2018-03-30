using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AT触发器_定时 : MonoBehaviour {

	public UnityEvent _触发;
	public float _剩余时间= 1.0f;
    public bool _触发后禁用 = true;
    	
	// Update is called once per frame
	void Update () {
		if (_剩余时间 > 0.0f) {
			_剩余时间 -= Time.deltaTime;	
		}
        else
        {
            _触发.Invoke();
            if(_触发后禁用)
            {
                this.enabled = false;
            }
        }
	}
}
