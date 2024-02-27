using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBaby : MonoBehaviour
{
    [SerializeField] private GameObject babyDoll;
    [SerializeField] private GameObject note;
    private bool alreadyPlayed = false;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !alreadyPlayed)
        {
            alreadyPlayed = true;
            StartCoroutine(Hide()); 
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(.5f);
        babyDoll.SetActive(false);
        yield return new WaitForSeconds(.1f);
        note.SetActive(true); 
    }
}
