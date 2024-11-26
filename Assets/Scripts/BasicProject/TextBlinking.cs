using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class TextBlinking : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private Color textColor;
    [SerializeField] private float speed;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textColor = textMeshProUGUI.color;
    }

    private void Update()
    {
        Blink();
    }

    private void Blink()
    {
        textColor.a = Mathf.PingPong(Time.time * speed, 1f);
        textMeshProUGUI.color = textColor;
        
    }
}
