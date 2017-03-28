using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class ATTraceRecorder : MonoBehaviour {
	public Camera _SceneCamera;
	public int _MouseBtn = 0;
	public float _StepMin = 0.0001f;
	private Vector3 _LastPos = new Vector3(float.NegativeInfinity, 0,0);
	public enum TracePointType
	{
		STROKE_START,
		STROKE_POINT,
		STROKE_END
	}
		
	[System.Serializable]
	public class TracePoint
	{
		public TracePoint(TracePointType t, Vector3 p, TracePoint PrevTP = null)
		{
			Type = t;
			Pos = p;
			if(PrevTP==null)
			{
				Dist = 0.0f;
			}
			else
			{
				Dist = PrevTP.Dist;
				Dist += (Pos - PrevTP.Pos).magnitude;
			}
		}
		public TracePointType Type;
		public Vector3 Pos;
		public float Dist;
	}
	public List<TracePoint> _Trace = new List<TracePoint>();
	public List<ATTraceRecorder> _SKRecs = new List<ATTraceRecorder>();

	// Use this for initialization
	void Start () {
		if (_SceneCamera == null) {
			_SceneCamera = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		bool bMouse = Input.GetMouseButton (_MouseBtn);
		Vector3 hitPos = Vector3.zero;
		if (HitTestPosition (out hitPos) && bMouse) {
			AddTracePoint (TracePointType.STROKE_START, hitPos);
			//Debug.Log ("OnMouseDown"+ hitPos);
		}
	}

	void OnMouseDrag()
	{
		Vector3 hitPos = Vector3.zero;
		if (HitTestPosition (out hitPos)) {
			AddTracePoint (TracePointType.STROKE_POINT, hitPos);
			//Debug.Log ("OnMouseDrag"+ hitPos);
		}
	}

	void OnMouseOver()
	{
		bool bMouse = Input.GetMouseButton (_MouseBtn);
		Vector3 hitPos = Vector3.zero;
		if (HitTestPosition (out hitPos) && bMouse) {
			AddTracePoint (TracePointType.STROKE_POINT, hitPos);
			//Debug.Log ("OnMouseOver"+ hitPos);
		}
	}

	void OnMouseUp()
	{
		Vector3 hitPos = Vector3.zero;
		if (HitTestPosition (out hitPos)) {
			//Debug.Log ("OnMouseUp"+ hitPos);
			AddTracePoint (TracePointType.STROKE_END, hitPos);
		}
	}

	void OnMouseEnter()
	{
		bool bMouse = Input.GetMouseButton (_MouseBtn);
		Vector3 hitPos = Vector3.zero;
		if (HitTestPosition (out hitPos) && bMouse) {
			//Debug.Log ("OnMouseEnter"+ hitPos);
			AddTracePoint (TracePointType.STROKE_START, hitPos);
		}
	}

	void OnMouseExit()
	{
		bool bMouse = Input.GetMouseButton (_MouseBtn);
		Vector3 hitPos = Vector3.zero;
		if (HitTestPosition (out hitPos) && bMouse) {
			AddTracePoint (TracePointType.STROKE_END, hitPos);
			//Debug.Log ("OnMouseExit"+ hitPos);
		}
	}

	void AddTracePoint (TracePointType tptype, Vector3 curPos)
	{
		Vector3 move = curPos - _LastPos;
		if (tptype == TracePointType.STROKE_END || 
			tptype == TracePointType.STROKE_START) {

		}

		if (move.magnitude > _StepMin) {
			AddTracePointAtPos (tptype, curPos);
		} else {
			if (tptype == TracePointType.STROKE_END || tptype == TracePointType.STROKE_START) {
				curPos += _StepMin * (Vector3)Random.insideUnitCircle;
				AddTracePointAtPos (tptype, curPos);
			}
		}
		_LastPos = curPos;
	}

	void AddTracePointAtPos (TracePointType tptype, Vector3 curPos)
	{
		if (_Trace.Count > 0) {
			_Trace.Add (new TracePoint (tptype, curPos, _Trace [_Trace.Count - 1]));
		}
		else {
			_Trace.Add (new TracePoint (tptype, curPos, null));
		}
	}

	bool HitTestPosition(out Vector3 pos){
		
		pos = new Vector3 (float.NaN, 0, 0);

		RaycastHit hit;
		Vector3 cursorPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		Ray cursorRay=_SceneCamera.ScreenPointToRay (cursorPos);
		if (Physics.Raycast(cursorRay,out hit,200)){
			MeshCollider meshCollider = hit.collider as MeshCollider;
			if (meshCollider != GetComponent<MeshCollider> ())
				return false;
			if (meshCollider == null || meshCollider.sharedMesh == null)
				return false;	
			
			pos = hit.point;

			return true;
		}
		else{	
			return false;
		}
	}

	public void Save(int Slot)
	{
		if (Slot >= _SKRecs.Count && Slot<0) {
			//Debug.Log ("Exceed Slot Count");
			return;
		}
		_SKRecs [Slot]._Trace = this._Trace;
	}

	public void Load(int Slot)
	{
		if (Slot >= _SKRecs.Count && Slot<0) {
			//Debug.Log ("Exceed Slot Count");
			return;
		}
		_Trace = _SKRecs [Slot]._Trace;
	}

	public void ClearTrace()
	{
		_Trace.Clear ();
	}

	public bool GetInterpPosAtId(int id, float dist, out Vector3 pos)
	{
		pos = new Vector3 (float.NegativeInfinity, 0, 0);
		if (id >= _Trace.Count - 1 || id<0) {
			return false;
		}
		//Debug.Log ("id:" + id);
		if(_Trace [id].Dist > dist)
		{
			return false;
		}
		if(_Trace[id+1].Dist <dist)
		{
			return false;
		}
		Vector3 p0 = _Trace [id].Pos;
		Vector3 p1 = _Trace [id + 1].Pos;
		float t = (dist - _Trace [id].Dist) / (_Trace [id + 1].Dist - _Trace [id].Dist);
		pos = Vector3.Lerp(p0,p1,t);

		return true;
	}

	public bool GetNextIdBeforeDist(float dist, int fromId, out int nextId)
	{
		nextId = -1;
		if (fromId >= _Trace.Count - 1) {
			//Debug.Log ("fromId >= _Trace.Count - 1");
			return false;
		}

		if (_Trace [fromId].Dist > dist) {
			//Debug.Log ("_Trace [fromId].Dist > dist");
			bool bJust = IsDistJustAfterId (dist,fromId);
			return false;
		}

		int nxt = fromId;
		while (_Trace [nxt].Dist < dist) {
			nxt += 1;
			//Debug.Log ("nxt:" + nxt);
			if (nxt >= _Trace.Count - 1) {
				//Debug.Log ("Exceed!");
				return false;
			}
		}
		nextId = nxt-1;
		return true;
		
	}

	public bool IsDistJustAfterId(float dist, int id)
	{
		if (id < 0 || id > _Trace.Count - 2) {
			return false;
		}

		if (_Trace [id].Dist <= dist && _Trace [id + 1].Dist >= dist) {
			return true;
		} else {
			return false;
		}

	}

	public bool DistExceedTrace(float dist)
	{
		if (_Trace.Count < 2) {
			return false;
		}

		return _Trace [_Trace.Count - 1].Dist < dist;
	}
}
