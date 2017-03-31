using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum IngredientUnit { Spoon, Cup, Bowl, Piece }

// Custom serializable class
[System.Serializable]
public class Ingredient{
	string name;
	int amount = 1;
	IngredientUnit unit;
}

public class TestSerializableClass : MonoBehaviour {
	Ingredient potionResult;
	Ingredient[] potionIngredients;

	void Update () {
		// Update logic here...
	}
}
