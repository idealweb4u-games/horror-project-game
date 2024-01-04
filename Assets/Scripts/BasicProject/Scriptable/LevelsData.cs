using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObject/LevelData")]
public class LevelsData : ScriptableObject {
    public LevelClass[] levelClasses;
}
[System.Serializable]
public class LevelClass {
    public string levelName;
    public int levelTime;
    public string levelDistance;
}
