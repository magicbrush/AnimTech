using UnityEngine;
using System.Collections;

public class AT_MathUtil {

	public static float map(
		float Input, 
		float inMin,
		float inMax,
		float outMin,
		float outMax)
	{
		float inBound = inMax - inMin;
		float outBound = outMax - outMin;
		float input01 = (Input - inMin) / inBound;
		float output = input01 * outBound + outMin;

		return output;
	}
}
