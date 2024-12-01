using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {
    public Session session;
    public LevelsData levelsData;
    private List<Transform> levels = new List<Transform>();
    private int
        totalLevels,
        currentLevel,
        levelnumbertext=1,
        unlocklevels
        ;
    [SerializeField] private Button currentLevelBtnPrefab;
    [SerializeField] private TextMeshProUGUI textToDisplay;

    private void Start() {
        SoundManager.Instance.PlayBackgroundMusic();
        GameSaveData.Instance.LoadData();
        //PlayerPrefs.SetInt("unlocklevels",8);
        foreach (Transform child in transform) {
            levels.Add(child);
      }
        int count;
        for (int i = 0; i < levels.Count; i++) {
            //add count and image here.
            count = i;
            levels[i].transform.GetComponent<LevelButtonSizeUp>().LevelImage.sprite = levelsData.levelClasses[i].levelImage; 
            levels[i].transform.GetComponent<LevelButtonSizeUp>().LevelNumber.text = ""+ ++count;
            levels[i].transform.GetComponent<LevelButtonSizeUp>().LevelName.text = levelsData.levelClasses[i].levelName;
            //GameSaveData.Instance.levelsLocked[i] = levelsData.levelClasses[i].isLocked;
        }
       
    }
    public void levelNumber(int index) {
        if (!levels[index].transform.GetComponent<LevelButtonSizeUp>().Lock.activeInHierarchy) {
            currentLevel = index;
            session.level = index;
        }
    }
    public void OnSelectButton(int index) {
        foreach (Transform level in levels) {
            //level.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            //level.transform.GetComponent<LevelButtonSizeUp>().Details.SetActive(false);
            level.transform.GetComponent<LevelButtonSizeUp>().Play.SetActive(false); // TEST
        }
        //levels[index].GetComponent<RectTransform>().localScale = new Vector2(1, 1.12f);
        //levels[index].transform.GetComponent<LevelButtonSizeUp>().Details.SetActive(true);
        levels[index].transform.GetComponent<LevelButtonSizeUp>().Play.SetActive(true); // TEST
        levelNumber(index);
        LevelClass levelClass = levelsData.levelClasses[index];
        if (GameSaveData.Instance.levelsLocked[index])
        {
            textToDisplay.text = $"unlock Level {levelClass.levelIndex - 1} to play.";
        }
        else
        {
            textToDisplay.text = "press to play";
        }
        SoundManager.Instance.PlayEffect();
    }
    public void NextScene()
    {
        LevelClass currentLevelClass = levelsData.levelClasses[currentLevel];
        if (!GameSaveData.Instance.levelsLocked[currentLevel])
        {
            SceneLoad.Instance.LoadScene(3);
            SoundManager.Instance.PlayEffect();
        }
        else
        {
            textToDisplay.text = $"unlock Level {currentLevelClass.levelIndex - 1} to play.";
            SoundManager.Instance.PlayEffect();
        }
    }


    public void BackScene() {
        SceneLoad.Instance.LoadScene(1);
        SoundManager.Instance.PlayEffect();
    }
}