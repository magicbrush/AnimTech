using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 方向抖动and随机震动 : MonoBehaviour {


    public float _步长;
    private float StepSize;

    // Use this for initialization
    void Start()
    {
        StepSize=GameObject.Find("StepSizeSlider").GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {
        float 随机角度 =180+Random.Range(-80, 80);   //  随机下落方向,即无角度抖动时所有颜料的运动方向 
        Quaternion 随机旋转量 = Quaternion.AngleAxis(随机角度, Vector3.forward);

        _步长 = Random.Range(1,15)*0.001f*StepSize;     

        Vector3 移动量 = new Vector3(Mathf.PerlinNoise(Random.Range(-100,100), Random.Range(-100, 100)),Mathf.PerlinNoise(2,4),0)*_步长;

        移动量 = 随机旋转量 * 移动量;

        transform.Translate(移动量);
    }
 
}
