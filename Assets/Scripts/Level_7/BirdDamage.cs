using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDamage : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
