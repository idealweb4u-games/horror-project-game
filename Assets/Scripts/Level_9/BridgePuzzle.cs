using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject[] bridges;
    [SerializeField] private GameObject[] hints;
    
    private List <GameObject> correctBridges = new List <GameObject>();

    private void Start()
    {
        StartPuzzle();
    }

    public void StartPuzzle()
    {
        ChoosePath();
        ShowAllBridges();
        ShowHints(false);
    }

    private void ChoosePath()
    {
        correctBridges.Clear(); // Clear current correct path

        // Choose either left or right bridge
        for (int i = 0; i < bridges.Length; i+=2)
        {
            if (i + 1 < bridges.Length) // Stay in bounds
            {
                bool num = Random.Range(0, 2) == 0; // 50%
                if (num)
                {
                    correctBridges.Add(bridges[i]);
                }
                else
                {
                    correctBridges.Add(bridges[i + 1]);
                }
                
            }
        }
    }

    private void ShowAllBridges()
    {
        foreach (GameObject bridge in bridges)
        {
            bridge.SetActive(true);
            bridge.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void ShowHints(bool show)
    {
        foreach (GameObject hint in hints)
        {
            hint.SetActive(show);
        }
    }

    private void HideBridges()
    {
        foreach (GameObject bridge in bridges)
        {
            if (correctBridges.Contains(bridge)) // If bridge is in the correct path
            {
                bridge.GetComponent<MeshRenderer>().enabled = false; // hide bridge
            }
            else
            {
                bridge.SetActive(false); // disable bridge
            }
        }

        ShowHints(true);
    }

    private void OnTriggerStay()
    {
        DisplayCorrectPath();
    }

    private void OnTriggerExit()
    {
        HideBridges();
    }

    private void DisplayCorrectPath() // Show correct path when standing at the edge of the dock
    {
        foreach (GameObject bridge in correctBridges)
        {
            bridge.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
