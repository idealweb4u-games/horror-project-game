using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] private GameObject tableToInteract;
    //Position, which depends on which table is intera
    [SerializeField] private Transform[] bottlePositions;
    [SerializeField] private BlinkEffect blinkEffectToAdd;
    
}
