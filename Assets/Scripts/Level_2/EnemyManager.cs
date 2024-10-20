using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy; //HACK later should be changed into cut scene or animation or anything else
    [SerializeField] private GameObject enemyBodyToPut;
    [SerializeField] private GameObject enemnyBodyToDisable;
    [SerializeField] private GameObject enemyBodyToCarry;
    private bool isEnemyCarried = false;

    //for box interactable
    public void CarryEnemy()
    {
        enemnyBodyToDisable.SetActive(false);
        enemyBodyToCarry.SetActive(true);
        isEnemyCarried = true;
    } 

    //for grave interactable
    public void PutEnemyInGrave()
    {
        enemyBodyToPut.SetActive(true);
        enemyBodyToCarry.SetActive(false) ;
        enemy.SetActive(true);
    }
}
