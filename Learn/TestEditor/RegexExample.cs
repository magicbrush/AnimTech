using UnityEngine;

public class RegexExample : MonoBehaviour {
	public string name;
	public GameObject tankModel;

	[Regex (@"^(?:\d{1,3}\.){3}\d{1,3}$", "Invalid IP address!\nExample: '127.0.0.1'")]
	public string serverAddress = "192.168.0.1";

}