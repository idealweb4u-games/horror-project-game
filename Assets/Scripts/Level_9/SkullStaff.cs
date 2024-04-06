using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullStaff : MonoBehaviour
{
    [SerializeField] private GameObject skulls;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            skulls.SetActive(false);
        }
    }
}
