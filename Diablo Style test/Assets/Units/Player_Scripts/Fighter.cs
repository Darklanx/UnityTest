using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
	public GameObject opponent;
	public AnimationClip attack;
	public AnimationClip die;
	private ClickToMove clickToMove;
	public float impactTime;
	bool impacted = false;
	CharacterProperty characterProperty;
	Animation anim;
	// Use this for initialization
	void Awake ()
	{
		characterProperty = GetComponent<CharacterProperty> ();
		clickToMove = gameObject.GetComponent<ClickToMove> ();
	}

	void Start ()
	{
		anim = gameObject.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (characterProperty.isDead) {
			anim.CrossFade (die.name);
			if (anim [die.name].time > anim [die.name].length * 0.95){
				anim.enabled = false;
			}

			}

		if (opponent != null) {
			if (Input.GetMouseButton (1) && opponent.tag == "Enemy" && InRange (characterProperty.attackRange) && clickToMove.lockTo.tag == "Enemy") {
				//Attacking 
				clickToMove.state = "attacking";
				anim.CrossFade (attack.name);
				transform.LookAt (opponent.transform);
				if (anim [attack.name].time <= 0.2f) {
					impacted = false;
				}	
				if ((anim [attack.name].time > anim [attack.name].length * impactTime) && (impacted == false)) {
					//opponent.GetComponent<CharacterProperty> ().damaged (gameObject.GetComponent<CharacterProperty>().attackDmg);
					characterProperty.Attack (opponent);
					impacted = true;
				}
			}
		}

	}

	bool InRange (float range)
	{
		if (Vector3.Distance (transform.transform.position, opponent.transform.position) <= range) {
			return true;
		} else {
			return false;
		}
	}
}
