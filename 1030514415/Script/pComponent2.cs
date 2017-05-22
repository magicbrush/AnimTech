using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pComponent2 : MonoBehaviour {

	public float _ForceMultiplier = 1.0f;
	public float random_V = 1.0f;
	public float minScale = 0.6f,maxScale = 1.4f;
	private float noise_y;
	private Vector3 ori_Scale = Vector3.zero;

	pComponent1 p1=new pComponent1();

	void Start () {
		noise_y = Random.value * 100.0f;
		ori_Scale = transform.localScale;
	}

	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		float time = Time.realtimeSinceStartup;
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		p1.RandomAction (rb);
		p1.ChangeColor (sr);
		noiseScale (time);
	}

	public void noiseScale(float Time) {
		float randomScale = Mathf.PerlinNoise(Time * random_V, noise_y);
		randomScale = AT_MathUtil.map(randomScale, 0.0f, 1.0f, minScale, maxScale);
		Vector3 randomScale_v3 = ori_Scale * randomScale;

		transform.localScale = randomScale_v3;
	}
}
