﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
	Rigidbody2D rb;
	Animator anim;
	GameObject target;
	float moveSpeed;
	Vector3 directionToTarget;
	bool facingRight = true;
	public int health;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		target = GameObject.Find ("Player");
		moveSpeed = Random.Range (1f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		MoveEnemy ();

		if(health <= 0){
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player") == true){
		//	anim.Play("Player_Death"); //doesnt play
			Destroy(col.gameObject);
			EnemySpawn.spawnAllowed = false;
			target = null;
//			gameOver();
		}
	}

	void MoveEnemy ()
	{
		if (target == null) {
			//enemy idle anim
			rb.velocity = Vector3.zero;
			return;
	
		}
		else
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);

		if(gameObject.transform.position.x > target.transform.position.x && facingRight){
			Vector3 newScale = gameObject.transform.localScale;
			newScale.x *= -1;
			gameObject.transform.localScale = newScale;
			facingRight = !facingRight;
			
		}else if(gameObject.transform.position.x < target.transform.position.x && !facingRight){
			Vector3 newScale = gameObject.transform.localScale;
			newScale.x *= -1;
			gameObject.transform.localScale = newScale;
			facingRight = !facingRight;
		}
	}
			
		public void TakeDamage(int damage){
			//HURT SOUND
		health -= damage;
		 Debug.Log("his health" + health);
		// anim.Play("Enemy1_Damage"); //anim not playing
	}
}