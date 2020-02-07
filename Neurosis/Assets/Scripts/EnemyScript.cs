using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject enemy;
    Animator anim;
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        //anim = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            return;
        }
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer < agroRange){
            ChasePlayer();
        }
        else{
            StopChasingPlayer();
        }
    }

    void ChasePlayer(){
        if(transform.position.x < player.position.x){ //enemy is left of player, so move right
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(4, 4);
            
        } else {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-4, 4);
        }
       // anim.Play("Enemy1_Walk");
    }
    
    void StopChasingPlayer(){
        rb.velocity = Vector2.zero;
    }
}
