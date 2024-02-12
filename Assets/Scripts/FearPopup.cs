using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearPopup : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    private bool alreadyPlayed = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !alreadyPlayed)
        {
            alreadyPlayed = true;
            popUp.SetActive(true);
            Destroy(gameObject, 4.1f);       
        }
    }
}
