using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;
    [SerializeField] public Image HeartUI;
    private EnemyMove player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyMove>();
    }

    void Update(){
        HeartUI.sprite = HeartSprites[player.playerHealth];
    }
}