using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdvancedHorrorFPS
{
    public class ClownRoom : MonoBehaviour
    {
        public static ClownRoom instance;
        public FirstPersonController controller;
        public AudioSource audio;
        public bool chasePlayer = false;

        private bool doorOpened;
        private bool alreadyPlayed = false;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("Player") && !alreadyPlayed) // && doorOpened)
            {
                controller.StopPlayer();
                audio.Play();
                alreadyPlayed = true;
                chasePlayer = true;
                
            }
        }
    }
}
