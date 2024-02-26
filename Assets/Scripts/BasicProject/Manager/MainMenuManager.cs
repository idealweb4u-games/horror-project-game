using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject SettingsPanel;
    public Slider effects;
    public Slider music;
    public Session session;
    public AudioClip clip;
    private void Start() {
        if (PlayerPrefs.GetInt("Checks") == 0) {
            PlayerPrefs.SetFloat("EffectsVolume", 1);
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.SetInt("Checks", 1);
            //PlayerPrefs.SetInt("Coins", 100000);
        } else {
            GetEffectVolume();
            GetMusicVolume();
        }
        SoundManager.Instance.AssignMusicClip(clip);
        SoundManager.Instance.PlayMusic();
    }
    public void ExitButton() {
        Application.Quit();
    }
    public void AboutUs() {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Fun+and+Learn");
    }
    public void RateUs() {
       Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
    }
    public void Play() {
        SceneLoad.Instance.LoadScene(3);
        SoundManager.Instance.PlayEffect();
    }

    public void LevelSelection() {
        SoundManager.Instance.PlayEffect();
        SceneManager.LoadScene(2);
    }
    public void SettingPanel(bool val) {
        SettingsPanel.SetActive(val);
    }
    #region SetVolume
    public void SetEffectVolume() {
        PlayerPrefs.SetFloat("EffectsVolume", effects.value);
        SoundManager.Instance.EffectsSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectsVolume");
    }
    public void GetEffectVolume() {
       SoundManager.Instance. EffectsSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectsVolume");
    }
    public void SetMusicVolume() {
        PlayerPrefs.SetFloat("MusicVolume", music.value);
        SoundManager.Instance.MusicSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void GetMusicVolume() {
        SoundManager.Instance.MusicSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void GetSoundSettings() {
        effects.value = PlayerPrefs.GetFloat("EffectsVolume");
        music.value= PlayerPrefs.GetFloat("MusicVolume");
        SoundManager.Instance.PlayEffect();
    }
    public void ResetDefault() {
        PlayerPrefs.SetFloat("MusicVolume",1);
        PlayerPrefs.SetFloat("EffectsVolume", 1);
        effects.value = 1;
        music.value = 1;
        SoundManager.Instance.MusicSource.GetComponent<AudioSource>().volume = 1;
        SoundManager.Instance.EffectsSource.GetComponent<AudioSource>().volume = 1;
        SoundManager.Instance.PlayEffect();
    }
    #endregion SetVolume

}
