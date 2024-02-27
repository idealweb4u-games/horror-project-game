using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float time = 4f;
    void Start()
    {
        Destroy(gameObject, time);
    }
}
