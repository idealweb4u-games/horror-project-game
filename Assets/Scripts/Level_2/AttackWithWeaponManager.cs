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

        [SerializeField] private GameObject weaponPrefab, weaponContainer;
        [SerializeField] private Transform startThrowPoint, throwPointTwo, throwPointThree;
        [SerializeField] private float speedForward, speedUpForward;
        [SerializeField] private float speedOfWeaponPath;
        public static AttackWithWeaponManager Instance;

        [Header("UI responsible for weapons")]
        public Button weaponButton;

        private Transform mainCam;
        private Rigidbody weaponRb;
        private GameObject weaponInstantiated;
        private bool wasThrownOnce = false;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            mainCam = GameplayManager.Instance.Camera.transform;
            
        }

        private void Update()
        {
            if(weaponInstantiated != null)
            {
                weaponContainer.transform.position = weaponInstantiated.transform.position;
            }
        }

        public void ThrowObject()
        {
            if (!wasThrownOnce)
            {
                weaponInstantiated = Instantiate(weaponPrefab, startThrowPoint.transform.position, weaponPrefab.transform.rotation);
                //Vector3 throwDirection = mainCam.transform.forward * speedForward + transform.forward * speedUpForward;
                //weaponRb = weaponPrefab.GetComponent<Rigidbody>();
                //weaponRb.AddForce(throwDirection, ForceMode.Impulse);
                weaponInstantiated.transform.position = SetPathOfWeapon();
                weaponContainer.SetActive(true);
                Debug.Log("Should throw weapon");
                wasThrownOnce = true;
            }
        }

        public void GrabWeapon()
        {
            weaponContainer.SetActive(false);
            Destroy(weaponInstantiated);
            wasThrownOnce=false;
        }

        private Vector3 SetPathOfWeapon()
        {
            Vector3 startTwo = Vector3.Lerp(startThrowPoint.position, throwPointTwo.position, speedOfWeaponPath);
            Vector3 twoThird = Vector3.Lerp(throwPointTwo.position, throwPointThree.position, speedOfWeaponPath);

            Vector3 startThird = Vector3.Lerp(startTwo, twoThird, speedOfWeaponPath);
            return startThird;
        }
    }   

}

