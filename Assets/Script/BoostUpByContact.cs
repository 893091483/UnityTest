using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostUpByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gamecontroller;
    private PlayerController playercontroller;
    public AudioSource musicSource;



    private void Start()
    {
        GameObject playertrollerobject = GameObject.FindWithTag("PlayerController");
        if (playertrollerobject != null)
        {
            playercontroller = playertrollerobject.GetComponent<PlayerController>();
        }
        if (playercontroller == null)
        {
            Debug.Log("Can not find'GameController'script");
        }







        GameObject gamecontrollerobject = GameObject.FindWithTag("GameController");
        if (gamecontrollerobject != null)
        {
            gamecontroller = gamecontrollerobject.GetComponent<GameController>();
        }
        if (gamecontroller == null)
        {
            Debug.Log("Can not find'GameController'script");
        }
        musicSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "PlayerController")
        {
            musicSource.Play();
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        gamecontroller.AddScore(scoreValue);
        playercontroller.speed = 20;
        Destroy(gameObject);

    }
}