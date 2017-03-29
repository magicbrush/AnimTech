using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 大小抖动 : MonoBehaviour {

    public float _缩放强度;
    private float trend;
    private float noisePos;
    private Vector3 OriSize;
    private float s;
    void Start()
    {
       
        _缩放强度 = GameObject.Find("SizeSlider").GetComponent<Slider>().value;
        s = Random.Range(0.01f, 0.2f);
    }
        
        // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(s,s, 0);
        OriSize = transform.localScale;

        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        noisePos = Mathf.PerlinNoise(0.01f * x, 0.01f * y)*0.3f;
        Vector3 size = new Vector3(noisePos,noisePos,0)*_缩放强度;
        transform.localScale = OriSize+size;
    }
}
