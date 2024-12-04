using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 initialPos;
    private const float SPEED = 50.0f; //hard coded and tested values. Limit for reseting image position
    [SerializeField] private float topLimit;
    public static CreditsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        rectTransform = GetComponent<RectTransform>();
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
        if(rectTransform.anchoredPosition.y > topLimit)
        {
            rectTransform.anchoredPosition = initialPos;
        }
        else {
            rectTransform.anchoredPosition += Vector2.up * Time.deltaTime * SPEED;
        }
        
    }
}
