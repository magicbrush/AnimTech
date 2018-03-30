using UnityEngine;
using System.Collections;

public class AT颜料空间 : MonoBehaviour {

	public Camera _曝光摄像头;

	[ContextMenu("曝光到画布纹理")]
	public void 曝光到画布纹理()
	{
		_曝光摄像头.Render ();
	}

	[ContextMenu("清除活性颜料")]
	public void 清除活性颜料()
	{
		Transform[] 颜料们 = GetComponentsInChildren<Transform> ();
		foreach (Transform tf in 颜料们) {
            if(tf!=transform)
            {
                Destroy(tf.gameObject);
            }
		}
	}

	[ContextMenu("固化活性颜料")]
	public void 固化活性颜料()
	{
		曝光到画布纹理 ();
		清除活性颜料 ();
	}

}
