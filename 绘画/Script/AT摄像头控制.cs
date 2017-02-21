using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AT摄像头控制 : MonoBehaviour {

    public Camera _观画摄像头;

    public float _缩放速率 = 1.0f;
    private float _正在缩放速率 = 0.0f;

    public float _旋转速率 = 100.0f;
    private float _正在旋转速率 = 0.0f;

    public float _移动速率 = 1.0f;
    private Vector2 _正在移动速度 = Vector2.zero;

    private Vector3 _原始位置, _原始尺寸;
    private Quaternion _原始角度;

	// Use this for initialization
	void Start () {
        记录原始尺寸();
    }
	
	// Update is called once per frame
	void Update () {
        float DT = Time.deltaTime;

        _观画摄像头.transform.Translate(DT * _正在移动速度);
        _观画摄像头.transform.Rotate(Vector3.forward, DT * _正在旋转速率);
        _观画摄像头.orthographicSize += DT * _正在缩放速率;
        _观画摄像头.orthographicSize = Mathf.Clamp(
            _观画摄像头.orthographicSize, 0.1f, 10.0f);

    }

    public void 恢复原始尺寸()
    {
        _观画摄像头.transform.localPosition = _原始位置;
        _观画摄像头.transform.localRotation = _原始角度;
        _观画摄像头.transform.localScale = _原始尺寸;
    }

    public void 记录原始尺寸()
    {
        _原始位置 = _观画摄像头.transform.localPosition;
        _原始尺寸 = _观画摄像头.transform.localScale;
        _原始角度 = _观画摄像头.transform.localRotation;
    }

    public void 开始放大()
    {
        _正在缩放速率 = -_缩放速率; 
    }

    public void 开始缩小()
    {
        _正在缩放速率 = _缩放速率;
    }

    public void 停止缩放()
    {
        _正在缩放速率 = 0.0f;
    }   

    public void 开始左旋()
    {
        _正在旋转速率 = _旋转速率;
    }
    
    public void 开始右旋()
    {
        _正在旋转速率 = -_旋转速率;
    }

    public void 停止旋转()
    {
        _正在旋转速率 = 0.0f;
    }    

    public void 开始左移()
    {
        _正在移动速度.x = _移动速率;
    }

    public void 开始右移()
    {
        _正在移动速度.x = -_移动速率;
    }

    public void 开始上移()
    {
        _正在移动速度.y = -_移动速率;
    }

    public void 开始下移()
    {
        _正在移动速度.y = _移动速率;
    }

    public void 停止移动()
    {
        _正在移动速度 = Vector2.zero;
    }

    
}
