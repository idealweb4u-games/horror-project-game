using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TableData", menuName = "ScriptableObject/TableData")]
public class TableData : ScriptableObject
{
    public bool isTableForBottle;
    public int tableID;
    public GameObject table;
}
