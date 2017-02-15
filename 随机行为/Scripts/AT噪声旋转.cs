using UnityEngine;
using System.Collections;

public class AT噪声旋转 : MonoBehaviour {

	public float _速率系数 = 1.0f;
    public float _随机变化速率 = 1.0f;
    private float _噪声参数y;

    // Use this for initialization
    void Start () {
        _噪声参数y = Random.value*100.0f;	
	}
	
	// Update is called once per frame
	void Update () {
        float 当前时刻_秒 = Time.realtimeSinceStartup;
        float 方向角度 =
            Mathf.PerlinNoise(
                当前时刻_秒 * _随机变化速率, _噪声参数y) * 1500.0f;
        transform.rotation =
            Quaternion.AngleAxis(方向角度,Vector3.forward);
    }

	[ContextMenu("随机化噪声参数")]
	public void 随机化噪声参数()
	{
		_随机变化速率 = _速率系数 * Random.value;
		_噪声参数y = Random.value * 100.0f;
	}
}
