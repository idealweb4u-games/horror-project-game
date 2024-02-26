using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour {
    [SerializeField]
    private Button[] TopButtons;
    [SerializeField]
    private Image[] MiddleButtons;
    public Sprite selectedButtonImage;
    public Sprite unselectedButtonImage;
    public Color32 selectedColor;
    public Color unselectedColor = Color.white;
    public void SelectedButton(int index) {
        #region TopButtons
        foreach (var button in TopButtons) {
            button.GetComponent<Image>().sprite = unselectedButtonImage;
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = unselectedColor;
            ChangeButtonAlphaColor(button, 0.2f);
        }
        TopButtons[index].GetComponent<Image>().sprite = selectedButtonImage;
        TopButtons[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = selectedColor;
        #endregion TopButtons
        #region MiddleButtons
        foreach (var button in MiddleButtons) {
            ChangeImageColorAlpha(button.transform.GetChild(0).GetComponent<Image>(), 0.5f);
            button.rectTransform.sizeDelta = new Vector2(305f, 210f);
            button.GetComponent<Button>().interactable=false;
            ChangeImageColorAlpha(button,0.5f);
        }
        ChangeImageColorAlpha(MiddleButtons[index].transform.GetChild(0).GetComponent<Image>(), 1f);
        MiddleButtons[index].rectTransform.sizeDelta = new Vector2(335f, 250f);
        MiddleButtons[index].GetComponent<Button>().interactable = true;
        ChangeImageColorAlpha(MiddleButtons[index], 1);
        #endregion
        SoundManager.Instance.PlayEffect();
    }
    private void ChangeImageColorAlpha(Image image, float transparencyValue) {
        Color imageColor = image.color;
        imageColor.a = transparencyValue;
        image.color = imageColor;
    }
    private void ChangeButtonAlphaColor(Button button, float alphaValue) {
        ColorBlock colors = button.colors;
        Color normalColor = colors.normalColor;
        normalColor.a = 0.2f;
        colors.normalColor = normalColor;
        // Apply the modified colors back to the Button
        button.colors = colors;
    }
}
