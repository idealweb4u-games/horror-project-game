using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftDoor"))
        {
            Debug.Log("We near left door");
            other.gameObject.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }
    }
}
