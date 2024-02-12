using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    public static ShakeObject instance;
    public float rotationAngle = 5f; 
    public float rotationSpeed = 1f; 

    private float currentRotation;
    private float rotationDirection = 1f; // 1 for right, -1 for left
    private Quaternion initialRotation;

    private bool shakeBed = false; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (shakeBed)
        {
            currentRotation += rotationDirection * rotationSpeed * Time.deltaTime;
            if (Mathf.Abs(currentRotation) >= rotationAngle)
            {
                rotationDirection *= -1f;
            }
            transform.rotation = initialRotation * Quaternion.Euler(0f, currentRotation, 0f);
        }
    }

    public void StartShaking()
    {
        shakeBed = true;
    }
}
