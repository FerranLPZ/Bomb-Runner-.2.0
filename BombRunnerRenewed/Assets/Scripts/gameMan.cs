using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMan : MonoBehaviour
{
    public GameObject gameOverUI;


    public static int hiScore = 0;
    public static int gameScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScore > hiScore)
        {
            hiScore = gameScore;
            Debug.Log("HI: " + hiScore);
        }
        
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void scorePoint()
    {
        gameScore = gameScore + 1;
        Debug.Log("SCORE: " + gameScore);
    }
}
