using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAudio : MonoBehaviour
{
    public static ClownAudio instance;
    //private AudioSource audio;
    [SerializeField] private AudioSource audio;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    public void PlayLaugh()
    {
        audio.Play();
    }


    
}
