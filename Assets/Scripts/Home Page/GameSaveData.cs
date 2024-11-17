using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSaveData : MonoBehaviour
{
    public float volume;
    public float brightness;
    public float vibration;

    public static GameSaveData Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [Serializable]
    class DataToSave
    {
        public float volume;
        public float brightness;
        public float vibration;
        //TODO: save level index
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        data.volume = volume;
        data.brightness = brightness;
        data.vibration = vibration;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/horrorGameSavings.json", json);
        Debug.Log("Save was called");
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/horrorGameSavings.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(json);

            volume = data.volume;
            brightness = data.brightness;
            vibration = data.vibration;
            Debug.Log(path);
        }
        Debug.Log("Load was called");

    }
}
