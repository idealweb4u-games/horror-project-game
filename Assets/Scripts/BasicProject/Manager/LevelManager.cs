using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager :Singleton<LevelManager> {

    public GameObject[] Levels;
    [HideInInspector]
    public Level currentlevel;
    public UnityEvent onComplete = new UnityEvent();
    public UnityEvent onGameOver= new UnityEvent();
    private Session session;
    public void startLevel(int index, UnityAction onCompleteCallBack,UnityAction onGameOverCallBack) {
        currentlevel = Levels[index].GetComponent<Level>();
        Levels[index].SetActive(true);
       GameplayManager.Instance.Player.transform.position = Levels[index].GetComponent<Level_Items>().startPosition.position;
        GameplayManager.Instance.Player.transform.rotation = Levels[index].GetComponent<Level_Items>().startPosition.rotation;
        onComplete.AddListener(onCompleteCallBack);
        onGameOver.AddListener(onGameOverCallBack);
        currentlevel.onComplete.AddListener(() => {
            onComplete?.Invoke();
            onComplete.RemoveAllListeners();
        });
        currentlevel.onGameOver.AddListener(() => {
            onGameOver?.Invoke();
            onGameOver.RemoveAllListeners();
        });
        currentlevel.initialized();
    }
}
