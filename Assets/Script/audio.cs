using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    private GameController gameController;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        GameObject gamecontrollerobject = GameObject.FindWithTag("GameController");
        if (gamecontrollerobject != null)
        {
            gameController = gamecontrollerobject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Can not find'GameController'script");
        }
    }


    // Update is called once per frame
    
}
