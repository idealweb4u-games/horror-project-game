using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCompletePoint : Singleton<LevelCompletePoint> {
    public static bool
        isFl,
        isFR,
        isRl,
        isRR,
        ispark
        ;
    public void Update() {
        if (isFR && isFl && isRR && isRl) {
            ispark = true;
            Debug.Log("finalyy");
            PlayerCollision.Instance.complete();
            isFR = false;
            isFl = false;
            isRl = false;
            isRR = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("FL")) {
            isFl = true;
            Debug.Log("FL");
        }
        if (other.gameObject.CompareTag("FR")) {
            Debug.Log("FR");
            isFR = true;
        }
        if (other.gameObject.CompareTag("RL")) {
            Debug.Log("RL");
            isRl = true;
        }
        if (other.gameObject.CompareTag("RR")) {
            Debug.Log("RR");
            isRR = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("FL")) {
            isFl = false;
        }
        if (other.gameObject.CompareTag("FR")) {
            isFR = false;
        }
        if (other.gameObject.CompareTag("RL")) {
            isRl = false;
        }
        if (other.gameObject.CompareTag("RR")) {
            isRR = false;
        }
    }
}
