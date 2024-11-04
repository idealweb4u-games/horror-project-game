using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownActivation : MonoBehaviour
{
    [SerializeField] GameObject[] clownsSight;
    private void Start()
    {
        foreach (GameObject clown in clownsSight)
        {
            clown.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Player enters the room");
            Invoke("MakeClownHunt", 2.0f);
        }
    }

    private void MakeClownHunt()
    {
        foreach (GameObject clown in clownsSight)
        {
            clown.SetActive(true);
        }
    }
    
}
