using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCutSceneManager : MonoBehaviour
{
    public static MirrorCutSceneManager Instance;
    [SerializeField] private GameObject mirrorCutScene;
    [SerializeField] private GameObject objectsCutScene;

    private void Awake()
    {
        Instance = this;
    }

    public void StartCutScene()
    {
        mirrorCutScene.SetActive(true);
        objectsCutScene.SetActive(true);
    }
}
