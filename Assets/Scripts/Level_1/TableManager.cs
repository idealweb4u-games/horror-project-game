using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] private GameObject bottleToPlace;
    [HideInInspector] public bool isBottlePlaced = false;


    public void PlaceBottle()
    {
        isBottlePlaced = true;
        bottleToPlace.gameObject.SetActive(true);
    }
    
}
