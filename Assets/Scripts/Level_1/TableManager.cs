using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] private GameObject bottleToPlace;
    [HideInInspector] public bool isBottlePlaced = false;
    public static TableManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaceBottle()
    {
        isBottlePlaced = true;
        bottleToPlace.gameObject.SetActive(true);
    }
    
}
