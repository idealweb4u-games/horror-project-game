using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    [RequireComponent(typeof(SphereCollider))]
    public class EnemyDetection : MonoBehaviour
    {
        public SphereCollider collider;
        public LayerMask lineOfSightLayer;

        public delegate void GainSightEvent(HeroPlayerScript player); 
        public GainSightEvent GainSight;
        public delegate void LoseSightEvent(HeroPlayerScript player); 
        public LoseSightEvent LoseSight;

        public float fieldOfView = 90f;
        public float threshold = 1f;

        private Coroutine CheckLineOfSightCoroutine;


        private void Awake()
        {
            collider = GetComponent<SphereCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            HeroPlayerScript player;
            if (other.TryGetComponent<HeroPlayerScript>(out player))
            {
                if (!CheckLineOfSight(player))
                {
                    CheckLineOfSightCoroutine = StartCoroutine(CheckForLineOfSight(player));
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            HeroPlayerScript player;
            if (other.TryGetComponent<HeroPlayerScript>(out player))
            {
                LoseSight?.Invoke(player);
                if (CheckLineOfSightCoroutine != null)
                {
                    StopCoroutine(CheckLineOfSightCoroutine);
                }
            }
        }

        private bool CheckLineOfSight(HeroPlayerScript player)
        {
            Vector3 Direction = (player.transform.position - transform.position).normalized;
            if (Vector3.Dot(transform.forward, Direction) >= Mathf.Cos(fieldOfView))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Direction, out hit, collider.radius, lineOfSightLayer))
                {
                    if (hit.transform.GetComponent<HeroPlayerScript>() != null)
                    {
                        GainSight?.Invoke(player);
                        return true;
                    }
                }
            }
            return false;
        }


        private IEnumerator CheckForLineOfSight(HeroPlayerScript player)
        {
            WaitForSeconds wait = new WaitForSeconds(threshold);

            while (!CheckLineOfSight(player))
            {
                yield return wait;
            }
        }

    }
}
