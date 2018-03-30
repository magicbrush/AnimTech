using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorModel))]
public class DestroyOnColorExhaust : MonoBehaviour {

	public ColorModel _colorModel;
	
	// Update is called once per frame
	void Update () {
		float amt = _colorModel.GetColorAmount ();
		if (amt<=0.0f) {
			Destroy (gameObject);
		}
	}
}
