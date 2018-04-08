using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_2ndODE : MonoBehaviour {
	public float _K = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

	private List<Vector2> _PPrev = new List<Vector2> ();
	// Update is called once per frame
	void Update () {
		//Vector2 P = transform.localPosition;
		if (_PPrev.Count < 2) {
			_PPrev.Add (transform.localPosition);
			return;
		}

		Vector2 P = 
			_K * _PPrev [1] * Mathf.Pow (Time.deltaTime, 2.0f) + 
			2.0f * _PPrev [1] - 
			_PPrev [0];
		transform.localPosition = (Vector3)P;

		_PPrev.Add (P);
		_PPrev.RemoveAt (0);
	}
}
