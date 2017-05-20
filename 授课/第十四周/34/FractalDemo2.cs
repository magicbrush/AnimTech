using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalDemo2 : MonoBehaviour {

	private float RotSpd;

	private static int _Count = 0;

	// Use this for initialization
	void Start () {
		
		RotSpd = 100.0f-(float)_Count;

		transform.localPosition =
			Random.rotationUniform * Vector2.right * 1.8f ;
		transform.localScale = Vector3.one * 0.8f;

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = new Color (
			(float)_Count / 200.0f,
			(float)_Count / 300.0f,
			1.0f - (float)_Count / 400.0f);


	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, RotSpd * Time.deltaTime));

		if(Input.GetKeyDown(KeyCode.A))
		{
			for (int i = 0; i < 4; i++) {
				if (_Count < 400) {
					GameObject newSP = 
						Instantiate (gameObject) as GameObject;
					newSP.transform.SetParent (transform, true);
					_Count++;
				}
			}
		}
	}
}
