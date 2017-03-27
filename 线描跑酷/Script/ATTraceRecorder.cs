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
		public TracePoint(TracePointType t, Vector3 p)
		{
			Type = t;
			Pos = p;
		}
		public TracePointType Type;
		public Vector3 Pos;
	}

	public List<TracePoint> _Trace;

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
		Vector3 hitUV = Vector3.zero;
		if (HitTestUVPosition (out hitUV) && bMouse) {
			
			Vector3 move = hitUV - _LastPos;
			Debug.Log ("Movement:" + 10000.0f*move.magnitude);
			if (move.magnitude > _StepMin) {
				_Trace.Add (new TracePoint (TracePointType.STROKE_START, hitUV));
				Debug.Log ("OnMouseDown:" + hitUV);
			}
		}
	}

	void OnMouseDrag()
	{
		Vector3 hitUV = Vector3.zero;
		if (HitTestUVPosition (out hitUV)) {
			
			Vector3 move = hitUV - _LastPos;
			Debug.Log ("Movement:" + 10000.0f*move.magnitude);
			if (move.magnitude > _StepMin) {
				_Trace.Add (new TracePoint (TracePointType.STROKE_POINT, hitUV));
				_LastPos = hitUV;
				Debug.Log ("OnMouseDrag:" + hitUV);
			}
		}
	}

	void OnMouseOver()
	{
		bool bMouse = Input.GetMouseButton (_MouseBtn);
		Vector3 hitUV = Vector3.zero;
		if (HitTestUVPosition (out hitUV) && bMouse) {
			
			Vector3 move = hitUV - _LastPos;
			Debug.Log ("Movement:" + 10000.0f*move.magnitude);
			if (move.magnitude > _StepMin) {
				_Trace.Add (new TracePoint (TracePointType.STROKE_POINT, hitUV));
				_LastPos = hitUV;
				Debug.Log ("OnMouseOver:" + hitUV);
			}
		}
	}

	void OnMouseUp()
	{
		Vector3 hitUV = Vector3.zero;
		if (HitTestUVPosition (out hitUV)) {
			
			Vector3 move = hitUV - _LastPos;
			Debug.Log ("Movement:" + 10000.0f*move.magnitude);
			if (move.magnitude > _StepMin) {
				_Trace.Add (new TracePoint (TracePointType.STROKE_END, hitUV));
				_LastPos = hitUV;
				Debug.Log ("OnMouseUp:" + hitUV);
			}
		}
	}

	void OnMouseEnter()
	{
		bool bMouse = Input.GetMouseButton (_MouseBtn);
		Vector3 hitUV = Vector3.zero;
		if (HitTestUVPosition (out hitUV) && bMouse) {
			
			Vector3 move = hitUV - _LastPos;
			Debug.Log ("Movement:" + 10000.0f*move.magnitude);
			if (move.magnitude > _StepMin) {
				_Trace.Add (new TracePoint (TracePointType.STROKE_START, hitUV));
				_LastPos = hitUV;
				Debug.Log ("OnMouseEnter:" + hitUV);
			}
		}
	}

	void OnMouseExit()
	{
		bool bMouse = Input.GetMouseButton (_MouseBtn);
		Vector3 hitUV = Vector3.zero;
		if (HitTestUVPosition (out hitUV) && bMouse) {
			Debug.Log ("OnMouseExit:" + hitUV);
			Vector3 move = hitUV - _LastPos;
			if (move.magnitude > 0.00001f) {
				_Trace.Add (new TracePoint (TracePointType.STROKE_END, hitUV));
				_LastPos = hitUV;
			}
		}
	}

	bool HitTestUVPosition(out Vector3 pos){
		
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
			Debug.Log ("Exceed Slot Count");
			return;
		}
		_SKRecs [Slot]._Trace = this._Trace;
	}

	public void Load(int Slot)
	{
		if (Slot >= _SKRecs.Count && Slot<0) {
			Debug.Log ("Exceed Slot Count");
			return;
		}
		_Trace = _SKRecs [Slot]._Trace;
	}

	public void ClearTrace()
	{
		_Trace.Clear ();
	}
}
