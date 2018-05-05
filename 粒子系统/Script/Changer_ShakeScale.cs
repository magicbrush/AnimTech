using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer_ShakeScale : Changer {

	public float Freq = 20.0f;
	public Vector3 BaseScale = Vector3.one;
	public Vector3 Amplitude = 0.2f * Vector3.one;

	public override void Change ()
	{
		Vector3 scl = BaseScale;
		for (int i = 0; i < 3; i++) {
			float vib = Amplitude [i] * Mathf.Sin (
				Freq * Time.realtimeSinceStartup);
			scl [i] += vib;
		}
		transform.localScale = scl;

	}
}
