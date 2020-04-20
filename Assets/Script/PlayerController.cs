using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    
    public float fireRate;
    public AudioSource musicSource;
    private float nextFire;
    public AudioClip musicSource1;
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            musicSource.clip = musicSource1;
            musicSource.Play();
            
        }
    }
    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.velocity = movement*speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

        

    }

}
