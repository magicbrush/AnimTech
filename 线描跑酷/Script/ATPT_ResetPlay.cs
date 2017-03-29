using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATPT_ResetPlay : MonoBehaviour {

	public GameObject _TracerSp;
	private GameObject _ExistingSP = null;
	public UnityEvent _Reset;

	public void ResetPlay()
	{
		Destroy (_ExistingSP);
		_ExistingSP = Instantiate (_TracerSp) as GameObject;
		_ExistingSP.transform.SetParent (transform);
		_ExistingSP.SetActive (true);
		_Reset.Invoke ();
	}
	public ATPT_BrushSprite GetBrushSprite()
	{
		if (_ExistingSP == null) {
			return null;
		}
		ATPT_BrushSprite brs = 
			_ExistingSP.GetComponentInChildren<ATPT_BrushSprite> ();
		return brs;
	}
}
