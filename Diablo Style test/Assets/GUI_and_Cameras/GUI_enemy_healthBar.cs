using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_enemy_healthBar : MonoBehaviour
{
	public GameObject player;
	public Texture2D frame;
	public Rect framePosition;
	public Texture2D healthBar;
	private Rect healthBarPosition;
	//public float displayOffsetX =-38.32f, displayOffsetY =125.2f;
	public float frameWidthRatio = 0.157f, frameHeightRatio = 0.05f;
	public float healthBarWidthRatio = 0.125f, healthBarHeightRatio = 0.022f, modifyX = 0.1f, modifyY = 0.2852f;
	GameObject target;
	ClickToMove clickToMove;
	float max_health, current_health, health_percentage;
	bool toDraw = false;
	int count_down_timer = 3;
	// Use this for initialization
	void Awake ()
	{
		clickToMove = player.GetComponent<ClickToMove> ();
	}

	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		target = clickToMove.lockTo;
		if (target && target.tag == "Enemy") {
			max_health = target.GetComponent<CharacterProperty> ().max_health;
			current_health = target.GetComponent<CharacterProperty> ().current_health;
			health_percentage = current_health / max_health;
			toDraw = true;
			count_down_timer = 3;
		} else {
			target = null;
			if (toDraw && count_down_timer == 3) //離開戰鬥後 延遲三秒才停止draw healthBar
				InvokeRepeating ("CountDown", 0.0f, 1.0f);
		}
	}

	void OnGUI ()
	{	
		if (health_percentage != 0 && toDraw) {
			DrawHealthBarFrame ();
			DrawHealthBar ();
		}
	}

	void CountDown ()
	{ //離開戰鬥後 延遲後才關閉敵方血量
		count_down_timer--;
		if (count_down_timer <= 0) {
			CancelInvoke ("CountDown");
			toDraw = false;
		}
	}



	void DrawHealthBarFrame ()
	{	
		framePosition.x = (Screen.width - framePosition.width) / 2;
		framePosition.height = Screen.height * frameHeightRatio;
		framePosition.width = Screen.width * frameWidthRatio;
		GUI.DrawTexture (framePosition, frame);
	}

	void DrawHealthBar ()
	{
		healthBarPosition.x = framePosition.x + modifyX * framePosition.width;
		healthBarPosition.y = framePosition.y + modifyY * framePosition.height;
		healthBarPosition.height = Screen.height * healthBarHeightRatio;
		healthBarPosition.width = Screen.width * healthBarWidthRatio * health_percentage;
		GUI.DrawTexture (healthBarPosition, healthBar);
	}
}