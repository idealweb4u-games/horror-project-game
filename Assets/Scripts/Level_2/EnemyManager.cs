using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy; 
    [SerializeField] private GameObject enemyBodyToPut;
    [SerializeField] private GameObject enemnyBodyToDisable;
    [SerializeField] private GameObject enemyBodyToCarry;
    [SerializeField] private GameObject hint2;
    
    //for box interactable
    public void CarryEnemy()
    {
        enemnyBodyToDisable.SetActive(false);
        enemyBodyToCarry.SetActive(true);
        hint2.SetActive(true);
    } 

    //for grave interactable
    public void PutEnemyInGrave()
    {
        enemyBodyToPut.SetActive(true);
        enemyBodyToCarry.SetActive(false) ;
        enemy.SetActive(true);
    }
}
