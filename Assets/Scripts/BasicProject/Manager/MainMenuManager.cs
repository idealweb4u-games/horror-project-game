using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject levelSelectionPanel;
    public GameObject settings;
    public GameObject mainMenu;

    public void ExitButton() {
        Application.Quit();
    }
    public void AboutUs() {
       // Application.OpenURL("https://play.google.com/store/apps/developer?id=Fun+and+Learn");
    }
    public void RateUs() {
#if UNITY_ANDROID
      //  Application.OpenURL("market://details?id=com.FunAndLearn.CarParking");
#elif UNITY_IPHONE
 Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
#endif
    }
    public void Play() {
        gameObject.SetActive(false);
        // AdmobAds.instance.ShowInterstitialAd();
    }

    //Main Menu Buttons
    public void MainMenuBtn()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        levelSelectionPanel.SetActive(false);
    }

    public void NewGameBtn()
    {
        LoadMenu();
    }

    //coroutine for start Game
    public void LoadMenu()
    {
        
        SceneManager.LoadScene(3);
    }


    public void LoadGameBtn()
    {

    }

    public void settingBtn()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);
        levelSelectionPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }


    //Middle Btns
    public void GameTutorialBtn()
    {

    }

    public void levelSelectBtn()
    {
        levelSelectionPanel.SetActive(true);
        settings.SetActive(false);
        mainMenu.SetActive(false);
    }

    

}
