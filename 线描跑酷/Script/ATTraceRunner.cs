using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ATTraceRunner : MonoBehaviour {

	public ATTraceRecorder _Recorder;
	public enum PosMode
	{
		LOCAL,
		GLOBAL
	}
	public PosMode _posMode = PosMode.GLOBAL;

	public enum State
	{
		INACTIVE,
		RUNNING,
		PAUSED
	}
	public State _State = State.INACTIVE;

	public float _Speed = 1.0f;
	public enum StepIntervalMode
	{
		CONTINUAL,
		STEP_OVER,
	}
	public StepIntervalMode _stepIntervalMode = StepIntervalMode.CONTINUAL;

	public float _PassedDist = 0.0f;
	private int _lastID=0;

	public float _DispLength = 1.0f;
	public float _zBias = -1.0f;
	public int _LengthCount = 50;
	private LineRenderer _LR;

	public UnityEvent _BeginPlay, _PausePlay,_StopPlay;

	[System.Serializable]
	public class Status
	{
		public float HP = 5.0f;
		public float HPMax = 10.0f;
		public void AddHP(float hp)
		{
			HP += hp;
			HP = Mathf.Clamp (HP, 0, HPMax);
		}
		public float getHPNorm()
		{
			return HP / HPMax;
		}
		public void SetHP(float hp)
		{
			HP = Mathf.Clamp (hp, 0, HPMax);
		}
		public UnityEvent _Die;
	}
	public Status _Status;


	// Use this for initialization
	void Start () {
		
		_LR = GetComponent<LineRenderer> ();
		InitLineRenderer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsTraceTooShort() || IsRunOverTheTrace())
			return;
		
		if (_State == State.RUNNING) {
			PlaceAtCurrentDist ();
			bool bExceed = _Recorder.DistExceedTrace (_PassedDist);
			if (bExceed) {
				StopRun ();
			}

			float dt = Time.deltaTime;
			float dDist = dt * _Speed;
			_PassedDist += dDist;

			bool bJustAfter = _Recorder.IsDistJustAfterId (_PassedDist, _lastID);
			if (!bJustAfter) {
				bool bAfter0 = _Recorder.IsDistJustAfterId (_PassedDist, _lastID);
				int id = _lastID;
				int idLast = _lastID;
				//Debug.Log ("_LastID:" + idLast);
				bool bAfter1 = _Recorder.IsDistJustAfterId (_PassedDist, _lastID);
				bool bHasNext = _Recorder.GetNextIdBeforeDist (_PassedDist, id, out idLast);

				if (idLast > _lastID) {
					SetLineRendererPositions (_LengthCount);
				}
				//Debug.Log ("_LastID:" + idLast);
				_lastID = idLast;
			}

			StatusChange (dDist);
		}
		
	}

	void StatusChange (float dDist)
	{
		_Status.HP -= dDist;
		if (_Status.HP <= 0.0f) {
			_Status._Die.Invoke ();
			Destroy (gameObject);
		}
	}

	bool IsTraceTooShort()
	{
		return (_Recorder._Trace.Count <= 2);
	}

	bool IsRunOverTheTrace()
	{
		return (_lastID + 1 > _Recorder._Trace.Count - 1);
	}

	void PlaceAtCurrentDist ()
	{
		Vector3 Pos;
		bool bGet = _Recorder.GetInterpPosAtId (_lastID, _PassedDist, out Pos);
		if (!bGet) {
			return;
		}
		if (_posMode == PosMode.GLOBAL) {
			transform.position = Pos;
		}
		else {
			transform.localPosition = Pos;
		}
	}

	public void PlayRun()
	{
		if (_State == State.INACTIVE) {
			_State = State.RUNNING;
		} else if (_State == State.PAUSED) {
			_State = State.RUNNING;
		}
		_BeginPlay.Invoke ();
	}

	public void PauseRun()
	{
		if (_State == State.RUNNING) {
			_State = State.PAUSED;
			_PausePlay.Invoke ();
		}
	}

	public void StopRun()
	{
		if (_State == State.RUNNING) {
			_State = State.INACTIVE;
		} else if (_State == State.PAUSED) {
			_State = State.INACTIVE;
		}
		_StopPlay.Invoke ();
		ResetToTraceStart ();
	}

	void ResetToTraceStart ()
	{
		_PassedDist = 0.0f;
		_lastID = 0;
	}

	public float GetSpeed()
	{
		return _Speed;
	}
	public void SetSpeed(float spd)
	{
		_Speed = spd;
	}

	public void InitLineRenderer()
	{
		int cnt =_LengthCount;
		_LR.positionCount = cnt;
		List<Vector3> Pos = new List<Vector3> ();
		for (int i = 0; i < cnt; i++) {
			Pos.Add (_Recorder._Trace[0].Pos);
		}
		SetLineRendererPositions (cnt);
	}

	void SetLineRendererPositions (int cnt)
	{
		int traceCnt = _Recorder._Trace.Count;
		for (int i = 0; i < cnt; i++) {
			int id = i + _lastID;

			if (id > traceCnt - 1) {
				id = traceCnt - 1;
			}
			Vector3 pos = _Recorder._Trace [id].Pos;
			pos.z += _zBias;
			//Debug.Log ("Pos[" + i + "]:" + pos);
			_LR.SetPosition (i, pos);
		}
	}

}
