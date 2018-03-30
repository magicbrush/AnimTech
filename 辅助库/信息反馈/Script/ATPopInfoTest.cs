using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lyu
{
public class ATPopInfoTest : MonoBehaviour {
	public KeyCode _Key;
	public string _Info = "信息";
	public KeyCode _Key1,_Key2;
	public string _Info1,_Info2;
	public KeyCode _Key3;
	public string _Info3;
	public GameObject _Deco3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (_Key)) {
			PopupInformer.Instance().PushTextInfo (
				_Info, transform.position,0,5.0f,5.0f,5.0f); // the simplest usage
		}

		if (Input.GetKeyUp (_Key1)) {
			PopupInformer.Instance ().SetDecoration ("NoiseWaving");// use predefined decoration
			PopupInformer.Instance().PushTextInfo (
				_Info, transform.position,0,5.0f,5.0f,5.0f);
		}

		if (Input.GetKeyUp (_Key2)) {
			PopupInformer.Instance ().SetDecoration ("Trembling"); // use predefined decoration
			PopupInformer.Instance().PushTextInfo (
				_Info, transform.position,Color.green,0,5.0f,5.0f,5.0f);
		}

		if (Input.GetKeyUp (_Key3)) {
			PopupInformer.Instance ().PushDecoration ();
			PopupInformer.Instance ().SetDecoration (_Deco3);// Input a Decorative Object from outside
			PopupInformer.Instance().PushTextInfo (
				_Info, transform.position,Color.yellow,0,5.0f,5.0f,5.0f);
			PopupInformer.Instance ().PopDecoration ();
			PopupInformer.Instance().PushTextInfo (
				"囧", transform.position,Color.cyan,0,15.0f,5.0f,12.0f);
		}
	}




}
}
