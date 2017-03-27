using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTraceRunner : MonoBehaviour {

	public ATTraceRecorder _Recorder;

	public enum State
	{
		INACTIVE,
		RUNNING,
		PAUSED
	}
	public State _State = State.INACTIVE;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_State == State.RUNNING) {
			
		}
		
	}

	public void PlayRun()
	{
		if (_State == State.INACTIVE) {
			_State = State.RUNNING;
		} else if (_State == State.PAUSED) {
			_State = State.RUNNING;
		}
	}

	public void PauseRun()
	{
		if (_State == State.RUNNING) {
			_State = State.PAUSED;
		}
	}

	public void StopRun()
	{
		if (_State == State.RUNNING) {
			_State = State.INACTIVE;
		} else if (_State == State.PAUSED) {
			_State = State.INACTIVE;
		}
	}
}
