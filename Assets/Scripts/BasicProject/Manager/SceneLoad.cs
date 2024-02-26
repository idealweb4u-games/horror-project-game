using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : Singleton<SceneLoad> {
    public Session session;
    public AudioClip loadingClip;
    private GameObject loadingScreen;
    public void LoadScene(int n) {
        SoundManager.Instance.AssignMusicClip(loadingClip);
        SoundManager.Instance.PlayMusic();
        loadingScreen = Instantiate(session.Loading, transform);
        StartCoroutine(StartLoad(n));
    }
    IEnumerator StartLoad(int n) {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(n);
        yield return new WaitForSeconds(0.4f);
        Destroy(loadingScreen);
    }
}
