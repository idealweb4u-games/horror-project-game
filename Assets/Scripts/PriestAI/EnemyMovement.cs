using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AdvancedHorrorFPS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        public Transform Player;
        public float UpdateRate = 0.1f;
        private NavMeshAgent Agent;
        private Animator animator;
        public NavMeshTriangulation Triangulation;
        public EnemyDetection DetectionCheck;
        [SerializeField] private Transform AttackZone;
        [SerializeField] private int AttackDamage;

        [SerializeField] private int waypointIndex = 0;
        public Vector3[] Waypoints = new Vector3[6];
        //  public AudioClip[] enemySound=new AudioClip[2];
        private float LastAttackTime = 0;
        public bool attacked = false;

        public EnemyState DefaultState;
        private EnemyState _state;
        private AudioSource audioSource;
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
        public float IdleLocationRadius = 5f;
        public float sprintSpeed = 4f;
        public float idleSpeed = 2;
        private Coroutine FollowingCoroutine;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            OnStateChange += StateChangeHandler;
            DetectionCheck.GainSight += GainSightHandler;
            DetectionCheck.LoseSight += LoseSightHandler;
            // audioSource=GetComponent<AudioSource>();
            // audioSource.clip = enemySound[0];
            // audioSource.Play();
        }


        private void GainSightHandler(HeroPlayerScript player)
        {
            State = EnemyState.Chase;
            Agent.speed = sprintSpeed;
            Debug.Log("Player Detetced");
            animator.SetBool("Chase", true);
        }
        private void LoseSightHandler(HeroPlayerScript player)
        {
            State = DefaultState; // Revert back to last state
            Agent.speed = idleSpeed;
            Debug.Log("Lost Sight Of Player");
            animator.SetBool("Chase", false);
        }

        private void OnDisable()
        {
            _state = DefaultState;
        }

        public void Spawn()
        {
            OnStateChange?.Invoke(EnemyState.Spawn, DefaultState);
        }

        public void Start()
        {
            Triangulation = Triangulation;
            Spawn();
        }

        private void FixedUpdate()
        {
            if (TableManager.Instance.isBottlePlaced)
            {
                State = EnemyState.Die;
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
                if (oldState == EnemyState.Idle)
                {
                    Agent.speed = idleSpeed;
                }

                switch (newState)
                {
                    case EnemyState.Idle:
                        FollowingCoroutine = StartCoroutine(IdleMotion());
                        break;
                    case EnemyState.Patrol:
                        FollowingCoroutine = StartCoroutine(PatrolMotion());
                        break;
                    case EnemyState.Chase:
                        FollowingCoroutine = StartCoroutine(FollowTarget());
                        break;
                    case EnemyState.Die:
                        TurnToBones();
                        break;

                }
            }
        }

        private IEnumerator IdleMotion()
        {
            WaitForSeconds wait = new WaitForSeconds(UpdateRate);
            Agent.speed = idleSpeed;
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

        private IEnumerator PatrolMotion()
        {
            WaitForSeconds wait = new WaitForSeconds(UpdateRate);

            yield return new WaitUntil(() => Agent.enabled && Agent.isOnNavMesh); // Wait till enemy is on the navmesh
            Agent.SetDestination(Waypoints[waypointIndex]);

            while (true)
            {
                if (Agent.isOnNavMesh && Agent.enabled && Agent.remainingDistance <= Agent.stoppingDistance)
                {
                    waypointIndex++;
                }

                if (waypointIndex >= Waypoints.Length)
                {
                    waypointIndex = 0;
                }

                Agent.SetDestination(Waypoints[waypointIndex]);
                yield return wait;
            }
        }

        private IEnumerator FollowTarget()
        {
            WaitForSeconds wait = new WaitForSeconds(UpdateRate);

            while (true)
            {
                if (Agent.enabled)
                {
                    if (Agent.isOnNavMesh)
                    {
                        Agent.SetDestination(Player.position);
                    }
                    else
                    {
                        Debug.LogError("Agent is not on a valid NavMesh!");
                        ChangeEnemyPositionManual();
                    }
                    if ((Player.transform.position - AttackZone.transform.position).sqrMagnitude < 1.65f)
                    {
                        Attack();
                        //  yield return false;
                    }
                }
                yield return wait;
            }
        }

        private void ChangeEnemyPositionManual()
        {
            transform.LookAt(Player.position);
            transform.position = Vector3.Lerp(transform.position, Player.position, Time.deltaTime * idleSpeed * 1.5f);
        }

        public void StartTracking(Transform newTarget)
        {
            Player = newTarget;
            State = EnemyState.Track;
            Agent.speed = sprintSpeed;
            StartCoroutine(TrackTarget());
        }

        private IEnumerator TrackTarget()
        {
            WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
            while (true)
            {
                if (Agent.enabled)
                {
                    Agent.SetDestination(Player.transform.position);
                }
                yield return Wait;
            }
        }

        //TODO set the animation(or just transform) enemy to the bunch of bones
        private void TurnToBones()
        {
            transform.position = Player.transform.position + new Vector3(2.0f, 0.0f, 0.0f); //teleport enemy to the player 
            Debug.Log("Enemy turns into bones");
        }

        private void Attack() // Attack script from Demon
        {
            /*
            if (Agent.enabled)
            {
                Agent.isStopped = true;
            }
            */
            if (Time.time > LastAttackTime + 2)
            {
                LastAttackTime = Time.time;
                if (AdvancedGameManager.Instance.gameType == GameType.DieWhenYouAreCaught)
                {
                    if (attacked == false)
                    {
                        animator.SetTrigger("Attack"); // TEST
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
                    //animator.SetTrigger("Attack");
                    attacked = true;
                    // audioSource.PlayOneShot(Audio_Hits[UnityEngine.Random.Range(0, Audio_Hits.Length)]);
                    HeroPlayerScript.Instance.GetDamage(AttackDamage);
                }
            }
        }

        public void DeathAnimation()
        {
            animator.SetTrigger("Dead");
        }

        public void OnDeath() // Called from Witch's Death Animation
        {
            gameObject.SetActive(false);
        }
    }
}
