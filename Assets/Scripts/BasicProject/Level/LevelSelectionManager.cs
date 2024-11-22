using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    [SerializeField] private LevelsData classes;
    [SerializeField] private Button currentLevelBtnPrefab;
    [SerializeField] private Transform content;
    

    private void Start()
    {
        AddLevelButtonsToScrollView();
    }
    private void AddLevelButtonsToScrollView()
    {
        foreach(LevelClass levelClass in classes.levelClasses)
        {
            Debug.Log(levelClass.levelName);
            Button levelBtn = Instantiate(currentLevelBtnPrefab, content);
            levelBtn.image.sprite = levelClass.levelImage;
        }
    }
}
