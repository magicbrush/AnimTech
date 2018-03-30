using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelScript : MonoBehaviour 
{
	public int experience;

	public int Level
	{
		get { return experience / 750; }
	}
}
