using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEachTest : MonoBehaviour {

	public List<Vector3> _Points;

	// Use this for initialization
	void Start () {
		_Points = new List<Vector3> ();
		_Points.Add (new Vector3 (0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0;
			i < _Points.Count; 
			i++) {
			_Points [i] += Vector3.one;
		}

		for (int i = _Points.Count-1; 
			i > 0; 
			i--) {
			_Points [i] += Vector3.one;
		}


		
	}
}
