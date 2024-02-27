using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdvancedHorrorFPS
{
    public class PriestGrave : MonoBehaviour
    {
        [SerializeField] private GameObject priest;
        [SerializeField] private BoxScript body;

        void OnTriggerStay(Collider other)
        {
            if ((other.CompareTag("DeadBody") || other.CompareTag("BabyBottle")) && !body.isHolding)
            {
                Debug.Log("Follower has died");
                priest.SetActive(false);

            }
        }
    }
}
