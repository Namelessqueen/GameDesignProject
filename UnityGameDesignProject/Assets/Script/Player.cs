using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D player;

    public float walkspeed = 2f;
    public float JumpHeight = 10f;

    float inputhorizontal;
    public bool isJumping = false;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        inputhorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Debug.Log("JUMP");;
            player.velocity = new Vector2(player.velocity.x, JumpHeight);
            isJumping = true;
        }
        if (inputhorizontal != 0)
        {
            player.velocity = new Vector2(inputhorizontal * walkspeed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
