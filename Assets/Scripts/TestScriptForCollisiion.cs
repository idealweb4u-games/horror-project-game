using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptForCollisiion : MonoBehaviour
{

    private void Update()
    {
        CheckObjectName();
    }
    private void CheckObjectName()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
