using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameMan : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text score;


    public static int hiScore = 0;
    public static int gameScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        score.text = "HI " + hiScore + " SCORE " + gameScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScore > hiScore)
        {
            hiScore = gameScore;
            score.text = "HI " + hiScore + " SCORE " + gameScore;
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

    public void playbutton()
    {
        SceneManager.LoadScene("Main2.0");
    }

    public void scorePoint()
    {
        gameScore = gameScore + 1;
        score.text = "HI " + hiScore + " SCORE " + gameScore;
        Debug.Log("SCORE: " + gameScore);
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
