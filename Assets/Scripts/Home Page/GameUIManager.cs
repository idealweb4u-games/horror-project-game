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
    [SerializeField] private SceneLoad sceneLoad;
    [Header("Settings components")]
    [SerializeField] private Slider soundSlider, brightnessSlider, vibrationSlider;
    [SerializeField] private TextMeshProUGUI volumeTextValue, brightnessTextValue, vibrationTextValue;
    [SerializeField] private AudioMixer audioMixer;
    [Header("Brightness")]
    [SerializeField] private Volume brightnessAdjusment;
    private ColorAdjustments colorAdjustments;

    //in case of unexpected behabiour change it to Update
    private void Start()
    {
        ChangeVolumeSliderAppearance();
    }

    public void Play()
    {
        //TODO: implement opening last opened(complete) level
        sceneLoad.LoadScene(3);
    }

    public void OpenLevelselection()
    {
        sceneLoad.LoadScene(2);
    }

    public void OpenSettings()
    {
        settings.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        //TODO: implement save settings
        GameSaveData.Instance.SaveData();
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
    #region settings controller
    public void ChangeSound(float volume)
    {
        GameSaveData.Instance.volume = volume;
        soundSlider.value = GameSaveData.Instance.volume;
        audioMixer.SetFloat("AllMusic", GameSaveData.Instance.volume);
        volumeTextValue.text = ConvertValuesToPercentage(GameSaveData.Instance.volume, soundSlider.maxValue, soundSlider.minValue) + "%";

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

    //formula for converting slider values into percentages
    private int ConvertValuesToPercentage(float currentValue, float maxValue, float minValue)
    {
        float percentageValue = ((currentValue - minValue) / (maxValue - minValue)) * 100f;
        return Mathf.RoundToInt(percentageValue);
    }

    private void ChangeVolumeSliderAppearance()
    {
        soundSlider.value = GameSaveData.Instance.volume;
        audioMixer.SetFloat("AllMusic", GameSaveData.Instance.volume);
    }

    
}

