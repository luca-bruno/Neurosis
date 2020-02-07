using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;
    [SerializeField] public Image HeartUI;
    private PlayerMove player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    void Update(){
        HeartUI.sprite = HeartSprites[player.playerHealth];
    }
}