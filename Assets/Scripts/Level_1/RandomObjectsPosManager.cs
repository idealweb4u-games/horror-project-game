using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectsPosManager : MonoBehaviour
{
    [SerializeField] private Transform[] bottlePoss;
    [SerializeField] private Transform[] keyPoss;
    [SerializeField] private Transform[] dollPoss;
    [Header("Prefabs")]
    [SerializeField] private GameObject bottlePrefab;
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private GameObject dollPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private float timeBeforeChange = 30.0f;

    private int bottlePosId;
    private int keyPosId;
    private int dollPosId;

    public delegate void OnChangeDollPosition();
    public static event OnChangeDollPosition onChangeDollPosition;

    public static RandomObjectsPosManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetObjectsPosition();
        onChangeDollPosition?.Invoke(); 
        
    }
    private void OnEnable()
    {
        onChangeDollPosition += CallDollChange;
    }
    private void OnDisable()
    {
        onChangeDollPosition -= CallDollChange;
    }

    private void SetObjectsPosition()
    {
        bottlePosId = Random.Range(0, bottlePoss.Length);
        keyPosId = Random.Range(0, keyPoss.Length);

        bottlePrefab.transform.position = bottlePoss[bottlePosId].position;
        keyPrefab.transform.position = keyPoss[keyPosId].position;
    }

    public void ChangeDollPosition()
    {
        dollPosId = Random.Range(0, dollPoss.Length);
        dollPrefab.transform.position = dollPoss[dollPosId].position;
        Vector3 rotation = dollPrefab.transform.rotation.eulerAngles;
        switch (dollPosId)
        {
            case 1:
            case 2:
            case 3:
                rotation.y = 90.0f;
                dollPrefab.transform.rotation = Quaternion.Euler(rotation);
                break;
            case 0:
            case 4:
            case 5:
                rotation.y = -90.0f;
                dollPrefab.transform.rotation = Quaternion.Euler(rotation);
                break;
        }
    }

    private void CallDollChange()
    {
        StartCoroutine(TeleportDoll());
    }

    private IEnumerator TeleportDoll()
    {
        while(true)
        {
            ChangeDollPosition();
            Debug.Log("Doll changes position from coroutine");
            yield return new WaitForSeconds(timeBeforeChange);
            if (!dollPrefab.activeSelf)
            {
                yield break;
            }
        }
    }
}
