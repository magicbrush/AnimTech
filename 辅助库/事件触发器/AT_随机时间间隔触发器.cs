using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT_随机时间间隔触发器 : MonoBehaviour {

    public UnityEvent _发生;

    public float _发生频度 = 1.0f;
    public float _发生间隔标准差 = 0.5f;
    private float _下一次发生剩余时间 = float.NegativeInfinity;

	// Use this for initialization
	void Start () {
        _下一次发生剩余时间 = _发生频度;
        随机生成时间间隔();
    }
	
	// Update is called once per frame
	void Update () {
        _下一次发生剩余时间 -= Time.deltaTime;
		if(_下一次发生剩余时间<=0.0f)
        {
            _发生.Invoke();
            随机生成时间间隔();
            //Debug.Log("发生间隔：" + _下一次发生剩余时间);
        }
	}

    private void 随机生成时间间隔()
    {
        int cnt = 0;
        if(_下一次发生剩余时间>0.0f)
        {
            _下一次发生剩余时间 = NextGaussian() * _发生间隔标准差 + _发生频度;
        }
       
        while(_下一次发生剩余时间<=0.0f && cnt<100)
        {
            float 间隔 = NextGaussian() * _发生间隔标准差 + _发生频度;
            间隔 = Mathf.Abs(间隔);
            _下一次发生剩余时间 += 间隔;
            cnt++;
        }           
    }

    // 如何从均匀分布转换到正态分布？
    // http://www.cnblogs.com/yymn/p/4817385.html
    // http://www.alanzucconi.com/2015/09/16/how-to-sample-from-a-gaussian-distribution/
    public static float NextGaussian()
    {
        float v1, v2, s;
        do
        {
            v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);
        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
        return v1 * s;
    }

}
