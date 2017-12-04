using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {
	public int test;
	// Animations
	Animation anim;
	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip die;
	public AnimationClip attack;
	//
	public float constant_speed;
	public int exp; 
	float speed;
	public float range;
	public Transform player;
	public float impactTime;
	bool impacted = false;
	CharacterProperty characterProperty, playerProperty;
	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		characterProperty = GetComponent<CharacterProperty> ();
		playerProperty = player.GetComponent<CharacterProperty> ();
		
	}	
	// Use this for initialization
	void Start () {
		speed = constant_speed;
		anim = gameObject.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		speed = constant_speed;
		if (characterProperty.isDead) { //Destroy when Dead 
			anim.CrossFade (die.name);
			if(anim[die.name].time > anim[die.name].length * 0.75){
				Destroy (gameObject);
				playerProperty.exp += exp;
			}
		} else {
			if (InRange ()) {
				if (Vector3.Distance (transform.position, player.position) < characterProperty.attackRange) {
					anim.CrossFade (attack.name);
					transform.LookAt (player.transform);
					if(anim[attack.name].time > anim[attack.name].length * impactTime && impacted == false){
						playerProperty.damaged (characterProperty.attackDmg);
						impacted = true;
					}
					if(anim[attack.name].time < anim[attack.name].length *0.2){
						impacted = false;
					}

				} else {
					chase ();
				}
			}else
				anim.CrossFade (idle.name);
		}
	}
	bool InRange(){
		if (Vector3.Distance (transform.position, player.position) < range)
			return true;
		else
			return false;
	}
	void chase(){
		if (player) {
			transform.LookAt (player.position);
			transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
			//controller.SimpleMove (transform.forward * speed);
			anim.CrossFade (run.name);
		}
	}




}
