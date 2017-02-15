using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AT_泊松过程触发器 : MonoBehaviour {

	public UnityEvent _PoissonProcessEvent;
	public float _lamda = 1.0f;

	private float _rvalue = Random.value;
	private float _passedTime = 0.0f;

	// Update is called once per frame
	void Update () {
		_passedTime += Time.deltaTime;

		float pvalue = 
			1.0f - Mathf.Exp(-_lamda * _passedTime);
		//Debug.Log("pvalue:"+pvalue);

		if(pvalue>=_rvalue)
		{
			_PoissonProcessEvent.Invoke();
			//Debug.Log("Poisson Happen at:" + _passedTime);
			_rvalue = Random.value;
			_passedTime = 0.0f;
		}	
	}
}
