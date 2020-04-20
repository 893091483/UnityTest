
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public float hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public int score;
    public Text restartText;
    public Text gameOverText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;




    public bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        musicSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("_Scene");
            }

        }
        
        
    }
    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);
        while (true)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {

                
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;

            }
            


        }
    }
    
        public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

    }
    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100&& score<= 115)
        {
            musicSource.Stop();
            musicSource.clip = musicClipOne;
            musicSource.Play();
            gameOverText.text = "You Win!Game Created By HangZheng";
            gameOver = true;
            restart = true;
            
        }
    }
    public void Gameover()
    {
        musicSource.Stop();
        musicSource.clip = musicClipTwo;
        musicSource.Play();
        gameOverText.text = "Game Over";
        gameOver = true;
       
    }
}