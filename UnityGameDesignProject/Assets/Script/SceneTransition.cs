using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToload;

    public void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneToload);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
               LoadNextScene();
        }
    }
   

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToload);
    }

}