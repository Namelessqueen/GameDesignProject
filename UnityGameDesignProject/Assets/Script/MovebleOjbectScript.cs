using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovebleOjbectScript : MonoBehaviour
{
    float PosX;
    float MovementX;
    float Pingpong;
    public bool reverse = false;
    public float speed = 1f;
    public float dist = 5f;

    void Start()
    {
        PosX = transform.position.x;
    }

    void Update()
    {
        if (reverse)
        {MovementX = PosX - Pingpong;}
        else
        {MovementX = PosX + Pingpong; }

        Pingpong = Mathf.PingPong(Time.time * speed, dist);
        transform.position = new Vector2(MovementX, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    { 
        if (other.gameObject.tag == "Player" )
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            other.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
    */
}
