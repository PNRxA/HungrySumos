using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This Script was done by: Peter and James
public class GameManager : MonoBehaviour
{

    public int Score = 0;
    public int scoreMultiplyer = 1;
    public int LivesCount = 3;
    public int Lives;
    public int HScore;

    private static GameManager instance;

    public int scoreNumber = 0;

    //dev
    public bool debug = false;

    // Use this for initialization
    void Start() //[Peter]
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Set highscore from player prefs
        HScore = PlayerPrefs.GetInt("highscore", 0);
    }


    // Update is called once per frame
    void Update() // [James]
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && !debug)
        {
            debug = true;
        }
        else if ((Input.GetKeyDown(KeyCode.BackQuote) && debug))
        {
            debug = false;
        }

        if (Lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
