using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdvancedHorrorFPS
{
    
    public class BurnWitch : MonoBehaviour
    {
        [SerializeField] private GameObject witch;
        [SerializeField] private BoxScript vile;
        [SerializeField] private GameObject bloodVile;
        [SerializeField] private Transform campfire;
        [SerializeField] private ParticleSystem burnEffect;

        private bool vilePlaced = false;
        private bool alreadyPlayed = false;
        private bool alreadyBurned = false;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Vile") && !vile.isHolding && !alreadyPlayed)
            {
                vilePlaced = true;
                Destroy(bloodVile);
                alreadyPlayed = true;
                witch.GetComponent<EnemyMovement>().StartTracking(campfire);
            }
            if (vilePlaced && other.CompareTag("Enemy") && !alreadyBurned)
            {
                alreadyBurned = true;
                burnEffect.Play();
                witch.GetComponent<EnemyMovement>().sprintSpeed = 0f;
                witch.GetComponent<EnemyMovement>().idleSpeed = 0f;
                StartCoroutine(KillWitch());
            }
        }

        IEnumerator KillWitch()
        {
            yield return new WaitForSeconds(4f);
            witch.GetComponent<EnemyMovement>().DeathAnimation();
            //witch.SetActive(false);
        
        }
    }
}
