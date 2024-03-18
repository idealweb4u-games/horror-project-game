using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonGraves : MonoBehaviour
{
    public GameObject[] graves;
    [SerializeField] private Animator animator;
    public float spawnCoolDown;
    public int maxSpawnAmount;
    private float startCoolDown = 10f;
    private int randomSpawn = 0;
    private bool nextRandom = false;
    private int spawnAmount = 0;

    private void Start()
    {
        StartCoroutine(StartSummoning());
    }

    public void Update()
    {
        if (nextRandom == true) 
        {
            if (spawnAmount <= maxSpawnAmount) 
            {
                randomSpawn = Random.Range(0, graves.Length); 
                GameObject _grave = graves[randomSpawn];
                spawnAmount += 1;
                graves[randomSpawn].gameObject.SetActive(true);
            }
            else 
            {
                StartCoroutine(NextGrave());
            }
        } 
    }

    IEnumerator StartSummoning()
    {
        yield return new WaitForSeconds(startCoolDown);
        for (int i = 0; i < graves.Length; i++)
        {
            graves[i].gameObject.SetActive(false);
        }
        animator.SetTrigger("isSummoning");
        yield return new WaitForSeconds(2f);
        nextRandom = true;
    }

    IEnumerator NextGrave()
    {
        nextRandom = false; 
        yield return new WaitForSeconds(spawnCoolDown);
        animator.SetTrigger("isSummoning");
        if (animator.GetBool("isBurning") == true)
        {
            yield return new WaitUntil(() => animator.GetBool("isBurning") == false);
            maxSpawnAmount += 5;
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < graves.Length; i++)
        {
            graves[i].gameObject.SetActive(false);
        }
        spawnAmount = 0;
        nextRandom = true; 
    }


}
