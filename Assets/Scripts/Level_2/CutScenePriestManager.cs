using AdvancedHorrorFPS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutScenePriestManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject cutScene;
    [SerializeField] private GameObject cutSceneObjects;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private GameObject enemyInGrave;
    public GameObject intermediateCutScenePosition;
    [HideInInspector] public bool wasPlayed = false;
    private void OnEnable()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;
    }
    private void Update()
    {
        EnableCutScene();
    }
    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        if(director == playableDirector)
        {
            mainCamera.gameObject.SetActive(true);
            enemy.SetActive(true);
            player.SetActive(true);
            cutScene.SetActive(false);
            cutSceneObjects.SetActive(false);
            FindObjectOfType<UIManager>().pauseButton.SetActive(true);
            FindObjectOfType<UIManager>().playerCanvas.SetActive(true);
            FindObjectOfType<UIManager>().skipButton.SetActive(false);
            GameplayManager.Instance.Player.transform.position = intermediateCutScenePosition.transform.position;
            Destroy(enemyInGrave);
            AudioManager.Instance.Play_PriestShout();
        }
    }

    public void EnableCutScene()
    {
        if (ItemScript.isEnemyPlaced && !wasPlayed)
        {
            cutScene.SetActive(true);
            cutSceneObjects.SetActive(true);
            player.SetActive(false);
            FindObjectOfType<UIManager>().pauseButton.SetActive(false);
            FindObjectOfType<UIManager>().playerCanvas.SetActive(false);
            FindObjectOfType<UIManager>().skipButton.SetActive(true);
            wasPlayed = true;
        }
    }
}
