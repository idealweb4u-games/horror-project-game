using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
   
    private void Start() {
        StartCoroutine(LoadMenu());
    }
    IEnumerator LoadMenu() {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(1);
    }
   
}
