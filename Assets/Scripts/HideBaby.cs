using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBaby : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovementScript;
    [SerializeField] private GameObject note;
    private bool alreadyPlayed = false;
    private bool isCollided = false;
    
    private void OnEnable()
    {
        if(isCollided)
        {
            RandomObjectsPosManager.onChangeDollPosition += HideAndChangePosition;
        }
    }

    private void Update()
    {
        if (enemyMovementScript.State == EnemyState.Chase || enemyMovementScript.State == EnemyState.Track)
        {
            Debug.Log("Disable the random doll transfers");
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        RandomObjectsPosManager.onChangeDollPosition -= HideAndChangePosition;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !alreadyPlayed)
        {
            alreadyPlayed = true;
            isCollided = true;
        }
    }
    private void HideAndChangePosition()
    { 
        StartCoroutine(Hide());
        RandomObjectsPosManager.Instance.ChangeDollPosition();
    }
    IEnumerator Hide()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        note.SetActive(true); 
    }
}
