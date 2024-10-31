using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftDoor"))
        {
            OpenDoor(other.gameObject, 90.0f);
        }
        if (other.gameObject.CompareTag("RightDoor"))
        {
            OpenDoor(other.gameObject, -90.0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("LeftDoor"))
        {
            StayInDoor(other.gameObject, 90.0f);
        }
        if (other.gameObject.CompareTag("RightDoor"))
        {
            StayInDoor(other.gameObject, -90.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("LeftDoor") || other.gameObject.CompareTag("RightDoor"))
        {
            CLoseDoor(other.gameObject);
        }
    }

    private void OpenDoor(GameObject door, float rotationAngle)
    {
        door.transform.rotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
        AudioManager.Instance.Play_Door_SelfOpen();
    }
    private void StayInDoor(GameObject door, float rotationAngle)
    {
        door.transform.rotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
    }
    private void CLoseDoor(GameObject door)
    {
        door.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        AudioManager.Instance.Play_Door_SelfClose();
    }
}
