using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedLevelsManager : MonoBehaviour
{
    [SerializeField] private LevelsData levelsData;
    public void UnlockLevels(int currentLevel)
    {
        LevelClass currentLevelClass = levelsData.levelClasses[currentLevel];
        currentLevelClass.isLocked = false;
        GameSaveData.Instance.levelsLocked[currentLevel] = false;
        Debug.Log("Method was called with: " + GameSaveData.Instance.levelsLocked[currentLevel]);
        GameSaveData.Instance.SaveData();
    }
}
