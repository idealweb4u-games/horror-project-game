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

        [SerializeField] private GameObject startThrowPoint, weaponPrefab, weaponContainer;
        [SerializeField] private float speedForward, speedUpForward;
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
                Vector3 throwDirection = mainCam.transform.forward * speedForward + transform.forward * speedUpForward;
                weaponRb = weaponPrefab.GetComponent<Rigidbody>();
                weaponRb.AddForce(throwDirection, ForceMode.Impulse);
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
    }
}

