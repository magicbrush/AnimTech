using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartAgent
{
	public class SA_Seek : SmartAgentBase {

		override public Vector2 EstimateOptimalVel()
		{
			TargetTransform TTF = GetComponent<TargetTransform> ();
			Transform tgtTF = TTF._Target;

			if (tgtTF == null) {
				return Vector2.zero;
			}

			Vector3 TgtPos = tgtTF.position;
			Vector3 CurPos = transform.position;
			Vector2 ToTarget = TgtPos - CurPos;
			Vector2 opVel = (Vector2)Vector3.ClampMagnitude (ToTarget, _MaxSpd);
			return opVel;
		}
	}
}
