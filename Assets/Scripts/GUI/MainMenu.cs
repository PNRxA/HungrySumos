using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This Script was done by: Kyle
public class MainMenu : MonoBehaviour
{
    //showOp to open options
    public bool showOp, mute;
    public float audioSlider, amSlider, dirSlider;
    public AudioSource audi;
    public Light dirLight;

    public GUISkin HUD;
    public GUISkin menuButtons;
    public Texture2D bg, bg2;
    
    void Start()
    {
        //Changing volume of Audio source
        audi = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        audioSlider = audi.volume;

        //Change Ambient light intensity
        amSlider = RenderSettings.ambientIntensity;
    }

    void Update()
    {
        if(audi.volume != audioSlider)
        {
            audi.volume = audioSlider;
        }

        if(RenderSettings.ambientIntensity !=amSlider)
        {
            RenderSettings.ambientIntensity = amSlider;
        }
    }

    void OnGUI()
    {
        //Set screen Parameters
        float scrW = Screen.width / 16f;
        float scrH = Screen.height / 9f;

        //Invisible box thats fits to screen
        GUI.skin = menuButtons;
        if (!showOp)
        {
            GUI.DrawTexture(new Rect(0, 0, scrW * 16, scrH * 9), bg2);
            GUI.DrawTexture(new Rect(scrW* 2f, 0, scrW * 12, scrH * 9.05f), bg);

            //Buttons/boxs...load scene with using UnityEngine.SceneManagement;
            //GUI.Box(new Rect(4f * scrW, 0.25f * scrH, 8f * scrW, 1.25f * scrH), "Hungry Hungry Sumos");

            if (GUI.Button(new Rect(8.75f * scrW, 6.35f * scrH, 2f * scrW, 1f * scrH), "Play"))
            {
                SceneManager.LoadScene(1);
            }

            if (GUI.Button(new Rect(8.75f * scrW, 7.12f * scrH, 2f * scrW, 1f * scrH), "Options"))
            {
                showOp = true;
            }

            if (GUI.Button(new Rect(8.75f * scrW, 7.9f * scrH, 2f * scrW, 1f * scrH), "Quit"))
            {
                Application.Quit();
            }

        }
        else
        {
            //Sliders and labels
            GUI.Box(new Rect(5f * scrW, 0.5f * scrH, 2.5f * scrW, 0.5f * scrH), "Volume");
            audioSlider = GUI.HorizontalSlider(new Rect(5f * scrW, 1f * scrH, 2.5f * scrW, 0.5f * scrH),audioSlider,0f,1f);

            GUI.Box(new Rect(5f * scrW, 4.5f * scrH, 2.5f * scrW, 0.5f * scrH), "Am Light");
            amSlider = GUI.HorizontalSlider(new Rect(5f * scrW, 5f * scrH, 2.5f * scrW, 0.5f * scrH), amSlider, 0f,8f);

            if (GUI.Button(new Rect(12f * scrW, 7f * scrH, 3f * scrW, 1.25f * scrH), "Menu"))
            {
                SceneManager.LoadScene(0);
            }

            if (GUI.Button(new Rect(3.5f * scrW, 0.5f * scrH, 1f * scrW, 0.5f * scrH), "Mute"))
            {
                
            }
        }

    }
}
