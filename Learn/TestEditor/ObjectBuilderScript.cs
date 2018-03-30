using UnityEngine;
using System.Collections;

public class ObjectBuilderScript : MonoBehaviour 
{
	public Texture2D _Tex;
	public GameObject obj;
	public Vector3 spawnPoint;
	public bool _bON = true;
	public string _Text0,_Text1;

	public void BuildObject()
	{
		Instantiate(obj, spawnPoint, Quaternion.identity);
	}
}