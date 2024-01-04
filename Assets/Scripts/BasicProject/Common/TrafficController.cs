using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    public float speed = 10;
    private Vector3 startPosition;
    private void Start() {
        startPosition = transform.position;
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Boundary")) {
            transform.position = startPosition;
        }
    }
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
