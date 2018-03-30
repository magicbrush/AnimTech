using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT缓慢漂白画布 : MonoBehaviour {

    private SpriteRenderer _白板;
    private AT触发器_固定间隔 _间隔触发器;

	// Use this for initialization
	void Start () {
        _白板 = GetComponentInChildren<SpriteRenderer>();
        _间隔触发器 = GetComponent<AT触发器_固定间隔>();
    }

    public void 设置漂白速度(float 速度)
    {
        _间隔触发器._时间间隔 = 1.0f / 速度;
    }

    public void 设置漂白强度(float 强度)
    {
        Color 漂白颜色 = _白板.color;
        漂白颜色.a = 强度;
        _白板.color = 漂白颜色;
    }

}
