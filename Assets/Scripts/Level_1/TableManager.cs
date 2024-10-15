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

    //Make the correct Table blink 
    private void AssignTableToInteract()
    {
        tableIndex = Random.Range(0, tablesInteractable.Length);
        tableToInteract = tablesInteractable[tableIndex];

        BlinkEffect blinkEffect = tableToInteract.GetComponent<BlinkEffect>();

        if (blinkEffect == null)
        {
            blinkEffect = tableToInteract.AddComponent<BlinkEffect>();
        }

        blinkEffect.startColor = new Color(55f / 255f, 55f / 255f, 55f / 255f); 
        blinkEffect.speed = 1.5f;

        //Debug.Log($"Assigned BlinkEffect to table index: {tableIndex}");
    }

}
