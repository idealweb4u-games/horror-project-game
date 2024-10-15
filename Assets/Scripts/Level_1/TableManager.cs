using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tablesInteractable;
    //Position, which depends on which table is interactable now
    [SerializeField] private Transform[] dollPositions;
    [SerializeField] private BlinkEffect blinkEffectToAdd;

    private int tableIndex;
    private GameObject tableToInteract;

    private void Start()
    {
        AssignTableToInteract();
    }

    private void AssignTableToInteract()
    {
        tableIndex = Random.Range(0, tablesInteractable.Length);
        tableToInteract = tablesInteractable[tableIndex];
        if(tableToInteract.AddComponent<BlinkEffect>() == null)
        {
            tableToInteract.AddComponent<BlinkEffect>();
        }
        
    }
}
