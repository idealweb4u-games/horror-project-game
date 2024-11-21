using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageLevelComplete : MonoBehaviour
{
    private static int i = 5;
    [SerializeField] private Image addScreen, nextLevelScreen;
    [SerializeField] private TextMeshProUGUI timer, timerWithSeconds;

    private void Start()
    {
        StartCoroutine(PlayAdd());
    }

    IEnumerator PlayAdd()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("UpdateTimer", 0f, 1f);
        yield return new WaitForSeconds(5.0f);
        CancelInvoke("UpdateTimer");
        addScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        ShowNextLevel();
    }

    // Method to update the timer text
    void UpdateTimer()
    {
        timer.text = i.ToString();
        timerWithSeconds.text = i.ToString() + " seconds";
        i--;
    }

    //TODO: Implement ads
    private void ShowNextLevel()
    {
        Debug.Log("After the end of watching ad");
        nextLevelScreen.gameObject.SetActive(true);
    }
}
