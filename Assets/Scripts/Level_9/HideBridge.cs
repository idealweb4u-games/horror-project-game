using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBridge : MonoBehaviour
{
    [SerializeField] private GameObject invisibleWall;
    private bool isHidden = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isHidden)
        {
            invisibleWall.SetActive(true);
            gameObject.SetActive(false);
            isHidden = true;
        }
    }
}
