using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard_Facing : MonoBehaviour {
	public Camera main_camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt (transform.position + main_camera.transform.rotation * Vector3.forward,
			main_camera.transform.rotation * Vector3.up);	
	}
}
