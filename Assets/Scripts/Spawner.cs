using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: Peter and James
public class Spawner : MonoBehaviour
{
    public float spawnRadius = .09f;
    public GameObject[] balls;
    public int ballSpawnNumber;
    public int ballCount = 0;
    public int intToSpawnPowerUp = 10;

    public GameManager gameManager;

    private float instantiationTimer = 2f;
    private float instantiationTimerUpdate = 2f;
    private float reductionTimer = .1f;
    private float reductionTimerUpdate = .1f;
    private int nextRandomIndex = 0;
    private int nextRandomStateIndex = 0;

    private int ballSpawnArrayNumMin = 0;
    private int ballSpawnArrayNumMax = 2;


    // Use this for initialization
    void Start()
    {
        nextRandomIndex = RandomIntNumber(ballSpawnArrayNumMin, ballSpawnArrayNumMax);
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManager.debug)
        //{
            Spawn();
            ReduceBallDelay();
        //}
    }

    void Spawn() // [James]
    {       
        instantiationTimer -= Time.deltaTime; // Timer
        if (instantiationTimer <= 0) //Check if power is needed && if timer == 0
        {
            SpawnBall(); // Spawn ball Function
            ballCount += 1;
        }
    }

    void SpawnBall() // [James and Peter]
    {
        Vector3 spawnLocation = transform.position + Random.insideUnitSphere * spawnRadius; // Choose spawn location
        spawnLocation.z = transform.position.z; // Set spawn location 

        // Spawns Ball
        GameObject clone = Instantiate(balls[nextRandomIndex], spawnLocation, Quaternion.identity); // Create a ball

        BallRayScript brs = clone.GetComponent<BallRayScript>();
        brs.gameManager = gameManager;

        instantiationTimer = instantiationTimerUpdate; // Reset Timer
        nextRandomIndex = RandomIntNumber(ballSpawnArrayNumMin, ballSpawnArrayNumMax); //Get next ball type
    }

    public int RandomIntNumber(int minLimit, int maxLimit) // [James] Random number Generator(Picks Ball_1 or Ball_2)
    {
        int numGenerated;
        numGenerated = Random.Range(minLimit, maxLimit);
        return numGenerated;
    }

    public Color GetNextBallColor() // [James] Get next ball color 
    {
        GameObject ball = balls[nextRandomIndex];
        MeshRenderer render = ball.GetComponent<MeshRenderer>();
        return render.sharedMaterial.color;
    }

    void ReduceBallDelay() // [Peter]
    {
        reductionTimer -= Time.deltaTime;
        if (reductionTimer <= 0) // Spawn balls after the initial InstantiationTimer then after the set InstantiationTimer
        {
            if (instantiationTimerUpdate > .5)
            {
                instantiationTimerUpdate -= .002f;
            }
            reductionTimer = reductionTimerUpdate;
        }
        if (instantiationTimerUpdate < 0.5f)
        {
            instantiationTimer = 0.5f;
        }
    }
}
