using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HSV抖动 : MonoBehaviour {
    
    private Color 初始颜色 = new Color();
    private Color PureColor = new Color(120, 120, 120);
    private Color MultiColor = new Color();

    private int R;
    private int G;
    private int B;

    private float x;
    private float y;


    // Use this for initialization
    void Start()
    {
        R = Random.Range(50, 240);
        G = Random.Range(50, 240);
        B = Random.Range(50, 240);
}

    // Update is called once per frame
    public void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        MultiColor = new Color(R, G, B);
         

        if (GameObject.Find("PureColorToggle").GetComponent<Toggle>().isOn)
            初始颜色 = PureColor;
        if (GameObject.Find("MultiColorToggle").GetComponent<Toggle>().isOn)
            初始颜色 = MultiColor;
       
        float 当前颜色H, 当前颜色S, 当前颜色V;
        Color.RGBToHSV(初始颜色, out 当前颜色H, out 当前颜色S, out 当前颜色V);

        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        float noisePos = Mathf.PerlinNoise(0.1f*x,0.1f*y);
        float noiseT = Mathf.PerlinNoise(0.1f*Time.time, 0.1f*Time.time);

        float 色相改变量 = 0.3f*noiseT+ noisePos;
        float 饱和度改变量 = 0.3f*noiseT + noisePos;
        float 明度改变量 = 0.3f*noiseT + noisePos;


        float 改变后颜色H, 改变后颜色S, 改变后颜色V;
        改变后颜色H = Mathf.Repeat(当前颜色H + 色相改变量, 1.0f);
        改变后颜色S = Mathf.Clamp01(当前颜色S + 饱和度改变量);
        改变后颜色V = Mathf.Clamp01(当前颜色V + 明度改变量)*1.2f;

        Color 随机变化后的颜色_rgb模式 =
            Color.HSVToRGB(改变后颜色H, 改变后颜色S, 改变后颜色V);
        sr.color = 随机变化后的颜色_rgb模式;
    }
}
