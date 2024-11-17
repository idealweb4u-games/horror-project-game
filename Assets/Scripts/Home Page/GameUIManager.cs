using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [Header("Home Page UI Elements")]
    [SerializeField] private Image settings, store;
    [Header("Settings components")]
    [SerializeField] private Slider soundSlider, brightnessSlider, vibrationSlider;
    [SerializeField] private TextMeshProUGUI volumeTextValue, brightnessTextValue, vibrationTextValue;
    [SerializeField] private AudioMixer audioMixer;
    [Header("Brightness")]
    [SerializeField] private Volume brightnessAdjusment;
    private ColorAdjustments colorAdjustments;

    public void Play()
    {
        //TODO: implement opening last opened(complete) level
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        //TODO: implement loading saved settings
        settings.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        //TODO: implement save settings
        settings.gameObject.SetActive(false);
    }

    public void OpenStore()
    {
        //TODO: implement loading money amount, all purchased items
        store.gameObject.SetActive(true);
    }

    public void CloseStore()
    {
        //TODO: implement loading money amount, all purchased items
        store.gameObject.SetActive(false);
    }
    public void OpenLevelSelection()
    {
        //TODO: open level selection scene
        SceneManager.LoadScene(2);
    }
    #region settings controller
    public void ChangeSound(float volume)
    {
        soundSlider.value = volume;
        audioMixer.SetFloat("AllMusic", volume);
        volumeTextValue.text = ConvertValuesToPercentage(volume, soundSlider.maxValue, soundSlider.minValue) + "%";

    }
    public void ChangeBrightness(float brightValue)
    {
        brightnessSlider.value = brightValue;
        if (brightnessAdjusment.profile.TryGet(out colorAdjustments))
        {
            colorAdjustments.postExposure.value = brightValue;
        }
        brightnessTextValue.text = ConvertValuesToPercentage(brightValue, brightnessSlider.maxValue, brightnessSlider.minValue) + "%";
    }
    public void ChangeVibrationStrength(float vibrationValue)
    {
        vibrationSlider.value = vibrationValue;
        vibrationTextValue.text = ConvertValuesToPercentage(vibrationValue, vibrationSlider.maxValue, vibrationSlider.minValue) + "%";
    }
    #endregion

    private int ConvertValuesToPercentage(float currentValue, float maxValue, float minValue)
    {
        float percentageValue = ((currentValue - minValue) / (maxValue - minValue)) * 100f;
        return Mathf.RoundToInt(percentageValue);
    }
}

