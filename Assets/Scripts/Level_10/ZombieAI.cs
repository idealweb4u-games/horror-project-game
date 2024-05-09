using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AdvancedHorrorFPS
{
    public class ZombieAI : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float minSpeed;
        [SerializeField] private Collider capsule;
        public float MaxHealth;

        private GameObject Player;
        private GameObject totem;
        private NavMeshAgent Agent;
        private Rigidbody rb;
        private float currentHealth;
        private bool isDead = false;

        private bool canChase = false;

        private void Awake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            totem = GameObject.FindGameObjectWithTag("Book");
            Agent = GetComponent<NavMeshAgent>();
            rb = GetComponent<Rigidbody>();
            currentHealth = MaxHealth;
        }

        private void Start()
        {
            Agent.speed = Random.Range(minSpeed, maxSpeed);
        }

        void Update()
        {
            if (canChase)
            {
            // Agent.SetDestination(Player.transform.position); 
            Agent.SetDestination(totem.transform.position);
            }
        }

        public void TakeDamage(float damage)
        {
            if (!isDead)
            {
                currentHealth -= damage;

                if (currentHealth <= 0)
                {
                    isDead = true;
                    animator.SetBool("isDead", true);
                    SummonUndead.onZombieKilled.Invoke();
                    Agent.speed = 0;
                    capsule.enabled = false;
                    // ADD: Remove zombies destination
                    Agent.SetDestination(gameObject.transform.position);
                    Agent.isStopped = true;
                }
            }
        }


        public void OnDeath()
        {
            Destroy(gameObject);
        }

        public void ChasePlayer() // Called from stand animation
        {
            canChase = true;
            // Enable rigidbody gravity
            rb.useGravity = true;


            // Enable capsule collider
            capsule.enabled = true;
        }

        /// <summary>
        /// Attack when zombie collides with player
        /// Continue attacking when animation ends
        /// </summary>

        //void OnCollisionEnter(Collision collision)
        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Book"))
            {
                animator.SetTrigger("Attack");
                //animator.SetBool("AttackEvent", true); // Delete?
            }
        }
        //void OnCollisionStay(Collision collision)
        void OnTriggerStay(Collider collision)
        {
            if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Book")) && animator.GetBool("AttackEvent") == false)
            {
                animator.SetTrigger("Attack");
                //animator.SetBool("AttackEvent", true); // Delete?
            }
        }

        public void AttackStart() // Attack animation event
        {
            animator.SetBool("AttackEvent", true); // TEST
        }

        public void AttackEnd() // Attack animation event
        {
            animator.SetBool("AttackEvent", false);
        }

        public void EndClimb() // Climb animation event trigger
        {
            //gameObject.transform.position = testLoc.transform.position;
        }
    }
}
