using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager> {
    public Session session;
    private GameObject player;
    private int levelindex;
    public void Start() {
        LevelManager.Instance.startLevel(
            index: session.level,
           onCompleteCallBack: () => {
               Debug.Log("Show LevelComplete");
               UIManager.Instance.showlevelComplete();
           },
           onGameOverCallBack: () => {
               Debug.Log("Show LevelFail");
               UIManager.Instance.showLevelFail();
           }
            );

    }
   
    public void home() {
        SceneLoad.Instance.LoadScene(1);
        SoundManager.Instance.PlayEffect();
    }
    public void replay() {
        SceneLoad.Instance.LoadScene(3);
        SoundManager.Instance.PlayEffect();
    }
    public void next() {
        if (session.level + 1 < LevelManager.Instance.Levels.Length) session.level++;
        Debug.Log(session.level);
        Debug.Log(session.totalLevel);

        if (session.level >= PlayerPrefs.GetInt("unlocklevels") && session.level < session.totalLevel) {
            Debug.Log("inside lokc");
            PlayerPrefs.SetInt("unlocklevels", PlayerPrefs.GetInt("unlocklevels") + 1);
        }
        Debug.Log("Levels" + PlayerPrefs.GetInt("unlocklevels"));
        SceneLoad.Instance.LoadScene(3);
        SoundManager.Instance.PlayEffect();
    }

}

