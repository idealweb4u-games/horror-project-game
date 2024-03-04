using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdvancedHorrorFPS
{
    public class FloorDetection : MonoBehaviour
    {
        public static FloorDetection instance;
        public bool canChase = false;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                canChase = true;
            }
        }
        void OnTriggerStay(Collider other)
        {
            
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                canChase = false;
            }
        }
    }
}
