using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForBugs : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}
