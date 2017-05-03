using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: James
public class PowerUpSpawner : MonoBehaviour
{
    public Spawner spawner;
    public GameManager gameManager;

    public GameObject[] powerUp;
    public GameObject currentPowerUp;

    private int nextPowerUpScore = 10;
    private int scoreInterval = 10;

    private int powerUpSpawnMin = 0;
    private int powerUpSpawnMax = 3;
    private int nextRandomIndex;

    private float timer = 2f;
    private float resetTimer = 2f;

    private bool powerUpReady = false;
    private bool slowTime = false;

    private Quaternion startRotation;

    // Use this for initialization
    void Start()
    {
        startRotation[1] = 180;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPowerUp();
        if (slowTime == true)
        {
            SlowTime();
        }

    }

    void SpawnPowerUp()
    {
        // If the ball needs to have a powerup on it
        if (gameManager.Score >= nextPowerUpScore && !powerUpReady)
        {
            nextRandomIndex = spawner.RandomIntNumber(powerUpSpawnMin, powerUpSpawnMax);
            GameObject clone = Instantiate(powerUp[nextRandomIndex], transform.position, startRotation);
            currentPowerUp = clone;
            nextPowerUpScore += scoreInterval;
            powerUpReady = true;
        }
        else if (gameManager.Score >= nextPowerUpScore && powerUpReady)
        {
            nextPowerUpScore += scoreInterval;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (currentPowerUp.gameObject.name == "Coin(Clone)")
            {
                Debug.Log(currentPowerUp.gameObject.name);
                gameManager.Score += 25;
                Destroy(currentPowerUp.gameObject);
                powerUpReady = false;
            }

            else if (currentPowerUp.gameObject.name == "Hour Glass(Clone)")
            {
                Debug.Log(currentPowerUp.gameObject.name);
                slowTime = true;
            }

            else if (currentPowerUp.gameObject.name == "X1(Clone)")
            {
                Debug.Log(currentPowerUp.gameObject.name);
                gameManager.scoreMultiplyer += 1;
                Destroy(currentPowerUp.gameObject);
                powerUpReady = false;
            }

            else if (currentPowerUp.gameObject.name == "x2(Clone)")
            {
                Debug.Log(currentPowerUp.gameObject.name);
                gameManager.scoreMultiplyer += 2;
                Destroy(currentPowerUp.gameObject);
                powerUpReady = false;
            }

            else if (currentPowerUp.gameObject.name == "x4(Clone)")
            {
                Debug.Log(currentPowerUp.gameObject.name);
                gameManager.scoreMultiplyer += 4;
                Destroy(currentPowerUp.gameObject);
                powerUpReady = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Destroy(currentPowerUp.gameObject);
            powerUpReady = false;
        }
    }

    void SlowTime()
    {
        Time.timeScale = 0.5f;
        if (timer <= 0)
        {
            Time.timeScale = 1;
            Debug.Log("done");
            slowTime = false;
            timer = resetTimer;
            powerUpReady = false;
            Destroy(currentPowerUp.gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
    }
}
