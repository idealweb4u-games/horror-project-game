using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Level : MonoBehaviour
{
    public int levelIndex;
    public Material skyboxs;
    public Color lightColor;
    public Transform startPosition;
    public GameObject[] Envirment_items;
    public GameObject
        lightningSettings
        ;
    protected abstract bool m_Completed { get; set; }
    protected bool m_GameOver { get; set; }
    public UnityEvent onComplete = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();
    protected abstract void _initialize();
    public void initialized() {
        RenderSettings.skybox = skyboxs;
        lightningSettings.GetComponent<Light>().color = lightColor;
        for (int i = 0; i < Envirment_items.Length; i++) Envirment_items[i].SetActive(true);
        _initialize();
        PlayerCollision.Instance.onCompleteLevel.AddListener(() => {
            m_Completed = true;
            onComplete?.Invoke();
        });
        PlayerCollision.Instance.onGameOver.AddListener(() => {
            onGameOver?.Invoke();
        });

    }
    private void OnDisable() {
        //GameOverCollision.Instance.onGameOver.RemoveAllListeners();
        //PlayerCollision.Instance.onCompleteLevel.RemoveAllListeners();
        //Timer.Instance.OnTimeComplete.RemoveAllListeners();
    }

}
