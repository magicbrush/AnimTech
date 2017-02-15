using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AT随机选择图像 : MonoBehaviour {

	public List<Texture2D> _图像组 = new List<Texture2D>();

	[ContextMenu("随机选择图像")]
	public void 随机选择图像()
	{
		if (_图像组.Count == 0)
			return;
		int 图像数量 = _图像组.Count;
		int 随机选择图像的编号 = 
			(int)Random.Range (0, (float)图像数量);
		Texture2D 选中图像 = _图像组 [随机选择图像的编号];
		int 长 = 选中图像.width;
		int 宽 = 选中图像.height;
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.sprite = Sprite.Create (
			选中图像, 
			new Rect (0, 0, 长, 宽),
			0.5f*Vector2.one);
	}
}
