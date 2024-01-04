using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VehicleMoving : MonoBehaviour
{
    public float speed = 10;
    public UnityEvent onGameOver = new UnityEvent();

    private Vector3 startPosition;
    private void Start() {
        startPosition= transform.position;
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Boundary")) {
            transform.position = startPosition;
        }
        if (collision.gameObject.CompareTag("Player")) {
            Time.timeScale = 0;
            UIManager.Instance.showLevelFail();
        }
    }
    void Update()
    {
        transform.Translate(Vector3.forward *speed* Time.deltaTime);
    }
  

}
