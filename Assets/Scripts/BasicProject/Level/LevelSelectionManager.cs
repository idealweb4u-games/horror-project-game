using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    [SerializeField] private LevelsData classes;
    [SerializeField] private Button currentLevelBtnPrefab;
    [SerializeField] private TextMeshProUGUI textToDisplay;
    
   
    public void DisplayText(int levelIndexToCheck)
    {
        LevelClass level = classes.levelClasses[levelIndexToCheck];
        if (level.isLocked)
        {
            textToDisplay.text = $"Unlock Level {level.levelIndex - 1} to play.";
        }
        else
        {
            textToDisplay.text = "Press to play!";
        }

    }
}
