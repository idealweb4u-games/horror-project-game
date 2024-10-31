using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire;
    public GameObject key;
    private bool wasPlayed = false;
    public static AltarManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void BurnBones()
    {
        if (!wasPlayed)
        {
            fire.Play();
            wasPlayed = true;
        }
        else
        {
            key.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
