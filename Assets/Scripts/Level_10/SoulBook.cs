using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class SoulBook : MonoBehaviour
    {
        public static SoulBook Instance;
        public int bookHealth = 150;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void TakeDamage(int damage)
        {
            bookHealth -= damage;

            if (bookHealth <= 0)
            {
                Debug.Log("GAMEOVER");
                //GameCanvas.Instance.Show_GameOverPanel(); 
                HeroPlayerScript.Instance.GetDamage(999);
            }
        }
    }
}
