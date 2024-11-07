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

        public GameObject weaponPrefab, weaponContainer;
        [SerializeField] private Transform startThrowPoint, throwPointTwo, throwPointThree;
        [SerializeField] private float speedForward, speedUpForward;
        [SerializeField] private float speedOfWeaponPath;
        public GameObject enemyPrefab;
        [Header("UI responsible for weapons")]
        public Button weaponButton;

        public static AttackWithWeaponManager Instance;

        private Transform mainCam;
        private Rigidbody weaponRb;
        [HideInInspector] public GameObject weaponInstantiated;
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

        //public void ThrowObject()
        //{
        //    if (!wasThrownOnce)
        //    {
        //        weaponInstantiated = Instantiate(weaponPrefab, startThrowPoint.transform.position, weaponPrefab.transform.rotation);
        //        weaponInstantiated.transform.position = SetPathOfWeapon();
        //        weaponContainer.SetActive(true);
        //        weaponButton.gameObject.SetActive(false);
        //        wasThrownOnce = true;
        //    }
        //}
        public void ThrowObject()
        {
            if (!wasThrownOnce)
            {
                weaponInstantiated = Instantiate(weaponPrefab, startThrowPoint.transform.position, weaponPrefab.transform.rotation);
                weaponContainer.SetActive(true);
                weaponButton.gameObject.SetActive(false);

                Sequence weaponPathSequence = DOTween.Sequence();

                weaponPathSequence.Append(weaponInstantiated.transform.DOMove(throwPointTwo.position, speedOfWeaponPath))
                                  .Append(weaponInstantiated.transform.DOMove(throwPointThree.position, speedOfWeaponPath))
                                  .OnComplete(() => {
                                      wasThrownOnce = true;
                                  });
            }
        }

        public void GrabWeapon()
        {
            weaponContainer.SetActive(false);
            Destroy(weaponInstantiated);
            wasThrownOnce=false;
        }

        //private Vector3 SetPathOfWeapon()
        //{
        //    Vector3 startTwo = Vector3.Lerp(startThrowPoint.position, throwPointTwo.position, speedOfWeaponPath);
        //    Vector3 twoThird = Vector3.Lerp(throwPointTwo.position, throwPointThree.position, speedOfWeaponPath);

        //    Vector3 startThird = Vector3.Lerp(startTwo, twoThird, speedOfWeaponPath);
        //    return startThird;
        //}
    }   

}

