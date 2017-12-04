using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking_avoidance : MonoBehaviour {
	Rigidbody rb;
	public float Aplitude = 3;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Avoid Unit Stacking : if they collide, push other away.
	void OnCollisionEnter(Collision col){
		rb.AddForce (-(col.transform.position - transform.position) * Aplitude, ForceMode.Impulse);
	} 
	//if they no longer collide with each other, set back its rigidbody's velocity back to 0. Unit's speed relies on the Chase() in Mob.cs
	void OnCollisionExit(){
		rb.velocity = new Vector3 (0, 0, 0); 
	}
	//
}
