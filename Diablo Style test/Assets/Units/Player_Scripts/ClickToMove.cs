using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
	Vector3 position;
	public float speed;
	public CharacterController controller;
	public AnimationClip idle;
	public AnimationClip run;
	public string state = "idle";
	public GameObject lockTo;
	Animation anim;
	// Use this for initialization

	void Start ()
	{
		anim = gameObject.GetComponent<Animation>();
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//Debug.Log (lockTo);
  		if (Input.GetMouseButton (1)) {
			//Locate where the Player Click on the Terrain
			locatePosition ();
		}
		if (Input.GetMouseButtonUp (1)) {
			lockTo = null;
			if (state == "attacking") {
				position = transform.position; //to avoid moving instantly after the attack
			}
			state = "idle";
		}
		//move the player to the position
		if(state != "attacking")
			moveToPosition ();
	}

	void locatePosition ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)  ) {
			if (state == "idle") {
				if (hit.collider.gameObject.tag != "Enemy") {
					if(lockTo == null)
						lockTo = hit.collider.gameObject;
					gameObject.GetComponent<Fighter> ().opponent = null;
					state = "moving";
				} 
				else{
					lockTo = hit.collider.gameObject;
				}
			}
			if(lockTo && lockTo.tag == "Mouse_Collider"){
				lockTo = lockTo.transform.parent.gameObject;
				GetComponent<Fighter> ().opponent = lockTo;
			}
			if (lockTo && lockTo.tag== "Enemy") {
				GetComponent<Fighter> ().opponent = lockTo;
			}
			if (hit.collider.gameObject.tag == "Enemy" && lockTo == null) {
				lockTo = hit.collider.gameObject;
				GetComponent<Fighter> ().opponent = hit.collider.gameObject;
			}
			if (lockTo && lockTo.tag == "Enemy") {
				position = lockTo.transform.position;
			} else {
				position = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
			}//Debug.Log (transform.position - position);
		}
	}

	void moveToPosition ()
	{
		
		if (Vector3.Distance (position, transform.position) > 0) {
			anim.CrossFade (run.name);
			Quaternion newRotation = Quaternion.LookRotation (position - transform.position, Vector3.forward);
			newRotation.x = 0f;
			newRotation.z = 0f;
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 100);
			transform.position = Vector3.MoveTowards (transform.position, position, speed * Time.deltaTime);
		}
		else{
			anim.CrossFade (idle.name);
		}

	}



}

