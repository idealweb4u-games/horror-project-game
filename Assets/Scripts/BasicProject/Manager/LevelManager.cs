using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager :Singleton<LevelManager> {

    public GameObject[] Levels;
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public Level currentlevel;
    public UnityEvent onComplete = new UnityEvent();
    public UnityEvent onGameOver= new UnityEvent();
    private Session session;
    public void startLevel(int index, UnityAction onCompleteCallBack,UnityAction onGameOverCallBack) {
        //Debug.Log("cureent level" + index);
        player = VehicleManager.Instance.currentVehicle;
        currentlevel = Levels[index].GetComponent<Level>();
        Levels[index].SetActive(true);
        player.transform.position = Levels[index].GetComponent<Level_Items>().startPosition.position;
        player.transform.rotation = Levels[index].GetComponent<Level_Items>().startPosition.rotation;
        //Debug.Log("here in level manager");
        onComplete.AddListener(onCompleteCallBack);
        onGameOver.AddListener(onGameOverCallBack);
        currentlevel.onComplete.AddListener(() => {
            onComplete?.Invoke();
            //Debug.Log("Oncomplete");
            onComplete.RemoveAllListeners();
        });
        currentlevel.onGameOver.AddListener(() => {
            onGameOver?.Invoke();
            onGameOver.RemoveAllListeners();
        });
        currentlevel.initialized();
    }
}
