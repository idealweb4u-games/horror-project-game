using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownHide : MonoBehaviour
{
    [SerializeField] private Vector3 endRotation;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private GameObject clown;
    [SerializeField] private bool rotate;
    private bool alreadyPlayed = false;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !alreadyPlayed)
        {
            alreadyPlayed = true;
            StartCoroutine(Hide()); 
        }
    }

    private IEnumerator Hide()
    {
        ClownAudio.instance.PlayLaugh();
        if (rotate)
        {
            clown.transform.localRotation = Quaternion.Euler(endRotation);
        }
        else
        {
            clown.transform.position = endPosition;//Quaternion.Euler(endPosition);
        }
        yield return new WaitForSeconds(.6f);
        clown.SetActive(false);
    }
}
