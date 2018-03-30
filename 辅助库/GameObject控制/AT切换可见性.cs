using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT切换可见性 : MonoBehaviour {

	public void 切换可见性()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
