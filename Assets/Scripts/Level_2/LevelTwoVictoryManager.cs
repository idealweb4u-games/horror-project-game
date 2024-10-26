using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoVictoryManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
           GameCanvas.Instance.Panel_LevelComplete.SetActive(true);
        }
    }
}
