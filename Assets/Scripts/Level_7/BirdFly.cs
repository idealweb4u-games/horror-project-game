using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AdvancedHorrorFPS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BirdFly : MonoBehaviour
    {
        public Transform Player;
        public float UpdateRate = 0.1f;
        public int AttackDamage = 25;
        public float attackCoolDown = 3f;
        public float divingCoolDown = .75f;
        public bool canDamage = false;
        private NavMeshAgent Agent;
        public NavMeshTriangulation Triangulation;
        public float IdleLocationRadius = 5f; 
        public float divingSpeed = 10f;
        public float wanderSpeed = 2f;
        private bool onCooldown = false;
        private bool isDiving = false;
        private Coroutine FollowingCoroutine;
        private Vector3 PlayersLastLocation;
        private Vector3 BirdsLastLocation;
        private Rigidbody rb;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            FollowingCoroutine = StartCoroutine(Wandering());
        }

        private IEnumerator Wandering()
        {
            WaitForSeconds wait = new WaitForSeconds(UpdateRate);
            Agent.speed = wanderSpeed;
            while (true)
            {
                if (!Agent.enabled || !Agent.isOnNavMesh)
                {
                    yield return wait;
                }
                else if (Agent.remainingDistance <= Agent.stoppingDistance)
                {
                    Vector2 point = Random.insideUnitCircle * IdleLocationRadius; // Random point in unity circle multiplied by radius
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(Agent.transform.position + new Vector3(point.x, 0, point.y), out hit, 3f, Agent.areaMask))
                    {
                        Agent.SetDestination(hit.position);
                    }
                }
                yield return wait;
            }
        }

        // If player in range then swoop down towards the player. Rest in the air for a few seconds. If player still in range then swoop down again.
        private IEnumerator SwoopAttack()
        {
            //rb.isKinematic = false;
            onCooldown = true;
            isDiving = true;
            Vector3 direction = (PlayersLastLocation - transform.position).normalized;
            rb.velocity = direction * divingSpeed;
            canDamage = true;

            yield return new WaitForSeconds(divingCoolDown);
            transform.position = BirdsLastLocation;
            rb.velocity = Vector3.zero;
            isDiving = false;
            Agent.enabled = true;
            //rb.isKinematic = true;
            canDamage = false;
            FollowingCoroutine = StartCoroutine(Wandering());

            yield return new WaitForSeconds(attackCoolDown);
            onCooldown = false;
            canDamage = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (canDamage && other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collided with player");
                DamagePlayer();
                canDamage = false;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && !onCooldown && !isDiving)
            {
                Debug.Log("Chase Player!!!");
                PlayersLastLocation = Player.transform.position; // Players last known position
                Agent.enabled = false; // Disable agent
                BirdsLastLocation = transform.position; // Birds last position before diving
                FollowingCoroutine = StartCoroutine(SwoopAttack());
            }
        }

        private void DamagePlayer()
        {
            if (AdvancedGameManager.Instance.gameType == GameType.DieWhenYouAreCaught)
            {
            //  if (attacked == false)
            // {
                   // animator.SetTrigger("Attack"); // TEST
                    Agent.enabled = false;
                 //   GetComponent<CapsuleCollider>().enabled = false;
                // attacked = true;
                    transform.parent = Camera.main.transform;
                    transform.localEulerAngles = new Vector3(0, -180, 0);
                    transform.localPosition = HeroPlayerScript.Instance.DemonComingPoint.localPosition;
                    HeroPlayerScript.Instance.GetDamage(100);
                    AudioManager.Instance.Play_DemonKilling();
            //  }
            }
            else
            {
            // attacked = true;
                // audioSource.PlayOneShot(Audio_Hits[UnityEngine.Random.Range(0, Audio_Hits.Length)]);
                HeroPlayerScript.Instance.GetDamage(AttackDamage);
            }
        }

    }
}
