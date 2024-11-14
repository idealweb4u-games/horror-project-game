using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [Header("Home Page UI Elements")]
    [SerializeField] private Image settings;
    [SerializeField] private Image store;

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
    
}
