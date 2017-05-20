using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_FractalTree : MonoBehaviour {
	public float _Prob = 0.01f;
	public int _MaxForkCount = 100;
	public float _NoiseSpd = 1.0f;
	public float _NoiseScale = 1.0f;
	public float _SpdScale = 1.0f;

	private int _EggCount;
	private Vector3 _Velocity;
	private Vector2 _NoiseStart;

	private static int _totalCount = 0;

	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.one;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Random.rotation;

		_EggCount = Mathf.CeilToInt(Random.Range (1, 4));
		_Velocity = Random.insideUnitCircle * (_SpdScale + 1.0f);
		_NoiseStart = Random.insideUnitCircle;
	}
	
	// Update is called once per frame
	void Update () {
		BornChildFork ();
		NoiseVelocity ();
		Move ();
	}

	void BornChildFork ()
	{
		if (_EggCount > 0 && _totalCount < _MaxForkCount) {
			float rvalue = Random.value;
			if (rvalue < _Prob) {
				GameObject chd = Instantiate (gameObject, transform) as GameObject;
				_EggCount--;
				_totalCount++;
			}
		}
	}

	void NoiseVelocity ()
	{
		float noiseValue = Mathf.PerlinNoise (_NoiseStart.x + Time.realtimeSinceStartup, _NoiseStart.y) - 0.5f;
		noiseValue *= _NoiseScale;
		Vector3 DeltaVel = Random.rotation * Vector3.right;
		DeltaVel.Normalize ();
		DeltaVel *= noiseValue;
		_Velocity += DeltaVel;


	}

	void Move ()
	{
		Vector3 Pos = transform.position;
		Vector3 DeltaMove = Time.deltaTime *  _Velocity;
		//DeltaMove = Vector3.Scale (DeltaMove, transform.lossyScale);

		Vector3 PosNew = Pos + DeltaMove;
		transform.position = PosNew;
	}
}
