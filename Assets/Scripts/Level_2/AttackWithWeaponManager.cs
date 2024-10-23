using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace AdvancedHorrorFPS
{
    [RequireComponent(typeof(Rigidbody))]
    public class AttackWithWeaponManager : MonoBehaviour
    {

        [SerializeField] private GameObject startThrowPoint, weapon;
        [SerializeField] private float speedForward, speedUpForward;
        public static AttackWithWeaponManager Instance;

        [Header("UI responsible for weapons")]
        public Button weaponButton;

        private Transform mainCam;

        private Rigidbody weaponRb;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            mainCam = GameplayManager.Instance.Camera.transform;
            weaponRb = weapon.GetComponent<Rigidbody>();
        }

        public void ThrowObject()
        {
            Vector3 throwDirection = mainCam.transform.forward * speedForward + transform.forward * speedUpForward;
            weaponRb.AddForce(throwDirection, ForceMode.Impulse);
            Debug.Log("Should throw weapon");
        }

        public void GrabWeapon()
        {
            weapon.transform.position = startThrowPoint.transform.position;
        }
    }
}

