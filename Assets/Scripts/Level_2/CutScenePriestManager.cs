using AdvancedHorrorFPS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutScenePriestManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject cutScene;
    [SerializeField] private GameObject cutSceneObjects;
    public GameObject enemy;
    [SerializeField] private GameObject noteThree;
    [SerializeField] private GameObject attackWithWeaponManager;
    [SerializeField] private GameObject player;
    public GameObject fpsHands;
    [SerializeField] private PlayableDirector playableDirector;
    public GameObject enemyInGrave;
    public GameObject intermediateCutScenePosition;
    [HideInInspector] public bool wasPlayed = false;

    public static CutScenePriestManager Instance;

    private void Awake()
    {
        Instance = this;
    }
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
            StopCutScene();
        }
    }
    public void StopCutScene()
    {
        mainCamera.gameObject.SetActive(true);
        enemy.SetActive(true);
        player.SetActive(true);
        cutScene.SetActive(false);
        cutSceneObjects.SetActive(false);
        enemyInGrave.SetActive(false);
        noteThree.SetActive(true);
        attackWithWeaponManager.SetActive(true);
        FindObjectOfType<UIManager>().pauseButton.SetActive(true);
        FindObjectOfType<UIManager>().playerCanvas.SetActive(true);
        FindObjectOfType<UIManager>().skipButton.SetActive(false);
        GameplayManager.Instance.Player.transform.position = intermediateCutScenePosition.transform.position;
        fpsHands.SetActive(true);
        AudioManager.Instance.Play_PriestShout();
    }
    public void EnableCutScene()
    {
        if (ItemScript.isEnemyPlaced && !wasPlayed)
        {
            cutScene.SetActive(true);
            cutSceneObjects.SetActive(true);
            fpsHands.SetActive(false);
            GameplayManager.Instance.Player.SetActive(false);
            FindObjectOfType<UIManager>().pauseButton.SetActive(false);
            FindObjectOfType<UIManager>().playerCanvas.SetActive(false);
            FindObjectOfType<UIManager>().skipButton.SetActive(true);
            wasPlayed = true;
        }
        
    }
}
