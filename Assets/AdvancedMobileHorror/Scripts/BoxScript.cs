using UnityEngine;

namespace AdvancedHorrorFPS
{
    [RequireComponent(typeof(Rigidbody))]
    public class BoxScript : MonoBehaviour
    {
        public bool isHolding = false;
        //public float liftAmount = 0.2f;
        Rigidbody rigidbody;
        public Vector3 offset; // TEST

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        public void Interact()
        {
            if (!isHolding && !HeroPlayerScript.Instance.isHoldingBox)
            {
                isHolding = true;
                HeroPlayerScript.Instance.isHoldingBox = true;
                rigidbody.isKinematic = true;
                rigidbody.useGravity = false;
                transform.parent = TouchpadFPSLook.Instance.transform;
                //transform.localPosition = transform.localPosition + transform.up * liftAmount;
                transform.localPosition = HeroPlayerScript.Instance.HoldingItemPoint.localPosition + offset; // Added
                //transform.position = HeroPlayerScript.Instance.HoldingItemPoint.transform.position; // Added
                AudioManager.Instance.Play_Item_Grab();
            }
            else if(isHolding && HeroPlayerScript.Instance.isHoldingBox)
            {
                isHolding = false;
                HeroPlayerScript.Instance.isHoldingBox = false;
                rigidbody.isKinematic = false;
                rigidbody.useGravity = true;
                transform.parent = null;
                AudioManager.Instance.Play_Item_Grab();
            }
        }
    }
}
