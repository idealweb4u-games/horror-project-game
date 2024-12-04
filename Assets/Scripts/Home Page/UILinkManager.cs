using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILinkManager : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Awake()
    {
        // Get the TextMeshProUGUI component
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

   public void OpenLink()
    {
        Application.OpenURL("https://delobogames.com/");
    }
}
