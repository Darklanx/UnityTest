using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRelativeToCamera : MonoBehaviour {
	public Camera cam;
	public float objectScale = 1.0f; 
	private Vector3 initialScale; 
	// Use this for initialization
	void Start () {
		if(cam == null){
			cam = Camera.main;
		}
		initialScale = transform.localScale; 
	}
	
	// Update is called once per frame
	void Update () {
		Plane plane = new Plane(cam.transform.forward, cam.transform.position); 
		float dist = plane.GetDistanceToPoint(transform.position); 
		transform.localScale = initialScale * dist * objectScale; 
	}
}
