using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class 角度抖动 : MonoBehaviour
{

    private float angle;
    private float dir;
    private float time;
    private float GetAngle;
    private float RotateSpeed;


    // Use this for initialization
    void Start()
    {
        time = 0;

        GetAngle = GameObject.Find("AngleSlider").GetComponent <Slider> ().value;
        

    }

    // Update is called once per frame
     void Update()
     {
         angle = GetAngle;
        RotateSpeed = GameObject.Find("RotateSpeedSlider").GetComponent<Slider>().value;

        if (time % RotateSpeed == 0) 
         {
             //随机摆动方向
             dir = Random.Range(0, 3) - 1;
             if (dir < 0)
                 dir = -1;
             else if (dir < 1)
                 dir = 0;
             else
                 dir = 1;

             Quaternion turn =
                 Quaternion.AngleAxis(dir * angle, Vector3.forward);
             transform.localRotation = turn;
         }

         time += 1;
     }

}

   


    
