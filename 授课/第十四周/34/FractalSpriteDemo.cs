using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalSpriteDemo : MonoBehaviour {

	private float RotSpd;

	private static int _Count = 0;

	// Use this for initialization
	void Start () {
		RotSpd = Random.Range (-30.0f, 30.0f);

		transform.localPosition =
			Random.rotationUniform * Vector2.right * 1.8f ;
		transform.localScale = 
			Vector3.one * Random.Range(0.7f,0.95f);

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = Random.ColorHSV ();

		_Count++;
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
				}
			}
		}
	}


}
