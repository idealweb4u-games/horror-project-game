using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class Grave : MonoBehaviour
    {
        public int damage = 20;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
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
                HeroPlayerScript.Instance.GetDamage(damage);
            }
        }
    }
}
