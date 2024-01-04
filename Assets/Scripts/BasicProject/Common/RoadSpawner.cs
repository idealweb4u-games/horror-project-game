using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {
    public GameObject Road;
    public GameObject endPoint;
    private int envirmentSpawnCount;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            envirmentSpawnCount++;
            if (envirmentSpawnCount == 50) {
                endPoint.GetComponent<BoxCollider>().enabled = true;
                endPoint.GetComponent<MeshRenderer>().enabled = true;
            }
            Debug.Log("here"+envirmentSpawnCount);
            Road.transform.position = new Vector3(0, 0, gameObject.transform.position.z + 60);
        }
    }
}
