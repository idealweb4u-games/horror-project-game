using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : Singleton<CoinsManager> {
    public Text coinsScore;
    public static int coinAmount;
    public static int coinsCount;

    void Start() {
        coinsCount = PlayerPrefs.GetInt("Coins");
    }
    private void Update() {
        coinsScore.text = "" + PlayerPrefs.GetInt("Coins");
    }
    public void SetCoins() {
        coinsCount += Random.Range(100, 150);
        PlayerPrefs.SetInt("Coins",coinsCount);
        Debug.Log("GetCoins");
    }

}
