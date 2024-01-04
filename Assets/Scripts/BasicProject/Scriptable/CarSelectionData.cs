using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObject/CarData")]
public class CarSelectionData : ScriptableObject
{
    public CarSelection[] carSelections;
}
[System.Serializable]
public class CarSelection {
    public string
        Name,
        Speed,
        power
        ;
    public int price;
}

