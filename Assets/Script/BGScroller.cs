
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour

{
    public float scrollsSpeed;
    public float tileSizeZ;
    private GameController gameController;
    private Vector3 startPosition;
    void Start()
    {
        GameObject gamecontrollerobject = GameObject.FindWithTag("GameController");
        if (gamecontrollerobject != null)
        {
            gameController = gamecontrollerobject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Can not find'GameController'script");
        }
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollsSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        if (gameController.score >= 100)
        {
            scrollsSpeed = -15;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}