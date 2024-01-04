//using UnityEngine;
//using GoogleMobileAds.Api;
//using GoogleMobileAds.Common;
//using System;

//public class AdmobAds : MonoBehaviour {
//    public static AdmobAds Instance;
//#if UNITY_ANDROID
//    public string GameID = "ca-app-pub-3940256099942544/3347511713";
//    public string leftbannerAdId = "ca-app-pub-3940256099942544/6300978111";
//    public string rightbannerAdId = "";
//    public string InterstitialAdID = "ca-app-pub-3940256099942544/1033173712";
//    public string rewarded_Ad_ID = "ca-app-pub-3940256099942544/5224354917";
//#endif

//    public BannerView leftbannerAd;
//    public BannerView rightbannerAd;
//    public InterstitialAd interstitial;
//    public RewardBasedVideoAd rewardedAd;

//    public static AdmobAds instance;

//    private void Awake() {
//        if (instance != null) {
//            Destroy(gameObject);
//        } else {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        rewardedAd = RewardBasedVideoAd.Instance;
//    }

//    // Start is called before the first frame update
//    void Start() {

//        MobileAds.Initialize(GameID);
//        leftreqBannerAd();
//        requestInterstital();
//        loadRewardVideo();

//    }

//    #region rewarded Video Ads

//    public void loadRewardVideo() {
//        rewardedAd.LoadAd(new AdRequest.Builder().Build(), rewarded_Ad_ID);

//        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
//        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
//        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
//        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
//        rewardedAd.OnAdRewarded += HandleUserEarnedReward;
//        rewardedAd.OnAdLeavingApplication += HandleOnRewardAdleavingApp;

//    }

//    /// rewarded video events //////////////////////////////////////////////

//    public event EventHandler<EventArgs> OnAdLoaded;

//    public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

//    public event EventHandler<EventArgs> OnAdOpening;

//    public event EventHandler<EventArgs> OnAdStarted;

//    public event EventHandler<EventArgs> OnAdClosed;

//    public event EventHandler<Reward> OnAdRewarded;

//    public event EventHandler<EventArgs> OnAdLeavingApplication;

//    public event EventHandler<EventArgs> OnAdCompleted;

//    /// Rewared events //////////////////////////



//    public void HandleRewardedAdLoaded(object sender, EventArgs args) {
//        Debug.Log("Video Loaded");
//    }

//    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
//        Debug.Log("Video not loaded");
//    }

//    public void HandleRewardedAdOpening(object sender, EventArgs args) {
//        Debug.Log("Video Loading");
//    }

//    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args) {
//        Debug.Log("Video Loading failed");
//    }

//    public void HandleRewardedAdClosed(object sender, EventArgs args) {
//        Debug.Log("Video Loading failed");
//    }

//    public void HandleUserEarnedReward(object sender, Reward args) {
//        /// reward the player here --------------------
//        CoinsManager.Instance.SetCoins();
//    }

//    public void HandleOnRewardAdleavingApp(object sender, EventArgs args) {
//        Debug.Log("when user clicks the video and open a new window");
//    }



//    public void showVideoAd() {
//        if (rewardedAd.IsLoaded()) {
//            rewardedAd.Show();
//        } else {
//            Debug.Log("Rewarded Video ad not loaded");
//        }
//    }

//    #endregion

//    #region banner

//    public void leftreqBannerAd() {
//        this.leftbannerAd = new BannerView(leftbannerAdId, AdSize.Banner, AdPosition.Bottom);

//        // Called when an ad request has successfully loaded.
//        this.leftbannerAd.OnAdLoaded += this.HandleOnAdLoaded;
//        // Called when an ad request failed to load.
//        this.leftbannerAd.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;

//        AdRequest request = new AdRequest.Builder().Build();

//        this.leftbannerAd.LoadAd(request);

//    }


//    public void lefthideBanner() {
//        this.leftbannerAd.Hide();
//    }


//    public void rightreqBannerAd() {
//        this.rightbannerAd = new BannerView(rightbannerAdId, AdSize.Banner, AdPosition.TopRight);

//        // Called when an ad request has successfully loaded.
//        this.rightbannerAd.OnAdLoaded += this.HandleOnAdLoaded;
//        // Called when an ad request failed to load.
//        this.rightbannerAd.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;

//        AdRequest requestt = new AdRequest.Builder().Build();

//        this.rightbannerAd.LoadAd(requestt);

//    }


//    public void righthideBanner() {
//        this.rightbannerAd.Hide();
//    }

//    public void destroyBannerAd() {
//        if (leftbannerAd != null) leftbannerAd.Destroy();
//    }



//    #endregion

//    #region interstitial

//    public void requestInterstital() {
//        this.interstitial = new InterstitialAd(InterstitialAdID);

//        this.interstitial.OnAdLoaded += this.HandleOnAdLoaded;
//        // Called when an ad request failed to load.
//        this.interstitial.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
//        // Called when an ad is clicked.
//        this.interstitial.OnAdOpening += this.HandleOnAdOpened;
//        // Called when the user returned from the app after an ad click.
//        this.interstitial.OnAdClosed += this.HandleOnAdClosed;
//        // Called when the ad click caused the user to leave the application.
//        this.interstitial.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

//        AdRequest request = new AdRequest.Builder().Build();

//        this.interstitial.LoadAd(request);
//    }

//    public void ShowInterstitialAd() {
//        if (this.interstitial.IsLoaded()) {
//            Debug.Log("here inter show");
//            this.interstitial.Show();
//        }
//    }
//    public void destroyInterstitialAd() {
//        this.interstitial.Destroy();
//    }
//    #endregion

//    #region adDelegates

//    //Delegates that i dont know
//    public void HandleOnAdLoaded(object sender, EventArgs args) {
//        //Debug.Log("Ad Loaded");
//    }

//    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
//        //Debug.Log("couldnt load ad" + args.Message);
//    }

//    public void HandleOnAdOpened(object sender, EventArgs args) {
//        //MonoBehaviour.print("HandleAdOpened event received");
//    }

//    public void HandleOnAdClosed(object sender, EventArgs args) {
//        //Debug.Log("Ad Closed");
//        requestInterstital(); // Optional : in case you want to load another interstial ad rightaway
//    }

//    public void HandleOnAdLeavingApplication(object sender, EventArgs args) {
//        //MonoBehaviour.print("HandleAdLeavingApplication event received");
//    }

//    #endregion
//    private void OnDestroy() {
//        destroyBannerAd();
//        destroyInterstitialAd();
//        this.interstitial.OnAdLoaded -= this.HandleOnAdLoaded;
//        this.interstitial.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
//        this.interstitial.OnAdOpening -= this.HandleOnAdOpened;
//        this.interstitial.OnAdClosed -= this.HandleOnAdClosed;
//        this.interstitial.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
//    }
//}
