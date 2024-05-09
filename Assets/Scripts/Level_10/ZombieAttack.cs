using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class ZombieAttack : MonoBehaviour
    {
        
        [SerializeField] private Animator animator;
        [SerializeField] private int attackDamage = 20;

        /// <summary>
        /// If zombies hand hits the player when the attack animation is still playing then damage the player
        /// </summary>

        public void TakeDamage(float damage){}

        void OnTriggerEnter(Collider other)
        {
            if (animator.GetBool("isDead") == false) // If zombie is not already dying
            {
                if (other.gameObject.CompareTag("Player") && animator.GetBool("AttackEvent") == true)
                {
                    HeroPlayerScript.Instance.GetDamage(attackDamage);
                }
                if (other.gameObject.CompareTag("Book") && animator.GetBool("AttackEvent") == true)
                {
                    SoulBook.Instance?.TakeDamage(attackDamage);
                }
            }
        }
    }
}
