using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorTransfer : MonoBehaviour {

	public ColorModel _colorModel;
	public float _DeltaFactor = 1.0f;
	public float _AbsorbPower = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public ColorModel GetColorModel()
	{
		return _colorModel;
	}


	public void OnTriggerStay2D(Collider2D other)
	{
		float dt = Time.deltaTime;

		ColorTransfer transferOther = other.GetComponent<ColorTransfer> ();
		if (transferOther==null) {
			return;
		}
		ColorModel colorModelOther = transferOther.GetColorModel ();
		float ColorAmt = _colorModel.GetColorAmount ();
		Vector3 RGBThis = _colorModel.GetRGB ();
		Vector3 RGBOther = colorModelOther.GetRGB ();
		float densityThis = _colorModel.GetDensity ();
		float densityOther = colorModelOther.GetDensity ();
		for (int i = 0; i < 3; i++) {
			float CThis = RGBThis [i];
			float COther = RGBOther [i];

			float deltaC = _DeltaFactor * (CThis - COther) + 1.0f;

			float CAbsorb = 
				dt * _AbsorbPower * ColorAmt * densityThis / 
				(deltaC * densityOther);

			CAbsorb = Mathf.Min (RGBOther [i], CAbsorb);
			RGBOther [i] -= CAbsorb;
			RGBThis [i] += CAbsorb;
		}

		_colorModel.SetRGB (RGBThis);
		colorModelOther.SetRGB (RGBOther);

	}

	public void Absorb()
	{
	}


}
