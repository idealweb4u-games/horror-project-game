using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CarSelectionScreen : MonoBehaviour {
    public CarSelectionData carData;
    public Session session;
    public int unlockCars;
    public Text
        carName,
        CarModel,
        carSpeed,
        carPrice
        ;
    public GameObject
        buyButton,
        InsufficientCashDlg,
        purchasedCarDlg,
        levelSelection,
        loading
        ;
    private List<Transform> cars = new List<Transform>();
    private int
        totalCars,
        currentCar,
        price,
        startcount
        ;

    private void Awake() {
        //Get All levels
        foreach (Transform child in transform) {
            cars.Add(child);
        }
        totalCars = cars.Count;
        //Inactive All the Levels
        foreach (Transform car in cars) {
            car.gameObject.SetActive(false);
        }
    }
    private void Start() {
        Time.timeScale = 1;
        activateCar(currentCar);
        Debug.Log(PlayerPrefs.GetInt("count"));
        if (PlayerPrefs.GetInt("count") == 0) {
            PlayerPrefs.SetInt("count", PlayerPrefs.GetInt("count") + 1);
            PlayerPrefs.SetInt("free", 1);
        }
        PlayerPrefs.SetInt("Bus" + currentCar + "Status", 1);
        setLevelAttributes(currentCar);
    }
    private void Update() {
        BusStatus(currentCar);
    }
    public void Back() {
        levelSelection.SetActive(true);
    }
    public void Buy() {
        if (carData.carSelections[currentCar].price < CoinsManager.coinsCount) {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - carData.carSelections[currentCar].price);
            Debug.Log("coins" + PlayerPrefs.GetInt("Coins"));
            carData.carSelections[currentCar].price = 0;
            PlayerPrefs.SetInt("Bus" + currentCar + "Status", 1);
            Debug.LogError(PlayerPrefs.GetInt("Bus" + currentCar + "Status"));
            CoinsManager.Instance.coinsScore.text = "Coins: " + PlayerPrefs.GetInt("Coins");
            purchasedCarDlg.SetActive(true);
        } else {
            InsufficientCashDlg.SetActive(true);
        }
    }
    public void OkInsufficientCashDlg() {
        InsufficientCashDlg.SetActive(false);
    }
    public void OkPurchasedButton() {
        purchasedCarDlg.SetActive(false);
    }
    public void next() {
        if (currentCar < totalCars) {
            currentCar++;
            if (currentCar == totalCars) currentCar--;
            activateCar(currentCar);
            setLevelAttributes(currentCar);
        }
      // AdsManager.Instance.ShowInterstitialAd();
    }
    public void back() {
        if (currentCar > -1) {
            currentCar--;
            if (currentCar == -1) currentCar++;
            activateCar(currentCar);
            setLevelAttributes(currentCar);
        }
       //AdsManager.Instance.ShowInterstitialAd();

    }
    private void activateCar(int index) {
        foreach (Transform car in cars) {
            car.gameObject.SetActive(false);
        }
        cars[index].gameObject.SetActive(true);
    }
    public void carNumber(int index) {
        session.carNumber = currentCar;
        loading.SetActive(true);
        SceneManager.LoadScene("GamePlay");
    }
    public void setLevelAttributes(int index) {
        carPrice.text = carData.carSelections[index].price.ToString();
        carName.text = carData.carSelections[index].Name.ToString();
        carSpeed.text = carData.carSelections[index].Speed.ToString();
        CarModel.text = carData.carSelections[index].power.ToString();
    }
    void BusStatus(int index) {
        //Get its status if its locked or buyed.
        int status = PlayerPrefs.GetInt("Bus" + index + "Status");
        // Debug.LogError("status" + status);
        if (status == 0) {  //if the status is zero than make it make all buy btn, price enble.
            buyButton.SetActive(true);
            carPrice.transform.parent.gameObject.SetActive(true);
        } else if (status == 1) {  //else disable all locked price tags.
            buyButton.SetActive(false);
            carPrice.transform.parent.gameObject.SetActive(false);
        }

    }
    public void GetCOins() {

    }

}
