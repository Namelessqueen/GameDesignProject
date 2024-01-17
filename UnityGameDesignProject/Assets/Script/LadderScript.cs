using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderScript : MonoBehaviour
{
    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    public GameObject Player;
    Rigidbody2D rb;
    int climbingSpeed = 5;
    

    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
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

            if(Mathf.Abs(vertical) > 0)
            {
                rb.velocity = new Vector2(0, vertical * climbingSpeed);
            }
        }
        else 
        {
            rb.gravityScale = 2f;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isLadder = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isLadder = false;
            isClimbing = false;
        }
    }

}
