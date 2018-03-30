using UnityEngine;
using System.Collections;

public class AT自定概率分布随机值生成器 
{
	public static float 根据分布生成随机数(
		AnimationCurve 概率分布曲线, 
		float x最小值, 
		float x最大值)
	{
		float 随机值 = 0.0f;
		bool 生成完成 = false;
		int 剩余尝试次数 = 100;
		do{
			float x随机值 = Random.Range(x最小值,x最大值);
			float x随机值出现的概率 = 概率分布曲线.Evaluate(x随机值);
			float y判定值 = Random.Range(0.0f,1.0f);
			if( y判定值 < x随机值出现的概率 )
			{
				生成完成 = true;
				随机值 = x随机值;
			}
			剩余尝试次数 --;
		}
		while(!生成完成 && 剩余尝试次数>0);

		return 随机值;
	}

}

