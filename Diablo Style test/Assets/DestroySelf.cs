using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
		//time = gameObject.GetComponent<ParticleSystem> ().main.duration;
		Destroy (gameObject, time);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
