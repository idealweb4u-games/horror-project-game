using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpPreventer : MonoBehaviour
{
    private void Update()
    {
        PreventHighJump();
    }
    
    //Used in Level 2 for unexpected behaviour when player grabs body
    private void PreventHighJump()
    {
        if(gameObject.transform.position.y >= 20.0f)
        {
            //Debug.Log("The player is about to jumo into space" + gameObject.transform.position.y);
            gameObject.transform.position = new Vector3(transform.position.x, 16.69f, transform.position.z);
        }
        
    }
}
