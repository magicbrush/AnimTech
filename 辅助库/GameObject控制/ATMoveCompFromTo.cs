using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMoveCompFromTo : MonoBehaviour {
	public Component From;
	public GameObject TgtObj;

	public void MoveComp()
	{
		if (TgtObj == null)
			return;

		AT_Utils.CopyComponent<Component> (From, TgtObj);
		Destroy (From);
	}
}
