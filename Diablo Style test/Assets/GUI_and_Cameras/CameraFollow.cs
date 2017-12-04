using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	GameObject playerObj;
	Vector3 position;
	// Use this for initialization
	void Start () {
		playerObj = GameObject.Find ("Player");
		position = playerObj.transform.position;
		if(playerObj == null)
			Debug.Log("playerObj not Found!!!");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerObj) {
			transform.position += (playerObj.transform.position - position);
			position = playerObj.transform.position;
		}
	}
}
