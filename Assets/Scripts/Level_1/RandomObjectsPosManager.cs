using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectsPosManager : MonoBehaviour
{
    [SerializeField] private Transform[] bottlePoss;
    [SerializeField] private Transform[] keyPoss;
    [SerializeField] private GameObject bottlePrefab;
    [SerializeField] private GameObject keyPrefab;

    private int bottlePosId;
    private int keyPosId;

    private void Start()
    {
        SetObjectsPosition();
    }
    private void SetObjectsPosition()
    {
        bottlePosId = Random.Range(0, bottlePoss.Length);
        keyPosId = Random.Range(0, keyPoss.Length);

        bottlePrefab.transform.position = bottlePoss[bottlePosId].position;
        keyPrefab.transform.position = keyPoss[keyPosId].position;
    }
}
