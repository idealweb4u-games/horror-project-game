using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private GameObject gate, gateLock, chain;
    private bool gateIsOpened = false;

    public static GateManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UnlockNextLevel()
    {
        StartCoroutine(OpenGate());
        if(gateIsOpened)
        {
            UIManager.Instance.showlevelComplete();
        }
    }

    IEnumerator OpenGate()
    {
        float currentValue = 0;

        while (currentValue < 100)
        {
            currentValue += 50.0f;
            gate.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            SetNultipleBlendShapeWeight(currentValue);
            yield return new WaitForSeconds(.5f);
        }

        gateIsOpened = true;
        gate.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100.0f);
    }

    private void SetNultipleBlendShapeWeight(float currentValue)
    {
        SkinnedMeshRenderer skinnedMeshRenderer = gateLock.GetComponent<SkinnedMeshRenderer>();

        if(skinnedMeshRenderer.sharedMesh.blendShapeCount >= 2 )
        {
            gateLock.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            gateLock.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
        }
        if (skinnedMeshRenderer.sharedMesh.blendShapeCount >= 6)
        {
            chain.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            chain.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            chain.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            chain.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            chain.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            chain.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
        }
    }
}
