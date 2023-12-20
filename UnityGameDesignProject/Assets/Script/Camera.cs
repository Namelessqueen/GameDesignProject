using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Player;
    Player Playerscript;
    float cameraDisctance = 5f;
    public float cameraLag = 0.2f;


    float distX;
    float distY;

    void Start()
    {
        
        Playerscript = Player.GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        MovementX();
        //MovementY();


    }

    void MovementX()
    {
        distX = Player.transform.position.x - transform.position.x;
        if (distX > cameraDisctance)
        {
            rb.velocity = new Vector2(Playerscript.walkspeed - cameraLag, 0);
        }
        else if (distX < -cameraDisctance)
        {
            rb.velocity = new Vector2(-Playerscript.walkspeed + cameraLag, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    //gonna be needed once I Start on the cloud and ladder system
    /*
    void MovementY()
    {
        distY = Player.transform.position.y - transform.position.y;
        if (distY > cameraDisctance)
        {
            rb.velocity = new Vector2(Playerscript.walkspeed - cameraLag, 0);
        }
        else if (distY < -cameraDisctance)
        {
            rb.velocity = new Vector2(-Playerscript.walkspeed + cameraLag, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    */

}
