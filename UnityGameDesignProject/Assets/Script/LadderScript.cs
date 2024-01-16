using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderScript : MonoBehaviour
{
    public bool collissionPlayer;
    public GameObject Player;
    Player Playerscript;
    Rigidbody2D rb;


    void Start()
    {
        Playerscript = Player.GetComponent<Player>();
        rb = Player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (collissionPlayer)
        {
            //rb.velocity = new Vector2(rb.velocity.y, 0);
            /*if (!Playerscript.onGround)
            {
                Debug.Log("not jumping");
                rb.velocity = new Vector2(rb.velocity.y, 0);
            }*/

          if (Input.GetKey(KeyCode.W)) 
          { 
            //Debug.Log("ladder up");
            Playerscript.enabled = false;
            rb.velocity = new Vector2(0, 5);
          }
          else
          {
                Playerscript.enabled = true;
          }

        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            collissionPlayer = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            collissionPlayer = false;
        }
    }

}
