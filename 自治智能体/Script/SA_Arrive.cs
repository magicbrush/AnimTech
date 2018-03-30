using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SmartAgent
{
	public class SA_Arrive : MonoBehaviour {
		public float _DistThres = 1.0f;
		private bool _bArrivePrev = false;
		public bool _checkInUpdate = true;
		public UnityEvent _Arrive, _Leave;

		void Update()
		{
			if (_checkInUpdate) {
				IsArrived ();
			}
		}

		public bool IsArrived()
		{
			TargetTransform TTF = GetComponent<TargetTransform> ();
			Vector3 tgtPos = TTF._Target.position;

			Vector3 curPos = transform.position;
			Vector3 offset = tgtPos - curPos;
			offset.z = 0.0f;
			float dist = offset.magnitude;

			bool bArrive = (dist <= _DistThres);
			if (_bArrivePrev != bArrive) {
				if (bArrive) {
					_Arrive.Invoke ();
				} else {
					_Leave.Invoke ();
				}
			}
			return bArrive;
		}
	}
}
