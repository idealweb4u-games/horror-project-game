using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSizeUp : MonoBehaviour
{
    public GameObject Lock;
    public GameObject Play;
    public GameObject Details;
    public Image LevelImage;
    public TMPro.TMP_Text LevelNumber;
    public TMPro.TMP_Text LevelName;
    public float sizeY = 1.2f;

    public void OnSelectButton() {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(1, sizeY);
    }
}
