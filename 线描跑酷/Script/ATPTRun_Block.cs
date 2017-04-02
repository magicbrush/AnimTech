using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATPTRun_Block : MonoBehaviour {
	public UnityEvent _Kill,_Solve;
	public enum BlockType
	{
		SMALLER,
		LARGER
	}
	public BlockType _blkType = BlockType.LARGER;

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
			return;
		}

		float scl = brs.transform.lossyScale.x;

		float myScl = transform.lossyScale.x;

		//Debug.Log ("scl:" + scl + " blockScl:" + myScl);
		bool bBlock = false;
		if (_blkType == BlockType.LARGER) {
			bBlock = (scl > myScl);
		} else if (_blkType == BlockType.SMALLER) {
			bBlock = (scl < myScl);
		}

		if (bBlock) {
			brs.Die ();
			_Kill.Invoke ();
		} else {
			_Solve.Invoke ();
			Destroy (gameObject);
			PopupInformer.Instance().PushTextInfo (
				"哈哈哈哈",
				gameObject.transform.position, 
				0, 5.0f, 5.0f, 5.0f);
		}

	}
}
