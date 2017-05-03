using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: Peter
public class KillScoreParticles : MonoBehaviour
{

    public GameObject goal;
    public GameManager gameManager;
    private ParticleSystem system;

    // Use this for initialization
    void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == goal.transform.position) // If particles reach the goal, stop then destroy
        {
            system.Stop();
            StartCoroutine(killMePlz(1));
        }
    }

    IEnumerator killMePlz(int time) // Kill particles and also increases score based on the multiplier
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
        gameManager.Score += 1 * gameManager.scoreMultiplyer;
        gameManager.scoreNumber++;
        if (gameManager.scoreNumber >= 10) // Wait until all bonus balls have been collected then increase multiplier
        {
            gameManager.scoreMultiplyer++;
            gameManager.scoreNumber = 0;
        }
    }

}
