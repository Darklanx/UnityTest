using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Follow : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 wantedPos = Camera.main.WorldToScreenPoint (target.transform.position);
		transform.position = wantedPos;
	}
}
