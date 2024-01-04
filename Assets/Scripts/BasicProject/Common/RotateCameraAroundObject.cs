using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundObject : MonoBehaviour
{
    public Transform target;
 
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * Time.smoothDeltaTime*3);
    }
    
}
