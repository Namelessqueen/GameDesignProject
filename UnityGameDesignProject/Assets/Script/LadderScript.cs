using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderScript : MonoBehaviour
{
    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    public  bool movable = false;
    public GameObject Player;
    public GameObject topCollider;
    Rigidbody2D rb;
    EdgeCollider2D top;
    int climbingSpeed = 5;
    
    void Start()
    {
       
        top = topCollider.GetComponent<EdgeCollider2D>();
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbingSpeed);
            top.isTrigger = true;

            if (Mathf.Abs(vertical) > 0)
            {
                rb.velocity = new Vector2(0, vertical * climbingSpeed);
                //top.isTrigger = true;
            }
        }
        else if (rb != null)
        {
            rb.gravityScale = 2f;
            top.isTrigger = false;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = Player.GetComponent<Rigidbody2D>();
            isLadder = true;

            if (movable && isClimbing)
            {
                other.gameObject.transform.SetParent(transform);
            }

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isLadder = false;
            isClimbing = false;

            if (movable)
            {
                other.gameObject.transform.SetParent(null);
            }

        }
    }

}
