using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Texture2D b1;
    public GUISkin skin;
    public GUIStyle style;

    private float scrW = Screen.width / 16;
    private float scrH = Screen.height / 9;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {

        GUI.skin = skin;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), b1);
        GUI.Label(new Rect(scrW * 5, scrH * 1, scrW * 10, scrH * 3), "GAME OVER");

        if (GUI.Button(new Rect(scrW * 5.5f, scrH * 3, scrW * 5, scrH * 1.5f), "Play Again"))
        {
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(scrW * 5.5f, scrH * 4.5f, scrW * 5, scrH * 1.5f), "Exit To Menu"))
        {
            SceneManager.LoadScene(0);
        }
        if (GUI.Button(new Rect(scrW * 5.5f, scrH * 6, scrW * 5, scrH * 1.5f), "Quit"))
        {
            Application.Quit();
        }
    }
}
