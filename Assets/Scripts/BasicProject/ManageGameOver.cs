using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageGameOver : MonoBehaviour
{
    private static int i = 5;
    [SerializeField] private Image preAddScreen, addScreen;
    [SerializeField] private TextMeshProUGUI timer, timerWithSeconds;

    private void Start()
    {
        StartCoroutine(PlayAdd());
    }

    IEnumerator PlayAdd()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(2.0f);
        preAddScreen.gameObject.SetActive(true);
        InvokeRepeating("UpdateTimer", 0f, 1f);
        yield return new WaitForSeconds(5.0f);
        CancelInvoke("UpdateTimer");
        addScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        StopShowAdd();
    }

    // Method to update the timer text
    void UpdateTimer()
    {
        timer.text = i.ToString();
        timerWithSeconds.text = i.ToString() + " seconds";
        i--;
        if(i<0)
        {
            i = 5;
        }
    }

    //TODO: Implement ads
    private void StopShowAdd()
    {
        Debug.Log("After the end of watching ad");
        FindObjectOfType<GameUIManager>().Play();
    }
}
