using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies; //ignores objects on layers other than Enemy
    public float attackRange;
    public int damage;
    
    void Start(){
   
    }
    void Update()
    {
     if(timeBetweenAttack <= 0){
         if(Input.GetKeyDown("q")){
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++){
                enemiesToDamage[i].GetComponent<EnemyMove>().TakeDamage(damage);
            }
         }

         timeBetweenAttack = startTimeBetweenAttack;
     }   else {
         timeBetweenAttack -= Time.deltaTime;
     }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
}
