using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class DemonHealth : MonoBehaviour
    {
        public int health = 3;
        [SerializeField] private GameObject tree;
        [SerializeField] private BoxScript torch;
        [SerializeField] private GameObject burnEffect;
        [SerializeField] private Animator animator;

        private bool isBurning = false;


        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Collectable") && !isBurning)
            {
                //if (!other.gameObject.GetComponent<BoxScript>().isHolding)
                other.gameObject.SetActive(false);
                isBurning = true;
                burnEffect.SetActive(true);
                animator.SetBool("isBurning", true);
                StartCoroutine(StopBurning());
            }
        }
        private IEnumerator StopBurning()
        {
            yield return new WaitForSeconds(3f);
            isBurning = false;
            burnEffect.SetActive(false);
            health--;
            animator.SetBool("isBurning", false);
            if (health < 1)
            {
                StartCoroutine(BurnTree());
                animator.SetBool("isBurning", true);
                burnEffect.SetActive(true);
            }
        }

        private IEnumerator BurnTree()
        {
            yield return new WaitForSeconds(3f);
            tree.SetActive(false);
        }

    }
}
