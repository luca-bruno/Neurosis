using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
	Rigidbody2D rb;
	GameObject target;
	float moveSpeed;
	Vector3 directionToTarget;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");
		rb = GetComponent<Rigidbody2D> ();
		moveSpeed = Random.Range (1f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		MoveEnemy ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		switch (col.gameObject.tag) {

		case "Player":
			EnemySpawn.spawnAllowed = false;
			Instantiate (explosion, col.gameObject.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			target = null;
			break;

		}
	}

	void MoveEnemy ()
	{
		if (target != null) {
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb.velocity = new Vector2 (directionToTarget.x * moveSpeed,
										directionToTarget.y * moveSpeed);
		}
		else
			rb.velocity = Vector3.zero;
	}
}

