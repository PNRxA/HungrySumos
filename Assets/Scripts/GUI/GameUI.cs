using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This Script was done by: Kyle
public class GameUI : MonoBehaviour
{
    public int Score = 0;
    public int scoreMultiplyer = 1;
    public int LivesCount = 3;
    public int Lives;

    public int scoreNumber = 0;

    public GUISkin HUD;
    public GUIStyle ScoreGUI;

    public GameManager gameManager;

    //dev
    public bool debug = false;

    
    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16f;
        float scrH = Screen.height / 9f;
        GUI.skin = HUD;

        GUI.Box(new Rect(scrW * 0.6f, scrH * 0.5f, scrW * 5, scrH * 2), "Score: " + gameManager.Score, ScoreGUI);

        GUI.Box(new Rect(scrW * 8.5f, scrH * 0.65f, 2.5f * scrW, scrH), "Next Color");

        GUI.Box(new Rect(scrW * 10.6f, scrH * 0.65f, 2.5f * scrW, scrH), "Lives: " + gameManager.Lives);

        GUI.Box(new Rect(scrW * 12.7f, scrH * 0.65f, 2.5f * scrW, scrH), "Power Ups");

        GUI.Box(new Rect(scrW * 5f, scrH * 0.65f, 2.5f * scrW, scrH), gameManager.scoreMultiplyer + "x");
    
        GUI.Box(new Rect(scrW * 5f, scrH * 1.4f, 2.5f * scrW, scrH), "High Score: " + gameManager.HScore);



    }
}
