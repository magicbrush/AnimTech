using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class ATStrokeRecorder : MonoBehaviour {

	public Camera _SceneCamera;

	// Use this for initialization
	void Start () {
		if (_SceneCamera == null) {
			_SceneCamera = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDrag()
	{
		//MeshCollider mcld = GetComponent<MeshCollider> ();
		Vector2 hitUV = Vector2.zero;
		if (HitTestUVPosition (out hitUV)) {
			Debug.Log ("hitUV:" + hitUV);
		}
	}

	bool HitTestUVPosition(out Vector2 uv){
		uv = new Vector2 (float.NaN, float.NaN);
		RaycastHit hit;
		Vector3 cursorPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		Ray cursorRay=_SceneCamera.ScreenPointToRay (cursorPos);
		if (Physics.Raycast(cursorRay,out hit,200)){
			MeshCollider meshCollider = hit.collider as MeshCollider;
			if (meshCollider != GetComponent<MeshCollider> ())
				return false;
			if (meshCollider == null || meshCollider.sharedMesh == null)
				return false;	
			
			uv.x = hit.textureCoord.x;
			uv.y = hit.textureCoord.y;
			return true;
		}
		else{	
			return false;
		}
	}
}
