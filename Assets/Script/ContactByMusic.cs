using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactByMusic : MonoBehaviour
{
    private BoostUpByContact boostUpByContact;
    public AudioSource musicSource;
    private void Start()
    {
        GameObject boostUpByContactobject = GameObject.FindWithTag("BoostUpByContact");
        if (boostUpByContactobject != null)
        {
            boostUpByContact = boostUpByContactobject.GetComponent<BoostUpByContact>();
        }
        if (boostUpByContact == null)
        {
            Debug.Log("Can not find'GameController'script");
        }
        
    }
    void Update()
    {
        if (boostUpByContact.explosion == true)
        {
            musicSource.Play();
        }
    }
}
