using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWeather : MonoBehaviour
{
    [SerializeField] private GameObject weatherHolder;

    void OnTriggerEnter(Collider collider) // When entering building
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            weatherHolder.SetActive(false);        
        }
    }

    void OnTriggerExit(Collider collider) // When leaving building
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            weatherHolder.SetActive(true);      
        }
    }
}
