using System.Collections.Generic;
using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class HeroPlayerScript : MonoBehaviour
    {
        public static HeroPlayerScript Instance;
        public GameObject LadderPointInCamera;
        public FirstPersonController firstPersonController;
        public CharacterController characterController;
        public Transform DemonComingPoint;
        public int Health = 100;
        public List<int> Keys_Grabbed = new List<int>();
        [HideInInspector]
        public GameObject Carrying_Ladder = null;
        public GameObject FPSHands;
        public FlashLightScript FlashLight;
        public bool isHoldingBox = false;


        void Start()
        {
            Time.timeScale = 1;
            GameCanvas.Instance.UpdateHealth();
        }

        public void GetDamage(int Damage)
        {
            Health = Health - Damage;
            GameCanvas.Instance.Show_Blood_Effect();
            if (Health < 0) Health = 0;
            GameCanvas.Instance.UpdateHealth();
            if(Health <= 0)
            {
                DeactivatePlayer();
                TouchpadFPSLook.Instance.fCamShakeImpulse = 1;
                GameCanvas.Instance.Show_GameOverPanel();
                if(AdvancedGameManager.Instance.showFPSHands)
                {
                    HeroPlayerScript.Instance.FPSHands.SetActive(false);
                }
            }
            else
            {
                TouchpadFPSLook.Instance.fCamShakeImpulse = 0.5f;
            }
        }

        private void Awake()
        {
            Instance = this;
        }

        public void Grab_Key(int ID)
        {
            Keys_Grabbed.Add(ID);
        }

        public void Get_Health()
        {
            Health = Health + 50;
            if (Health > 100) Health = 100;
            GameCanvas.Instance.UpdateHealth();
        }

        public void ActivatePlayer()
        {
            transform.eulerAngles = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
            firstPersonController.enabled = true;
            characterController.enabled = true;
            transform.eulerAngles = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }

        public void DeactivatePlayer()
        {
            firstPersonController.enabled = false;
            characterController.enabled = false;
        }

        public void ActivatePlayerInputs()
        {
            firstPersonController.enabled = true;
            characterController.enabled = true;
        }
    }
}