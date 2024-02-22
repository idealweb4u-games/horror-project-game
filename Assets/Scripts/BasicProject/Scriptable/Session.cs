using UnityEngine;

[CreateAssetMenu(fileName = "Session", menuName = "ScriptableObject/Session")]
public class Session : ScriptableObject {
    public int level;
    public int levelLoad;
    public int totalLevel;
    public int unlocklevels;
    public GameObject Loading;
}