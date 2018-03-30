using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModel : MonoBehaviour {

	public float R = 1.0f;
	public float G = 0.0f;
	public float B = 0.0f;

	[Range(0.01f,1.0f)]
	public float Density = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetRGB(Vector3 rgb)
	{
		R = rgb [0];
		G = rgb [1];
		B = rgb [2];
	}

	public void SetRGB(float r, float g, float b)
	{
		R = r;
		G = g;
		B = b;
	}

	public Vector3 GetRGB()
	{
		return new Vector3 (R, G, B);
	}

	public void SetDensity(float density)
	{
		Density = Mathf.Clamp(density,0.01f,1.0f);
	}
		
	public float GetDensity()
	{
		return Density;
	}

	public  float GetColorAmount()
	{
		return R + G + B;
	}

	public Vector3 GetColorAmount01()
	{
		float amt = GetColorAmount ();
		Vector3 cr01 = Vector3.zero;
		if (amt > 0.0f) {
			cr01 = 3.0f * new Vector3 (R / amt, G / amt, B / amt);
		}
		return cr01;
	}

	public Color GetDispColor()
	{
		float totalAmount = GetColorAmount ();
		Vector3 rgb = GetColorAmount01 ();
		float density = GetDensity ();
		Color cr = new Color (rgb.x, rgb.y, rgb.z,density);
		return cr;
	}


}
