using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Lorenz : MonoBehaviour {

	// 洛伦兹方程的三个参数
	public float Sigma, Ro, Beta;
	// Vel <--> dx/dt,dy/dt,dz/dt
	public Vector3 Vel = Vector3.zero;

	//  控制总体快慢
	public float _Spd = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 获得当前位置 x,y,z
		Vector3 LocPos = transform.localPosition;
		float x, y, z;
		x = LocPos.x;
		y = LocPos.y;
		z = LocPos.z;

		// 根据洛伦兹方程计算速度
		float vx, vy, vz; // dx/dt, dy/dy, dz/dy
		vx = Sigma * (y - x); 
		vy = x * (Ro - z) - y;
		vz = x * y - Beta * z;
		Vel = new Vector3 (vx, vy, vz);

		// 根据速度计算瞬时位移
		float dt = Time.deltaTime * _Spd;
		Vector3 deltaMovement =  Vel * dt;

		// 移动物体
		Vector3 LocPosNew = LocPos + deltaMovement;
		transform.localPosition = LocPosNew;
	}
}
