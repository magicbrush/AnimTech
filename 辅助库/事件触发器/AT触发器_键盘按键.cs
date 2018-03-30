using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT触发器_键盘按键 : MonoBehaviour {

	public enum InvokeType
	{
		BUTTON_DOWN,
		BUTTON_UP,
		BUTTON_KEEP
	}
	[System.Serializable]
	public class KeyInvoker
	{
		public InvokeType _Type;
		public KeyCode _Key;
		public UnityEvent _Invoke;
	}

	public List<KeyInvoker> _Invokers = new List<KeyInvoker>();
	
	// Update is called once per frame
	void Update () {
		foreach (KeyInvoker ki in _Invokers) {
			bool down = Input.GetKeyDown (ki._Key);
			bool up = Input.GetKeyDown (ki._Key);
			bool keep = Input.GetKey (ki._Key);
			if ((ki._Type == InvokeType.BUTTON_DOWN && down) || 
				(ki._Type == InvokeType.BUTTON_UP && up) || 
				(ki._Type == InvokeType.BUTTON_KEEP && keep)) {
				ki._Invoke.Invoke ();
			} 
		}
	}
}
