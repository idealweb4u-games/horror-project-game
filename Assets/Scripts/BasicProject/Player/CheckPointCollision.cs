using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollision : MonoBehaviour
{
    public GameObject EndPoint;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            EndPoint.SetActive(true);
        }
    }
}
