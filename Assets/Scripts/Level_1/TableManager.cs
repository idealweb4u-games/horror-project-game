using AdvancedHorrorFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] private GameObject bottleToPlace, note, animationBottle, bottleInBox, boxForMilk;
    public GameObject bones;
    [HideInInspector] public bool isBottlePlaced = false, milkBoxIsOpened = false;
    public static TableManager Instance;
    private bool isLoweringMilk = false;


    private void Awake()
    {
        Instance = this;
    }
    public void PlaceBottle()
    {
        isBottlePlaced = true;
        bottleToPlace.gameObject.SetActive(true);
        boxForMilk.gameObject.SetActive(false);
        bottleInBox.gameObject.SetActive(false);
        StartCoroutine(MakeMilkLower());
    }
    
    public void ActivateFinalItems()
    {
        bones.SetActive(true);
        note.SetActive(true);
    }

    public void ActivateMilkBoxOpenning()
    {
        StartCoroutine(OpenMilkBox());
    }

    IEnumerator MakeMilkLower()
    {
        float currentValue = 100;
        int blendShapeIndex = 0;
        if(isLoweringMilk)
        {
            yield break;
        }
        isLoweringMilk = true;
        while (currentValue > 0)
        {

            currentValue -= 20.0f;
            animationBottle.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(blendShapeIndex, Mathf.Max(currentValue, 0));
            yield return new WaitForSeconds(1);
        }
        animationBottle.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(blendShapeIndex, 0);
        isLoweringMilk = false;
    }


    IEnumerator OpenMilkBox()
    {
        float currentValue = 0;

        while (currentValue < 100)
        {
            currentValue += 40.0f;
            boxForMilk.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentValue);
            yield return new WaitForSeconds(1);
        }

        milkBoxIsOpened = true;
        boxForMilk.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100.0f);
        bottleInBox.SetActive(true);
    }

}
