using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty : MonoBehaviour {
	[System.NonSerialized]
	public int level, exp, required_exp;
	[System.NonSerialized]
	public bool isDead=false;

	public float current_health, max_health,current_mana, max_mana;
	public float attackDmg, attackRange;
	public float psycialArmour;

	/// <summary>
	/// Damaged the specified damage.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void damaged(float damage){
		current_health -= damage;
		if(current_health <= 0){
			current_health = 0;
			isDead = true;
		}
	}

	/// <summary>
	/// Attack the specified target.
	/// </summary>
	/// <param name="target">Target.</param>
	public void Attack(GameObject target){
		if(target.GetComponent<CharacterProperty>()){
			target.GetComponent<CharacterProperty> ().damaged (this.attackDmg);
		}
		else{
			Debug.Log ("Target Not Found!");
		}
	}

	void LevelUp(){
		if(exp >= required_exp){
			exp -= required_exp;
			level++;
		}
	}


	// Use this for initialization
	void Start () {
		current_health = max_health;
		level = 1;
	}
	
	// Update is called once per frame
	void Update () {
		LevelUp ();	
		required_exp = level * 10 + 20; // Next Lv Exp equation
		
	}
}
