using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandomPos : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform[] weaponPoss;

    private int posIndex;

    private void Start()
    {
        PositionWeapon();
    }

    private void PositionWeapon()
    {
        posIndex = Random.Range(0, weaponPoss.Length);
        weapon.transform.position = weaponPoss[posIndex].position;
    }
}
