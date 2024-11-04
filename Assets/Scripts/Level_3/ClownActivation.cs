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
            Invoke("MakeClownHunt", 2.0f);
        }
        if (gameObject.CompareTag("Finish"))
        {
            if (other.gameObject.CompareTag("Clown"))
            {
                Debug.Log("CLowns enter the room");
            }
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
