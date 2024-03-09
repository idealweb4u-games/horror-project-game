using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BirdFly : MonoBehaviour
{
    public Transform Player;
    public float UpdateRate = 0.1f;
    public int damage = 25;
    public float coolDown = 3f;
    public bool canDamage = false;
    private NavMeshAgent Agent;
    //private Animator animator;
    public EnemyState DefaultState;
    private EnemyState _state;
    //private AudioSource audioSource;
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


    // If player in range then swoop down towards the player. Rest in the air for a few seconds. If player still in range then swoop down again.
    private IEnumerator SwoopAttack()
    {
        WaitForSeconds wait = new WaitForSeconds(UpdateRate);
        while (true)
        {
            if (Agent.enabled)
            {
                Agent.SetDestination(Player.transform.position);
                /*
                if ((Player.transform.position - AttackZone.transform.position).sqrMagnitude < 1.65f)
                {
                    DamagePlayer();
                }
                */
            }
            yield return wait;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canDamage && other.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
            canDamage = false;
        }
    }

    private void DamagePlayer()
    {
        /*
        if (AdvancedGameManager.Instance.gameType == GameType.DieWhenYouAreCaught)
        {
          //  if (attacked == false)
           // {
                animator.SetTrigger("Attack"); // TEST
                Agent.enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
               // attacked = true;
                transform.parent = Camera.main.transform;
                transform.localEulerAngles = new Vector3(0, -180, 0);
                transform.localPosition = HeroPlayerScript.Instance.DemonComingPoint.localPosition;
               // HeroPlayerScript.Instance.GetDamage(100);
                AudioManager.Instance.Play_DemonKilling();
          //  }
        }
        else
        {
           // attacked = true;
            // audioSource.PlayOneShot(Audio_Hits[UnityEngine.Random.Range(0, Audio_Hits.Length)]);
          //  HeroPlayerScript.Instance.GetDamage(AttackDamage);
            StartCoroutine(AttackCoolDown());
        }
    */
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        canDamage = true;
    }

}
