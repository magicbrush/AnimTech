using UnityEngine;
using System.Collections;

public class AT周期行为基类 : MonoBehaviour {

	protected float _基准时刻 = 0.0f;
	public bool _初始化基准时刻  = true;

	[ContextMenu("初始化基准时刻")]
	public void 初始化基准时刻()
	{
		if (_初始化基准时刻) {
			_基准时刻 = Time.realtimeSinceStartup;
		}
	}

	[ContextMenu("随机化基准时刻")]
	public void 随机化基准时刻()
	{
		_基准时刻 = Random.Range (-99999.0f, 99999.0f);
	}


}
