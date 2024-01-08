using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToload;


    public void OnTriggerEnter2D(Collider2D other)
    {

       if (other.gameObject.tag == "Player")
       {
            Debug.Log("next scene");
            SceneManager.LoadScene(sceneToload);
       }
    }


}