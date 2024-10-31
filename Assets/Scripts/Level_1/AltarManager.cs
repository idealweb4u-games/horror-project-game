using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire;
    public GameObject key;

    public static AltarManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void BurnBones()
    {
        fire.Play();
        if (fire.isStopped)
        {
            key.SetActive(true);
        }
    }
}
