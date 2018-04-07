using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_Absorbit : MonoBehaviour {

	[Header("Model DE: dC_other/dt =  a * C_this * Rho / r ^( b * _Rho) ")]

	[Header("The amount of Absorbit:")]
	public float _C = 1.0f;

	[Header("The density of Absorbit:")]
	[Range(0.1f,1.0f)]
	public float _Rho = 0.5f;

	[Header("Constants:")]
	public float _a = 1.0f;
	public float _b = 1.0f;

	public float _DistanceMultiplier = 1.0f;

	// -------------- get/set -----------------------//
	public float GetC()
	{
		return _C;
	}

	public void SetC(float c)
	{
		_C = Mathf.Clamp (c, 0.0f, float.PositiveInfinity);
	}

	public float GetRho()
	{
		return _Rho;
	}

	public void SetRho(float rho)
	{
		_Rho = Mathf.Clamp (rho, 0.1f, 1.0f);
	}

	public float GetA()
	{
		return _a;
	}

	public float GetB()
	{
		return _b;
	}

	// ---------------- start/update ----------------------//
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Transform parentTF = transform.parent;
		AT_Absorbit[] SibAbsorbits = parentTF.GetComponentsInChildren<AT_Absorbit> ();
		foreach (var sibAbsorbit in SibAbsorbits) {
			if (sibAbsorbit == this) {
				continue;
			}
			AbsorbFromOther (sibAbsorbit, Time.deltaTime);
		}

		gameObject.name = "Absorbit_" + _C.ToString ();
		
	}

	void AbsorbFromOther(AT_Absorbit other, float dt)
	{
		// 计算距离
		Vector3 posThis = transform.position;
		Vector3 posOther = other.transform.position;
		Vector3 offset = posOther - posThis;
		float dist = offset.magnitude * _DistanceMultiplier;

		// 计算吸收速率
		float absorbSpd = _a * _Rho / (0.01f + Mathf.Pow (dist, _b * _Rho));

		// 算出量的变化
		float dC = absorbSpd * dt;
		float COther = other.GetC ();
		dC = Mathf.Clamp( Mathf.Min (dC, COther),0.0f,float.PositiveInfinity);

		// 减少对方的量
		float COther2 = COther - dC;
		other.SetC (COther2);

		// 增加自己的量
		_C += dC;

	}


}
