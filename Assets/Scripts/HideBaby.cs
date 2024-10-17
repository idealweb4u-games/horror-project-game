using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBaby : MonoBehaviour
{
    
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
            Debug.Log("Was triggered");
        }
    }
    private void HideAndChangePosition()
    {
        Debug.Log("Position changed because player sees doll");
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
