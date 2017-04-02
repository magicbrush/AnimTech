using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATSwapWithParent : MonoBehaviour {
	public bool _useParentPosition = true;
	public void SwapWithParent()
	{
		if (transform.parent == null)
			return;

		Transform curParent = transform.parent;
		transform.SetParent (curParent.parent,!_useParentPosition);
		curParent.SetParent (transform,true);



	}
}
