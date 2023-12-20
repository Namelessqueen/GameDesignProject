using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;

    public float walkspeed = 2f;
    public float JumpHeight = 10f;

    float inputhorizontal;
    Vector2 playerMovement;
    public bool isJumping = false;


    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Debug.Log(playerMovement);
        // playerMovement = new Vector2(playerMovement.x, playerMovement.y);
        // player.velocity = playerMovement;
        inputhorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            
            player.velocity = playerMovement;
            Debug.Log("JUMP");
            playerMovement = Vector2.up * JumpHeight;
            isJumping = true;
        }
        else
        {
            //playerMovement.y = 0f;
        }
        /*
        if (inputhorizontal != 0)
        {
            playerMovement.x = inputhorizontal * walkspeed;
        }
        else
        {
            playerMovement.x = 0;
        }*/
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Collider groud");
            isJumping = false;
        }
    }
}
