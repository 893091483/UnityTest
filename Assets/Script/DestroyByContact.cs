using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gamecontroller;

    private void Start()
    {
        GameObject gamecontrollerobject = GameObject.FindWithTag("GameController"); 
        if(gamecontrollerobject != null)
        {
            gamecontroller = gamecontrollerobject.GetComponent<GameController>();
        }
        if (gamecontroller == null)
        {
            Debug.Log("Can not find'GameController'script");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag  ("Boundary")|| other.CompareTag  ("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gamecontroller.Gameover();
        }

        gamecontroller.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
