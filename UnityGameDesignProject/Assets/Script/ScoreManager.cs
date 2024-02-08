using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int ApplePoints;
    public TextMeshProUGUI Score;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        
    }

    void Update()
    {
        Score.text = ": " + ApplePoints.ToString();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            Debug.Log("SCENE GAMEOVER");
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void AddPoint()
    {
        ApplePoints++;
        Score.text = ": " + ApplePoints.ToString();
    }
}
