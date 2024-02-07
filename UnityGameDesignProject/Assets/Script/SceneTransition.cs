using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToload;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("next scene");
                SceneManager.LoadScene(sceneToload);
            }
        }
    }


}