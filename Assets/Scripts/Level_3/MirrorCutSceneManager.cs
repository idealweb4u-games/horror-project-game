using AdvancedHorrorFPS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MirrorCutSceneManager : MonoBehaviour
{
    public static MirrorCutSceneManager Instance;
    [SerializeField] private GameObject mirrorCutScene, objectsCutScene, fpsHands;
    [SerializeField] private PlayableDirector playableDirector;

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
        mirrorCutScene.SetActive(true);
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
            if (enemy.gameObject.CompareTag("Clown"))
            {
                enemy.enabled = false;
            }
        }
    }

    private void StopCutScene()
    {
        FindObjectOfType<UIManager>().levelComplete.SetActive(true);
        
    }
}
