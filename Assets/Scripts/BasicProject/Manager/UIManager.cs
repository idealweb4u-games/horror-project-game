using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject
        levelComplete,
        levelFail,
        pauseDlg,
        startDlg,
        loading
;
  public void showlevelComplete() {
        GameplayManager.Instance.sounds.enabled = false;
        levelComplete.SetActive(true);
    }
    public void showLevelFail() {
        GameplayManager.Instance.sounds.enabled = false;
        levelFail.SetActive(true);
    }
    public void pause() {
        Time.timeScale = 0;
        GameplayManager.Instance.sounds.enabled = false;
       pauseDlg.SetActive(true);
    }
    public void resume() {
        Time.timeScale = 1;
        GameplayManager.Instance.sounds.enabled = true;
        pauseDlg.SetActive(false);
    }
    public void start() {
       // GameplayManager.Instance.sounds.SetActive(true);
        Time.timeScale = 1;
        GameplayManager.Instance.sounds.enabled = true;
        startDlg.SetActive(false);
    }

}
