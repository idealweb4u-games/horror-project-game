using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSizeUp : MonoBehaviour
{
    public GameObject Lock;
    public GameObject Play;
    public GameObject Details;
    public float sizeY = 1.1f;

    public void OnSelectButton() {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(1, sizeY);
    }
}
