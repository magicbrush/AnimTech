using UnityEngine;
using System.Collections;

public class AT噪声尺寸 : MonoBehaviour {
    public float _速率 = 0.01f;
    public float _随机变化速率 = 1.0f;
    public float _最小尺度 = 0.8f,_最大尺度 = 1.2f;

    private float _噪声参数y;
    private Vector3 _原始尺度 = Vector3.zero;

    // Use this for initialization
    void Start () {
        _噪声参数y = Random.value * 100.0f;
        _原始尺度 = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        float 当前时刻_秒 = Time.realtimeSinceStartup;
        float 随机尺度 =
            Mathf.PerlinNoise(
                当前时刻_秒 * _随机变化速率, _噪声参数y);
		随机尺度 = AT_MathUtil.map(随机尺度, 0.0f, 1.0f, _最小尺度, _最大尺度);
        Vector3 随机尺度v3 = _原始尺度 * 随机尺度;

        transform.localScale = 随机尺度v3;
    }
}
