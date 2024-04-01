using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class WaterDetection : MonoBehaviour
    {
         void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                HeroPlayerScript.Instance.GetDamage(100);
                AudioManager.Instance.Play_DemonKilling();
            }
        }
    }
}
