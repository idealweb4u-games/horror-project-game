using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    private bool soundPlayed = false;


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !soundPlayed)
        {
            soundPlayed = true;
            audio.Play();    
        }
    }



}
