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

    private bool wasPlayed = false;
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
            enemyInGrave.SetActive(false);
        }
    }

    public void EnableCutScene()
    {
        if (ItemScript.isEnemyPlaced && !wasPlayed)
        {
            cutScene.SetActive(true);
            cutSceneObjects.SetActive(true);
            player.SetActive(false);
            wasPlayed = true;
        }
    }
}
