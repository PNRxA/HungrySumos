using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This Script was done by: Kyle
public class PauseMenu : MonoBehaviour
{
    public bool showPa;
    public bool showOp;
    public float audioSlider, amSlider, dirSlider;

    public GUISkin HUD;
    public GUISkin menuButtons;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    void OnGUI()
    {
        //Set screen Parameters
        float scrW = Screen.width / 16f;
        float scrH = Screen.height / 9f;

        //Invisible box thats fits to screen
        //GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.skin = menuButtons;
        if (!showOp)
        {

            if (!showPa)
            {
                //if (GUI.Button(new Rect(10f * scrW, 1f * scrH, 1f * scrW, 0.5f * scrH), "Pause"))
                //{
                //    showPa = true;
                //    Time.timeScale = 0;
                //}
            }
            else
            {
                //GUI.TextArea(new Rect(0, 0, Screen.width, Screen.height), "");
                if (GUI.Button(new Rect(6f * scrW, 2.5f * scrH, 4f * scrW, 2f * scrH), "Resume"))
                {
                    //SceneManager.LoadScene(0);
                    Time.timeScale = 1;
                    showPa = false;
                }

                if (GUI.Button(new Rect(6f * scrW, 4.5f * scrH, 4f * scrW, 2f * scrH), "Options"))
                {
                    showOp = true;
                }

                if (GUI.Button(new Rect(6f * scrW, 6.5f * scrH, 4f * scrW, 2f * scrH), "Quit To Menu"))
                {
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1;
                }
            }
        }

        if(showOp == true)
        {
            //Sliders and labels
            GUI.Box(new Rect(5f * scrW, 0.5f * scrH, 2.5f * scrW, 0.5f * scrH), "Volume");
            audioSlider = GUI.HorizontalSlider(new Rect(5f * scrW, 1f * scrH, 2.5f * scrW, 0.5f * scrH), audioSlider, 0f, 1f);

            GUI.Box(new Rect(5f * scrW, 2.5f * scrH, 2.5f * scrW, 0.5f * scrH), "Dir Light");
            dirSlider = GUI.HorizontalSlider(new Rect(5f * scrW, 3f * scrH, 2.5f * scrW, 0.5f * scrH), dirSlider, 0f, 8f);

            GUI.Box(new Rect(5f * scrW, 4.5f * scrH, 2.5f * scrW, 0.5f * scrH), "Am Light");
            amSlider = GUI.HorizontalSlider(new Rect(5f * scrW, 5f * scrH, 2.5f * scrW, 0.5f * scrH), amSlider, 0f, 8f);

            if (GUI.Button(new Rect(3.5f * scrW, 0.5f * scrH, 1f * scrW, 0.5f * scrH), "Mute"))
            {

            }

            if (GUI.Button(new Rect(1f * scrW, 7f * scrH, 3f * scrW, 1.25f * scrH), "Back"))
            {
                showOp = false;
            }
        }
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!showPa)
            {
                Time.timeScale = 0;
                showPa = true;
                
            }
            else if (showPa)
            {
                Time.timeScale = 1;
                showPa = false;
            }
        }
    }
}










