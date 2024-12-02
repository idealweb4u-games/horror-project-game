using AdvancedHorrorFPS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// <summary>This class is used for both Level 3 and 4 cut scene logic</summary>
/// </summary>
public class MirrorCutSceneManager : MonoBehaviour
{
    public static MirrorCutSceneManager Instance;
    [SerializeField] private GameObject mirrorCutScene, graveCutScene, objectsCutScene, fpsHands;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private bool isLevel3, isLevel4; //test for beta version of the game

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        if (director == playableDirector)
        {
            StopCutScene();
        }
    }

    public void StartCutScene()
    {
        if (isLevel3)
        {
            mirrorCutScene.SetActive(true);
        }
        if (!isLevel3)
        {
            graveCutScene.SetActive(true);
        }
        
        objectsCutScene.SetActive(true);
        fpsHands.SetActive(false);
        GameplayManager.Instance.Player.SetActive(false);
        FindObjectOfType<UIManager>().pauseButton.SetActive(false);
        FindObjectOfType<UIManager>().playerCanvas.SetActive(false);
        FindObjectOfType<UIManager>().skipButton.SetActive(false);
        AudioManager.Instance.Play_Clown_Pain();
        AudioManager.Instance.Stop_Clown_Laugh();
        foreach (var enemy in FindObjectsOfType<EnemyMovement>())
        {
            if (enemy.gameObject.CompareTag("Clown") || enemy.gameObject.CompareTag("Pumpkin"))
            {
                enemy.enabled = false;
            }
        }
    }

    private void StopCutScene()
    {
        
        if (isLevel4)
        {
            FindObjectOfType<UIManager>().allBetaLevelsAreCompleted.SetActive(true);
        }
        else
        {
            FindObjectOfType<UIManager>().levelComplete.SetActive(true);
        }
        
    }
}
