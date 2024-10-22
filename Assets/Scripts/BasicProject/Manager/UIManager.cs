using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AdvancedHorrorFPS;

public class UIManager : Singleton<UIManager> {
    public LevelsData levelData;
    public GameObject PlayerHands;
    public AudioManager audioManager;
    public ParticleSystem rain;
    public ParticleSystem fire;
    public AudioSource audioSource;
    public Session session;
    public GameObject
        levelComplete,
        levelFail,
        pauseDlg,
        startDlg,
        playerCanvas,
        pauseButton,
        skipButton
        ;
    public TMPro.TMP_Text LevelName;
    public TMPro.TMP_Text Description;
    public Image levelImage;
    private void Start() {
        ShowLevelData();
        Time.timeScale = 0f;
    }
    public void showlevelComplete() {
        Time.timeScale = 0;
        SoundManager.Instance.PlayEffect();
        levelComplete.SetActive(true);
    }
    public void showLevelFail() {
        SoundManager.Instance.PlayEffect();
        levelFail.SetActive(true);
    }
    public void pause() {
        Time.timeScale = 0;
        SoundManager.Instance.PlayEffect();
       pauseDlg.SetActive(true);
    }
    public void resume() {
        Time.timeScale = 1;
        SoundManager.Instance.PlayEffect();
        pauseDlg.SetActive(false);
    }
    public void startButton() {
        Time.timeScale = 1f;
        SoundManager.Instance.PlayEffect();
        SoundManager.Instance.MusicSource.Stop();
        LevelManager.Instance.currentlevel.GetComponent<Level_Items>().Enemy.SetActive(false);
        LevelManager.Instance.currentlevel.GetComponent<Level_Items>().CameraCutScene.SetActive(true);
        GameplayManager.Instance.Camera.SetActive(false);
        startDlg.SetActive(false);
        playerCanvas.SetActive(false);
        pauseButton.SetActive(false);
        skipButton.SetActive(true);
        StartCoroutine(CutScene());
    }
    private void ShowLevelData() {
        LevelName.text = levelData.levelClasses[session.level].levelName;
        Description.text = levelData.levelClasses[session.level].levelDescription;
        levelImage.sprite = levelData.levelClasses[session.level].levelImage;
        startDlg.SetActive(true); GameplayManager.Instance.Player.SetActive(false);
    }
    IEnumerator CutScene() {
        float time = LevelManager.Instance.currentlevel.GetComponent<Level_Items>().timeCutScene;
        yield return new WaitForSeconds(time);
        SKipCutScene();
    }
    public void SKipCutScene() {
        GameplayManager.Instance.Player.SetActive(true);
        GameplayManager.Instance.Camera.SetActive(true);
        LevelManager.Instance.currentlevel.GetComponent<Level_Items>().CameraCutScene.SetActive(false);
        if(LevelManager.Instance.currentlevel.GetComponent<Level_Items>().intermediateCutScene != null) //used fore level2
        {
            LevelManager.Instance.currentlevel.GetComponent<Level_Items>().intermediateCutScene.SetActive(false);
            LevelManager.Instance.currentlevel.GetComponent<Level_Items>().intermediateCutSceneObjects.SetActive(false);
            if (FindObjectOfType<CutScenePriestManager>().wasPlayed)
            {
                GameplayManager.Instance.Player.transform.position = FindObjectOfType<CutScenePriestManager>().intermediateCutScenePosition.transform.position;
            } 
        }
        LevelManager.Instance.currentlevel.GetComponent<Level_Items>().Enemy.SetActive(true);
        playerCanvas.SetActive(true);
        pauseButton.SetActive(true);
        skipButton.SetActive(false);
    }
    public void EndingCameraCutScene() {
        StartCoroutine(LevelEnding());
        
    }
    IEnumerator LevelEnding() {
        GameplayManager.Instance.Camera.GetComponent<TouchpadFPSLook>().enabled = false;
        PlayerHands.SetActive(false);
        GameplayManager.Instance.Camera.transform.rotation= LevelManager.Instance.currentlevel.GetComponent<Level_Items>().cameraEndPos.rotation;
        GameplayManager.Instance.Camera.transform.position = LevelManager.Instance.currentlevel.GetComponent<Level_Items>().cameraEndPos.position;
        UIManager.Instance.audioSource.clip = UIManager.Instance.audioManager.Audio_DemonKilling[2];
        UIManager.Instance.audioSource.Play();
        
        if (LevelManager.Instance.currentlevel.GetComponent<Level_Items>().fire) {
        UIManager.Instance.fire.Play();
        UIManager.Instance.fire.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(7);
        showlevelComplete();
    }
}
