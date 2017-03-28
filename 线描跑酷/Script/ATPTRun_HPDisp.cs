using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATPTRun_HPDisp : MonoBehaviour {

	public ATTraceRunner _Runner;
	public LineRenderer _LRHP,_LRHPMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		UpdateHPDisplay ();
	}

	[ContextMenu("UpdateHPDisplay")]
	public void UpdateHPDisplay()
	{
		Vector3 p0 = _LRHP.GetPosition (0);
		float hpNorm = _Runner._Status.getHPNorm ();
		float hpBarLenMax = _LRHPMax.GetPosition (1).x;
		float hpBarLen = hpNorm * hpBarLenMax;
		_LRHP.SetPosition (1, new Vector3 (hpBarLen, 0, p0.z));
	}
}
