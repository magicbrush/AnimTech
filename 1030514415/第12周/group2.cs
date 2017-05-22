using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class group2 : MonoBehaviour {

	public float _Multiplier = 1.0f;
	public float _MaxForce = 1.0f;
	public float _MaxSpd = 1.0f;
	public float _MultipRand = 1.0f;
	public float xx=0.8f;
	public float yy=0.5f;
	public float d=0.05f;

	private List<Vector3> _Pos = new List<Vector3> ();

	// Use this for initialization
	void Start () {
		_Multiplier += Random.Range (-_MultipRand, _MultipRand);
	}

	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Vector3 localpos = rb.transform.localPosition;
		Vector2 vel = rb.velocity;

		//判断是否在范围内，给出新的预期速度和转向力
		Vector2 desired = new Vector2(0.0f,0.0f);

		if (localpos.x < d-0.8f ) {
			desired = new Vector2(_MaxSpd, vel.y);
		}
		else if (localpos.x > 0.8f-d  ) {
			desired = new Vector2(-_MaxSpd, vel.y);
		}

		if (localpos.y < 0.5f+d ) {
			desired = new Vector2(vel.x, _MaxSpd);
		}
		else if (localpos.y > 1.5f-d) {
			desired = new Vector2(vel.x, -_MaxSpd);
		}

		if (desired != new Vector2(0.0f,0.0f)) {
			desired=desired.normalized* _MaxSpd;
			Vector2 steer = desired-vel;
			steer=steer.normalized * _MaxForce;
			rb.AddForce(steer);
		}
	}

	void OnTriggerStay2D(Collider2D another)  //彼此分开
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Vector2 vel = rb.velocity;

		Vector3 localpos = rb.transform.localPosition;

		Vector2 separationVel = 
			transform.position - another.transform.position;
		separationVel = 
			separationVel.normalized* _MaxSpd;

		Vector2 force = separationVel - vel;
		if (force.magnitude > _MaxForce) {
			force = force.normalized * _MaxForce;
		}
		force *= _Multiplier;

		rb.AddForce (force);

	}
}
