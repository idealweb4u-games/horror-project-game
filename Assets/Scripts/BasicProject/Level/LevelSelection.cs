using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {
    public Session session;
    private List<Transform> levels = new List<Transform>();
    private int
        totalLevels,
        currentLevel,
        levelnumbertext=1,
        unlocklevels
        ;
    public GameObject
       carSelection,
       levelSelection
       ;


    private void Start() {
      foreach(Transform child in transform) {
            levels.Add(child);
        }
      foreach(Transform level in levels) {
            level.GetChild(0).gameObject.GetComponent<Text>().text = levelnumbertext.ToString();
            levelnumbertext++;
        }
       unlocklevels= PlayerPrefs.GetInt("unlocklevels");
        Debug.Log("unlocklevels"+unlocklevels);
      for(int i = 0; i <= unlocklevels; i++) {
            levels[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void levelNumber(int index) {
        if (!levels[index].transform.GetChild(1).gameObject.activeInHierarchy) {
            currentLevel = index;
            session.level = index;
            levelSelection.SetActive(false);
            carSelection.SetActive(true);
        }
    }
}