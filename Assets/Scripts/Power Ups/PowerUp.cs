using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: James
public class PowerUp : MonoBehaviour
{
    GameManager gamemanager;
    public enum PowerUpState
    {
        AddScore = 0,
        BulletTime = 1,
        AllBallsGivePoints = 2,
        Multiplier = 3,
    }

    public PowerUpState powerUpCurrentState;

    public MeshRenderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<MeshRenderer>();


        switch (powerUpCurrentState)
        {
            case PowerUpState.AddScore:
                ChangeColor(Color.red);
                break;

            case PowerUpState.AllBallsGivePoints:
                ChangeColor(Color.blue);
                break;

            case PowerUpState.BulletTime:
                ChangeColor(Color.green);
                break;

            case PowerUpState.Multiplier:
                ChangeColor(Color.black);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set a switch Statement to determine type on spawn
        // Swtich
        // powerUpCurrentState = PowerUpState.AddScore;
        // powerUpCurrentState = PowerUpState.AllBallsGivePoints;
        // etc...

    }

    //Functions for each powerup type

    //Deal with what each power up does in the collectors
    //Use this to determine What type of power up

    void ChangeColor(Color setcolor)
    {
        // [Peter] Will break game if there isn't a renderer 
        if (rend)
        {
            Material mat = rend.material;
            mat.color = setcolor;
        }
    }
}
