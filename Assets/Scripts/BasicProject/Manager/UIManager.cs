using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager> {
    public LevelsData levelData;
    public Session session;
    public GameObject
        levelComplete,
        levelFail,
        pauseDlg,
        startDlg;
    public TMPro.TMP_Text LevelName;
    public TMPro.TMP_Text Description;
    public Image levelImage;
    public void showlevelComplete() {
        SoundManager.Instance.PlayEffect();
        levelComplete.SetActive(true);
    }
    public void showLevelFail() {
        SoundManager.Instance.PlayEffect();
        levelFail.SetActive(true);
    }
    public void pause() {
       // Time.timeScale = 0;
        SoundManager.Instance.PlayEffect();
       pauseDlg.SetActive(true);
    }
    public void resume() {
       // Time.timeScale = 1;
        SoundManager.Instance.PlayEffect();
        pauseDlg.SetActive(false);
    }
    public void start() {
        Time.timeScale = 1;
        SoundManager.Instance.PlayEffect();
        SoundManager.Instance.MusicSource.Stop();
        startDlg.SetActive(false);
    }
    private void ShowLevelData() {
        LevelName.GetComponent<TextMeshPro>().text = levelData.levelClasses[session.level].levelName;
        Description.GetComponent<TextMeshPro>().text = levelData.levelClasses[session.level].levelDescription;
        Description.GetComponent<TextMeshPro>().text = levelData.levelClasses[session.level].levelDescription;
        levelImage = levelData.levelClasses[session.level].levelImage;
    }

}
