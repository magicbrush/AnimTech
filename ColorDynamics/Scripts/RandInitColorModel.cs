using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandInitColorModel : MonoBehaviour {
	public ColorModel _colorModel;

	public Vector3 _Mulitiplier = Vector3.one;
	public float _MinDensity = 0.1f,_MaxDensity = 1.0f;

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Init()
	{
		_colorModel.SetRGB (
			Random.value * _Mulitiplier[0], 
			Random.value * _Mulitiplier[1], 
			Random.value * _Mulitiplier[2]);
		_colorModel.SetDensity (Random.Range (_MinDensity,_MaxDensity));
	}


}
