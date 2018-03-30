using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AT切换部件活性 : MonoBehaviour {

    public List<MonoBehaviour> _部件们 = 
        new List<MonoBehaviour>();

    [ContextMenu("切换活性")]
	public void 切换活性()
    {
        foreach(MonoBehaviour 部件 in _部件们)
        {
            部件.enabled = !部件.enabled;
        }
    }
}
