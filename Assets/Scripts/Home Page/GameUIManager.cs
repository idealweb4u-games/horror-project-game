using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [Header("Home Page UI Elements")]
    [SerializeField] private Image settings;
    [SerializeField] private Image store;
    [Header("Settings components")]
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Slider vibrationSlider;
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
    }
    public void ChangeBrightness(float brightValue)
    {
        brightnessSlider.value = brightValue;
        if (brightnessAdjusment.profile.TryGet(out colorAdjustments))
        {
            colorAdjustments.postExposure.value = brightValue;
        }
    }
    public void ChangeVibrationStrength(float vibrationValue)
    {
        vibrationSlider.value = vibrationValue;
    }
    #endregion

}

