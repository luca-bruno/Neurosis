using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int playerHealth;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;   

    void Update(){
        
        if(playerHealth > numOfHearts){
            playerHealth = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++){
            
            if(i < playerHealth){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
