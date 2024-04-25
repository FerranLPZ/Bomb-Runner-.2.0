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
    public AudioSource source;
    public AudioSource deathSound;



    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        score.text = "HI " + hiScore + " SCORE " + gameScore;

        AudioSource[] sources = GetComponents<AudioSource>();
        source = sources[0]; // Assign the first AudioSource
        deathSound = sources[1]; // Assign the second AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScore > hiScore)
        {
            Debug.Log("scorePoint called");
            hiScore = gameScore;
            score.text = "HI " + hiScore + " SCORE " + gameScore;
            //Debug.Log("HI: " + hiScore);
        }
        
    }

    public void gameOver()
    {

        deathSound.Play();
        gameOverUI.SetActive(true);
        deathSound.Play();
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
        source.Play();
        Debug.Log("scorePoint called");
        gameScore = gameScore + 1;
        score.text = "HI " + hiScore + " SCORE " + gameScore + "DEATHS ";
        //Debug.Log("SCORE: " + gameScore);
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
