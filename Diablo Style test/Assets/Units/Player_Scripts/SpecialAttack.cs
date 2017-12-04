using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour {
	public float cooldown = 3.0f;
	public int damage;
	bool cdComplete = true;
	public KeyCode specialAttack = KeyCode.Mouse0;
	public float area_radius = 1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(specialAttack) && cdComplete){
			cdComplete = false;
			Invoke ("CD", cooldown);
			AreaDamage ();
			Instantiate (Resources.Load ("SpecialAttackExplosive"), transform.position, Quaternion.identity);

		}
	}
	void AreaDamage(){
		Collider[] hitColliders = Physics.OverlapSphere (transform.position, area_radius);
		for(int i=0;i<hitColliders.Length;i++){
			if (hitColliders [i].tag == "Enemy"){
				if (hitColliders [i].GetComponent<CharacterProperty> () != null) {
					hitColliders [i].GetComponent<CharacterProperty> ().damaged (damage);
					gameObject.GetComponent<ClickToMove> ().lockTo = hitColliders [i].gameObject;
					//Debug.Log (hitColliders [i]);
				}
			}
		}	
	}

	void CD(){
		cdComplete 				= true;
	}
}
