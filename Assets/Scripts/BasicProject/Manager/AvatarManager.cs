using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AvatarManager : Singleton<AvatarManager>
{
    public InputField name;
    public Dropdown age;
    public Dropdown countryList;
    public Image photo;
    public Image[] images;
    public GameObject 
        avatarSelection,
        levelSelection
        ;
    private int imageIndex;
    private int count;
    private void Start() {
        if (PlayerPrefs.GetInt("count") ==1) { avatarSelection.SetActive(false);  }
        PlayerPrefs.GetInt("Image");
        setName();
        setImage();
        setCountry();
        setAge();
    }
    public void setName() {
        name.placeholder.GetComponent<Text>().text = PlayerPrefs.GetString("Name");
    }
    public void setAge() {
        age.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("AgeList");
        age.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Age");
    }
    public void setImage() {
        photo.GetComponent<Image>().sprite = images[PlayerPrefs.GetInt("Image")].GetComponent<Image>().sprite;
        photo.GetComponent<Image>().color = images[PlayerPrefs.GetInt("Image")].GetComponent<Image>().color;
    }
    public void setCountry() {
        countryList.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("CountryName");
        countryList.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("CountryName");
    }
    public void selectAge() {
        int index = age.GetComponent<Dropdown>().value;
        string options = age.options[index].text;
        PlayerPrefs.SetInt("Age", index);
        PlayerPrefs.SetString("AgeList", options);
    }
    public void selectCountry() {
        int index = countryList.GetComponent<Dropdown>().value;
        string options = countryList.options[index].text;
        PlayerPrefs.SetInt("Country", index);
        PlayerPrefs.SetString("CountryName", options);
    }
    public void selectImage(int index) {
        photo.GetComponent<Image>().sprite = images[index].GetComponent<Image>().sprite;
        photo.GetComponent<Image>().color = images[index].GetComponent<Image>().color;
        PlayerPrefs.SetInt("Image", index);
        imageIndex = PlayerPrefs.GetInt("Image");
    }
    public void okAvatarScreen() {
        string name = this.name.textComponent.text;
        if (!(string.IsNullOrEmpty(name))) {
            PlayerPrefs.SetString("Name", this.name.textComponent.text.ToString());
        }
        selectCountry();
        selectAge();
        avatarSelection.SetActive(false);
        levelSelection.SetActive(true);
        PlayerPrefs.SetInt("count", 1);
    }

}
