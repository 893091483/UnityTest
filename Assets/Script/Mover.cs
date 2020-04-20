using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;


    void Start()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            speed = -20;
        }
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
  

}