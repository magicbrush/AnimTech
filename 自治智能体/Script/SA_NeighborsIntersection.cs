using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartAgent
{
	public class SA_NeighborsIntersection : MonoBehaviour {
		public SA_Neighbors[] _Neighbors;

		public List<Rigidbody2D> _Intersection = new List<Rigidbody2D>();

		[ContextMenu("GetSANeighbors")]
		void GetSANeighbors()
		{
			_Neighbors = GetComponentsInChildren<SA_Neighbors> ();
		}

		[ContextMenu("GetIntersection")]
		public List<Rigidbody2D> GetIntersection()
		{
			_Intersection.Clear ();
			foreach(SA_Neighbors snb in _Neighbors)
			{
				foreach (Rigidbody2D rb in snb._Neighbors) {
					_Intersection.Add (rb);
				}
			}

			/*
			var itr = _Intersection.GetEnumerator ();
			while (itr.MoveNext ()) {
				Rigidbody2D rb = itr.Current;
				foreach(SA_Neighbors snb in _Neighbors)
				{
					if (!snb._Neighbors.Contains (rb)) {
						//_Intersection.
					}
				}
			}*/

			foreach (Rigidbody2D rb in _Intersection) {
				foreach(SA_Neighbors snb in _Neighbors)
				{
					if (!snb._Neighbors.Contains (rb)) {
						_Intersection.Remove (rb);
					}
				}
			}
			return _Intersection;
		}
	}
}
