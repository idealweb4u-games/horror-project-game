using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyVanish : MonoBehaviour
{
    public static BabyVanish instance;
    public GameObject babyDoll;
    public GameObject jumpScareDoll;
    public GameObject bloodDisplay;
    public GameObject redLight;
    public GameObject enemy;
    private bool alreadyPlayed = false;
    public Vector3 babyEndRotation;
    [SerializeField] private float rotationTime = 1.5f;
    private bool doorOpened = false;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !alreadyPlayed && doorOpened)
        {
            Debug.Log("END");
            alreadyPlayed = true;
            Destroy(redLight);
            enemy.SetActive(false); 
          //  StartCoroutine(RotateBaby());      
        }
    }

    //public void DoorOpened()
    //{
    //    doorOpened = true;
    //}


    //IEnumerator RotateBaby()
    //{
    //    yield return new WaitForSeconds(rotationTime);
    //    // ROTATE BABY
    //    //babyDoll.transform.rotation = Quaternion.Euler(babyEndRotation);
    //    babyDoll.transform.localRotation = Quaternion.Euler(babyEndRotation);
    //    yield return new WaitForSeconds(2f);
    //    babyDoll.SetActive(false); 
    //    ShakeObject.instance?.StartShaking();
    //    LightFlickerEffect.instance?.StartLightFlicker();

    //    // CHANGE so that jumpscare happens after placing down bottle
    //    yield return new WaitForSeconds(4.5f);
    //    BabyJumpScare();
    //}

    //public void BabyJumpScare()
    //{
    //    jumpScareDoll.SetActive(true);
    //    bloodDisplay.SetActive(true);
    //}
}
