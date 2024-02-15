using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject SeetingScreen;
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
}
