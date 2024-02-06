using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody2D rbPlayer;
    public GameObject Player;
    Player Playerscript;
    float cameraDisctance = 4.5f;
    public float cameraDisctanceY = 3f;
    public float cameraLag = 0.2f;

    private float velocityX;
    private float velocityY;
    float distX;
    float distY;

    void Start()
    {
        
        Playerscript = Player.GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        rbPlayer = Player.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Debug.Log(distX);
        MovementX(); 
        MovementY();
        rb.velocity = new Vector2(velocityX, velocityY);
    }

    float MovementX()
    {
        distX = Player.transform.position.x - transform.position.x;


        if (distX > cameraDisctance)
        {
            velocityX = Playerscript.walkspeed - cameraLag;
        }
        else if (distX < -cameraDisctance)
        {
            velocityX = -Playerscript.walkspeed + cameraLag;
        }
        else
        {
            velocityX = 0f;
 
        }

        return velocityX;
    }

    //gonna be needed once I Start on the cloud and ladder system

    float MovementY()
    {
        distY = Player.transform.position.y - transform.position.y;
        if (distY > cameraDisctanceY)
        {
            velocityY = rbPlayer.velocity.y;
        }
        else if (distY < -cameraDisctanceY)
        {
            velocityY = rbPlayer.velocity.y;
        }
        else
        {
            velocityY = 0f;
        }
        return velocityY;
    }
    

}
