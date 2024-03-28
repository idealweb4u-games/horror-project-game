using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class SkullAttack : MonoBehaviour
    {
        [SerializeField] private int attackDamage = 15;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collided with player");
                DamagePlayer();
            }
        }

        private void DamagePlayer()
        {
            if (AdvancedGameManager.Instance.gameType == GameType.DieWhenYouAreCaught)
            {
                transform.parent = Camera.main.transform;
                transform.localEulerAngles = new Vector3(0, -180, 0);
                transform.localPosition = HeroPlayerScript.Instance.DemonComingPoint.localPosition;
                HeroPlayerScript.Instance.GetDamage(100);
                AudioManager.Instance.Play_DemonKilling();
            }
            else
            {
                HeroPlayerScript.Instance.GetDamage(attackDamage);
            }
        }
    }
}
