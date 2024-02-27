using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdvancedHorrorFPS
{
    public class GraveHint : MonoBehaviour
    {
        [SerializeField] private GameObject note;
        [SerializeField] private BoxScript body;
        private bool alreadyPlayed = false;

        void Update()
        {
            if (body.isHolding && !alreadyPlayed)
            {
                alreadyPlayed = true;
                note.SetActive(true);
            }
        }  

    }
}
