using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGameOverFlow : MonoBehaviour
{
    [SerializeField] private Image preAddScreen, addScreen;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Debug.Log("It is active");
            StartCoroutine(PlayAdd());
        }
    }

    IEnumerator PlayAdd()
    {
        yield return new WaitForSeconds(2.0f);
        preAddScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        addScreen.gameObject.SetActive(true);
    }
}
