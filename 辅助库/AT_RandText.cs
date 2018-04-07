using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AT_RandText : MonoBehaviour {

	public int TextLengthMin = 1;
	public int TextLengthMax = 5;
	[System.Serializable]
	public class EventWithText: UnityEvent<string>
	{

	};

	public EventWithText _RandText;

	public void RandText()
	{
		string txt = "";
		int len = Random.Range (TextLengthMin, TextLengthMax);
		for (int i = 0; i < len; i++) {
			char c = (char)Random.Range (0, 255);
			txt += c;
		}
		_RandText.Invoke (txt);
	}
}
