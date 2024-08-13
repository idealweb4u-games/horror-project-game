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
    private void Start() {
        SoundManager.Instance.PlayBackgroundMusic();
        PlayerPrefs.SetInt("unlocklevels",8);
      foreach(Transform child in transform) {
            levels.Add(child);
      }
        int count;
        for (int i = 0; i < levels.Count; i++) {
            //add count and image here.
            count = i;
            levels[i].transform.GetComponent<LevelButtonSizeUp>().LevelImage.sprite = levelsData.levelClasses[i].levelImage; 
            levels[i].transform.GetComponent<LevelButtonSizeUp>().LevelNumber.text = ""+ ++count;
            levels[i].transform.GetComponent<LevelButtonSizeUp>().LevelName.text = levelsData.levelClasses[i].levelName;
        }
       unlocklevels= PlayerPrefs.GetInt("unlocklevels");
        Debug.Log("unlocklevels"+unlocklevels);
        for (int i = 0; i <= unlocklevels; i++) {
            levels[i].transform.GetComponent<LevelButtonSizeUp>().Lock.SetActive(false);
           // levels[i].transform.GetComponent<LevelButtonSizeUp>().Play.SetActive(true);
        }
        for (int i = 0; i <= unlocklevels; i++) {
            levels[i].transform.GetComponent<LevelButtonSizeUp>().Lock.SetActive(false);
          //  levels[i].transform.GetComponent<LevelButtonSizeUp>().Play.SetActive(true);
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
            level.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            level.transform.GetComponent<LevelButtonSizeUp>().Details.SetActive(false);
            level.transform.GetComponent<LevelButtonSizeUp>().Play.SetActive(false); // TEST
        }
        levels[index].GetComponent<RectTransform>().localScale = new Vector2(1, 1.12f);
        levels[index].transform.GetComponent<LevelButtonSizeUp>().Details.SetActive(true);
        levels[index].transform.GetComponent<LevelButtonSizeUp>().Play.SetActive(true); // TEST
        levelNumber(index);
        SoundManager.Instance.PlayEffect();
    }
    public void NextScene() {
        SceneLoad.Instance.LoadScene(3);
        SoundManager.Instance.PlayEffect();
    }
    public void BackScene() {
        SceneLoad.Instance.LoadScene(1);
        SoundManager.Instance.PlayEffect();
    }
}