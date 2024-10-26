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
            GameCanvas.Instance.Panel_GameUI.SetActive(false);
            GameCanvas.Instance.Button_Pauese.SetActive(false);
            AttackWithWeaponManager.Instance.enemyPrefab.SetActive(false);
            AttackWithWeaponManager.Instance.weaponContainer.SetActive(false);
            AttackWithWeaponManager.Instance.weaponPrefab.SetActive(false);
        }
    }
}
