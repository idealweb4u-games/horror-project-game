using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class ItemScript : MonoBehaviour
    {
        public ItemType itemType;
        public string Name = "";
        public GameObject Lock;
        public bool isOpened = false;
        public bool playerInRange = false;

        public void Interact()
        {
            if (itemType == ItemType.Flashlight)
            {
                AudioManager.Instance.Play_Item_Grab();
                HeroPlayerScript.Instance.FlashLight.enabled = true;
                FlashLightScript.Instance.Grabbed();
                Destroy(gameObject);
            }
            else if (itemType == ItemType.Door)
            {
                GetComponent<DoorScript>().TryToOpen();
            }
            else if (itemType == ItemType.Key)
            {
                AudioManager.Instance.Play_Item_Grab();
                GetComponent<KeyScript>().isGrabbed = true;
                HeroPlayerScript.Instance.Grab_Key(GetComponent<KeyScript>().KeyID);
                Destroy(gameObject);
            }
            else if (itemType == ItemType.Note && !GetComponent<NoteScript>().isReading)
            {
                GetComponent<NoteScript>().Read();
            }
            else if (itemType == ItemType.Note && GetComponent<NoteScript>().isReading)
            {
                GameCanvas.Instance.Hide_Note();
            }
            else if(itemType == ItemType.Box)
            {
                GetComponent<BoxScript>().Interact();
            }
            else if (itemType == ItemType.LadderPuttingArea)
            {
                if (HeroPlayerScript.Instance.Carrying_Ladder != null && !HeroPlayerScript.Instance.Carrying_Ladder.GetComponent<LadderScript>().isPut)
                {
                    GameCanvas.Instance.Drop_GrabbedLadder(transform);
                }
            }
            else if (itemType == ItemType.Cabinet)
            {
                GetComponent<CabinetScript>().Open();
            }
            else if (itemType == ItemType.Drawer)
            {
                GetComponent<DrawerScript>().Interact();
            }
            else if (itemType == ItemType.MedKit)
            {
                if(HeroPlayerScript.Instance.Health < 100)
                {
                    HeroPlayerScript.Instance.Get_Health();
                    AudioManager.Instance.Play_Item_Grab();
                    Destroy(gameObject);
                }
            }
            else if (itemType == ItemType.WoodToBreak)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 1);
                GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90)));
                AudioManager.Instance.Play_WoodBreakable();
                BlinkEffect effect = GetComponent<BlinkEffect>();
                effect.Disable();
                GetComponent<BoxCollider>().enabled = false;
                Destroy(gameObject, 2);
            }
            else if (itemType == ItemType.Ladder && !GetComponent<LadderScript>().isPut)
            {
                HeroPlayerScript.Instance.Carrying_Ladder = this.gameObject;
                SphereCollider[] colliders = GetComponents<SphereCollider>();
                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].enabled = false;
                }
                GetComponent<BoxCollider>().enabled = false;
                BlinkEffect[] blinks = this.gameObject.GetComponentsInChildren<BlinkEffect>();
                for (int i = 0; i < blinks.Length; i++)
                {
                    blinks[i].Disable();
                }
                AudioManager.Instance.Play_Item_Grab();
                transform.parent = HeroPlayerScript.Instance.LadderPointInCamera.transform.parent;
                transform.position = HeroPlayerScript.Instance.LadderPointInCamera.transform.position;
                transform.eulerAngles = HeroPlayerScript.Instance.LadderPointInCamera.transform.eulerAngles;
                transform.localScale = HeroPlayerScript.Instance.LadderPointInCamera.transform.localScale;

            }
            else if (itemType == ItemType.Chest && !GetComponent<ChestScript>().isOpened)
            {
                GetComponent<SphereCollider>().enabled = false;
                BlinkEffect[] blinks = gameObject.GetComponentsInChildren<BlinkEffect>();
                for (int i = 0; i < blinks.Length; i++)
                {
                    blinks[i].Disable();
                }
                Lock.SetActive(true);
            }
        }

        

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Lock != null && Lock.activeSelf)
                {
                    Lock.SetActive(false);
                }
                if (AdvancedGameManager.Instance.controllerType == ControllerType.PcAndConsole)
                {
                    playerInRange = false;
                    GameCanvas.Instance.Hide_Warning();
                }
            }
        }

        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                if(playerInRange)
                {
                    Interact();
                }
                else if(itemType == ItemType.Box && GetComponent<BoxScript>().isHolding)
                {
                    Interact();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(AdvancedGameManager.Instance.controllerType == ControllerType.PcAndConsole)
            {
                if(other.CompareTag("Player"))
                {
                    playerInRange = true;
                    if(itemType == ItemType.Box && GetComponent<BoxScript>().isHolding)
                    {

                    }
                    else
                    {
                        GameCanvas.Instance.Show_Warning("Press E to Interact");
                    }
                }
            }
        }
    }

    public enum ItemType
    {
        Door,
        Flashlight,
        Key,
        Note,
        Cabinet,
        Ladder,
        WoodToBreak,
        LadderPuttingArea,
        Chest,
        None,
        Drawer,
        Box,
        MedKit
    }
}