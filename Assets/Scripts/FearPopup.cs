using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearPopup : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    private bool alreadyPlayed = false;
    [SerializeField] private float destroyTime = 4.1f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !alreadyPlayed)
        {
            alreadyPlayed = true;
            popUp.SetActive(true);
            Destroy(gameObject, destroyTime);       
        }
    }
}
