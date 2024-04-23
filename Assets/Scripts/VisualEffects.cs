using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AdvancedHorrorFPS
{
    public class VisualEffects : MonoBehaviour
    {
        public static VisualEffects Instance;
        public  PostProcessVolume postVolume;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void ChangeBlurEffect(int amount)
        {
            if (amount == 1)
            {
                //postVolume
            }
            if (amount == 2)
            {

            }
            if (amount == 3)
            {

            }
            if (amount == 4)
            {

            }
            else
            {

            }
        }
        
    }
}
