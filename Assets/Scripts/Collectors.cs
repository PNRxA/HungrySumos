using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script was done by: Peter
public class Collectors : MonoBehaviour
{

    public GameObject particleDestination;
    public GameObject explosionPrefab;
    public GameObject scoreExplosionPrefab;
    public GameObject collector;
    public GameManager gameManager;
    public GameObject ballToKill;
    public List<GameObject> ballsToKill;
    public int ballToKillForDestroyBonus = 10;
    public float speed;
    public AudioClip plusScore;
    public AudioClip minusScore;
    public AudioClip bonusScore;
    public AudioClip gameOver;

    private GameObject[] instantiation = new GameObject[10];
    private float explodeTime = .1f;
    private float wrongExplodeTime = .1f;
    private AudioSource audi;

    // Use this for initialization
    void Start()
    {
        gameManager.Lives = gameManager.LivesCount; // Set number of lives
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveParticles();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name.Contains(ballToKill.name)) // If wrong ball ball in collector
        {
            StartCoroutine(KillBill(col.gameObject, wrongExplodeTime));
            gameManager.Score--;
            gameManager.scoreMultiplyer = 1;
            PlayEffect(minusScore);
            if (gameManager.Lives <= 0) 
            {
                PlayEffect(gameOver);
                Time.timeScale = 0;
                // Set highscore if it's larger than previously
                if (gameManager.Score > gameManager.HScore)
                {
                    PlayerPrefs.SetInt("highscore", gameManager.Score);
                    gameManager.HScore = gameManager.Score;
                    PlayerPrefs.Save();
                }
            }
            else
            {
                gameManager.Lives -= 1;
            }
        }
        else // If correct ball in collector
        {
            gameManager.Score++;            
            ballsToKill.Add(col.gameObject); // Add ball to list of balls for ball bonus
            PlayEffect(plusScore);
        }

        
        if (ballsToKill.Count >= ballToKillForDestroyBonus) // Destroy balls if ballToKillForDestroyBonus is reached
        {
            for (int i = 0; i < ballsToKill.Count; i++)
            {
                GameObject ball = ballsToKill[i];
                Vector3 ballPos = ball.transform.position;
                ballPos.z = -1;
                StartCoroutine(ScoreExplosion(ballPos, i, explodeTime));
                StartCoroutine(KillBill(ball, explodeTime));
            }
            ballsToKill.Clear(); // Clears list of balls
        }

    }

    // Plays effect at random pitch
    void PlayEffect(AudioClip effect)
    {
        audi.clip = effect;
        audi.pitch = Random.Range(.5f, 1.5f);
        audi.Play();
    }

    IEnumerator KillBill(GameObject bill, float time)
    {
        yield return new WaitForSeconds(time); // Waits time unit
        if (bill != null) // Make sure bill exists
        {
            Vector3 pos = bill.transform.position;
            Explode(pos);
            Destroy(bill); // This will work after 2 seconds.
        }
    }

    void Explode(Vector3 pos)
    {
        GameObject clone = Instantiate(explosionPrefab); // Create a copy of our explosionPrefab        
        clone.transform.position = pos; // Position our copy into the player's position        
        ParticleSystem explosion = clone.GetComponent<ParticleSystem>(); // Play the particle system
        explosion.Play();
        Destroy(clone, 1f); // Commit Sudoku 
    }
    IEnumerator ScoreExplosion(Vector3 pos, int i, float time) // Loop through and instantiate score particles 
    {
        yield return new WaitForSeconds(time);
        instantiation[i] = Instantiate(scoreExplosionPrefab);
        instantiation[i].transform.position = pos;
        KillScoreParticles ksp = instantiation[i].GetComponent<KillScoreParticles>();
        ksp.gameManager = gameManager;
        ParticleSystem explosion = instantiation[i].GetComponent<ParticleSystem>();
        explosion.Play();
    }

    void MoveParticles() // Loop through all spawned score particles and move them towards the destination
    {
        float step = speed * Time.deltaTime;
        for (int i = 0; i < instantiation.Length; i++)
        {

            if (instantiation[i] != null)
            {
                instantiation[i].transform.position = Vector3.MoveTowards(instantiation[i].transform.position, particleDestination.transform.position, step);
            }           
        }
    }

    void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighscore)
        {
            PlayerPrefs.SetInt("highscore", newHighscore);
        }
    }
}
