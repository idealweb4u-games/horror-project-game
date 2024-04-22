using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animation anim;
    private bool isOpened = false;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isOpened)
        {
            isOpened = true;
            anim.Play();
        }
    }
}
