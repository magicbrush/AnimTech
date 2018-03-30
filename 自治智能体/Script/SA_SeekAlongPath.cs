using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SmartAgent
{
	public class SA_SeekAlongPath : SmartAgentBase {

		public UnityEvent _Finished;
		public List<Transform> _PathPoints;
		public float _DistThres = 0.1f;
		private int _PathPtId = 0;
		private bool _bFinished = false;

		public override Vector2 EstimateOptimalVel()
		{
			Vector2 vel=Vector2.zero;

			bool bFinish = _PathPtId >= _PathPoints.Count - 1;
			if (bFinish) {
				if (!_bFinished) {
					_Finished.Invoke ();
				}
			} else {
				Transform tgtTF = _PathPoints [_PathPtId];

				Vector3 CurPos = transform.position;
				Vector3 TgtPos = tgtTF.position;
				Vector3 Offset = TgtPos - CurPos;

				vel = (Vector3)Offset;
				vel = vel.normalized * _MaxSpd;

				bool bApproach = Approach (tgtTF);
				if (bApproach) {
					_PathPtId++;
				}
			}
			_bFinished = bFinish;

			return vel;
		}

		[ContextMenu("Reset")]
		public void Reset()
		{
			_PathPtId = 0;
			_bFinished = false;
		}

		private bool Approach(Transform tgtTF)
		{
			Vector3 CurPos = transform.position;
			Vector3 TgtPos = tgtTF.position;
			Vector2 Offset = (Vector2)(TgtPos - CurPos);

			if (Offset.magnitude <= _DistThres) {
				return true;
			} else {
				return false;
			}
		}

		public void SetPathPointsList(List<Transform> _pathPts)
		{
			_PathPoints = _pathPts;
		}

	}
}
