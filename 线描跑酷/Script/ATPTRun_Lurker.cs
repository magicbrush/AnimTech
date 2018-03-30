using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATPTRun_Lurker : MonoBehaviour {

	public UnityEvent _See,_Seeing,_Lost;

	private ATPT_BrushSprite _brs;

	public Color _CrAlert, _CrSeeing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		ATPT_BrushSprite brs = other.GetComponent<ATPT_BrushSprite> ();
		if (brs == null) {
			_brs = null;
			return;
		}
		_See.Invoke ();

		_brs = brs;

		GetComponent<SpriteRenderer> ().color = _CrSeeing;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		ATPT_BrushSprite brs = other.GetComponent<ATPT_BrushSprite> ();
		if (brs == null) {
			_brs = null;
			return;
		}
		_Seeing.Invoke ();
		_brs = brs;
		GetComponent<SpriteRenderer> ().color = _CrSeeing;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		ATPT_BrushSprite brs = other.GetComponent<ATPT_BrushSprite> ();
		if (brs == null) {
			_brs = null;
			return;
		}
		_Lost.Invoke ();
		_brs = brs;
		GetComponent<SpriteRenderer> ().color = _CrAlert;
	}

	public ATPT_BrushSprite GetBrushSprite()
	{
		return _brs;
	}
}
