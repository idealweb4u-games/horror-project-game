using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 initialPos;
    private const float SPEED = 50.0f, TOPLIMIT = 485.0f; //hard coded and tested values. Limit for reseting image position
    public static CreditsManager Instance { get; private set; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Instance = this;
    }
    private void Start()
    {
        initialPos = rectTransform.anchoredPosition;
    }
    private void Update()
    {
        RunCredits();
    }
    public void RunCredits()
    {
        if(rectTransform.anchoredPosition.y > TOPLIMIT)
        {
            rectTransform.anchoredPosition = initialPos;
        }
        else {
            rectTransform.anchoredPosition += Vector2.up * Time.deltaTime * SPEED;
        }
        
    }
}
