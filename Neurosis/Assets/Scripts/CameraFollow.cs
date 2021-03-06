﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;        //Public variable to store a reference to the player game object
    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        if(player == null){
            return;
        }
            else{

            
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(transform.position.x, -2.725f, 27.87f);
        transform.position = v3;
            }
        }
    }  
