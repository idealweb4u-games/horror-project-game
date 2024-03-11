using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CreatureMovement : MonoBehaviour
    {
        public Transform Player;
        public FloorDetection floorDetection;
        public float UpdateRate = 0.1f;
        public EnemyDetection DetectionCheck;
        [SerializeField] private Transform AttackZone;
        [SerializeField] private int AttackDamage;
        private NavMeshAgent Agent;
        private Animator animator;
        private float LastAttackTime = 0;
        public bool attacked = false;
        public float wanderRadius = 5f;

        public EnemyState DefaultState;
        private EnemyState _state;
        private AudioSource audioSource;
        private Coroutine FollowingCoroutine;
        public EnemyState State
        {
            get
            {
                return _state;
            }
            set
            {
                OnStateChange?.Invoke(_state, value); 
                _state = value;
            }
        }

        public delegate void StateChangeEvent(EnemyState oldState, EnemyState newState);
        public StateChangeEvent OnStateChange;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            OnStateChange += StateChangeHandler;
            DetectionCheck.GainSight += GainSightHandler;
            DetectionCheck.LoseSight += LoseSightHandler;
        }

        private void GainSightHandler(HeroPlayerScript player)
        {
           // Debug.Log("Player Detetced");
        }
        private void LoseSightHandler(HeroPlayerScript player)
        {
            State = DefaultState;
          //  Debug.Log("Lost Sight Of Player");
        }

        void FixedUpdate()
        {
            if (floorDetection)
            {
                StartCoroutine(TrackTarget());
            }
        }

        private void StateChangeHandler(EnemyState oldState, EnemyState newState)
        {
            if (oldState != newState)
            {
                if (FollowingCoroutine != null)
                {
                    StopCoroutine(FollowingCoroutine);
                }

                switch (newState)
                {
                    case EnemyState.Idle:
                        FollowingCoroutine = StartCoroutine(Idle());
                        break;
                    case EnemyState.Patrol:
                        FollowingCoroutine = StartCoroutine(Wander());
                        break;
                    case EnemyState.Track:
                        FollowingCoroutine = StartCoroutine(TrackTarget());
                        break;
                }
            }
        }

        private IEnumerator Idle()
        {
            WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
            while(true)
            {
                if (Agent.enabled)
                {
                    Agent.isStopped = true;
                }
                yield return Wait;
            }
        }

        private IEnumerator Wander()
        {
            Agent.isStopped = false;
            WaitForSeconds wait = new WaitForSeconds(UpdateRate);
            while (true)
            {
                if (!Agent.enabled || !Agent.isOnNavMesh)
                {
                    yield return wait;
                }
                else if (Agent.remainingDistance <= Agent.stoppingDistance)
                {
                    Vector2 point = Random.insideUnitCircle * wanderRadius; // Random point in unity circle multiplied by radius
                    NavMeshHit hit;

                    if (NavMesh.SamplePosition(Agent.transform.position + new Vector3(point.x, 0, point.y), out hit, 3f, Agent.areaMask))
                    {
                        Agent.SetDestination(hit.position);
                    }
                }
                yield return wait;
            }

        }

        private IEnumerator TrackTarget()
        {
            animator.SetBool("Chase", true);
            if (Agent.isOnNavMesh)
            {
                Agent.isStopped = false;
            }
            WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
            while(floorDetection.canChase)
            {
                if (Agent.enabled)
                {
                    Agent.SetDestination(Player.transform.position);
                    Vector3 directionToPlayer = Player.transform.position - transform.position;
                    directionToPlayer.y = 0f;

                    if (directionToPlayer != Vector3.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer) * Quaternion.Euler(0, 90, 0);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 280f * Time.deltaTime);
                    }
                    if ((Player.transform.position - AttackZone.transform.position).sqrMagnitude < 1.65f)
                    {
                        Attack();
                    }
                }
                yield return Wait;
            }
            animator.SetBool("Chase", false);
            StopMovement();
        }

        public void StopMovement()
        {
            Agent.isStopped = true;
        }

        private void Attack() 
        {
            if (Time.time > LastAttackTime + 2)
            {
                LastAttackTime = Time.time;
                if (AdvancedGameManager.Instance.gameType == GameType.DieWhenYouAreCaught)
                {
                    if (attacked == false)
                    {
                        animator.SetTrigger("Attack");
                        Agent.enabled = false;
                        GetComponent<CapsuleCollider>().enabled = false;
                        attacked = true;
                        transform.parent = Camera.main.transform;
                        transform.localEulerAngles = new Vector3(0, -180, 0);
                        transform.localPosition = HeroPlayerScript.Instance.DemonComingPoint.localPosition;
                        HeroPlayerScript.Instance.GetDamage(100);
                        AudioManager.Instance.Play_DemonKilling();
                    }
                }
                else
                {
                    animator.SetTrigger("Attack");
                    attacked = true;
                    // audioSource.PlayOneShot(Audio_Hits[UnityEngine.Random.Range(0, Audio_Hits.Length)]);
                    HeroPlayerScript.Instance.GetDamage(AttackDamage);
                }
            }
        }
    }
}
