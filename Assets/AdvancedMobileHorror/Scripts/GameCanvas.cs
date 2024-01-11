using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace AdvancedHorrorFPS
{
    public class GameCanvas : MonoBehaviour
    {
        public static GameCanvas Instance;
        public GameObject Indicator_BlueLight;
        public Image Image_BlueLight;
        public GameObject Panel_WarningPanel;
        public GameObject Button_Flashlight;
        public GameObject Button_Jump;
        public LayerMask layerMaskForInteract;
        public Color BlueLightcolor;
        public GameObject Panel_GameUI;
        public GameObject Panel_Pause;
        public GameObject Panel_Health;
        public GameObject Panel_Settings;
        public GameObject Panel_Note;
        public GameObject Panel_Note_Text;
        public Text Button_Close_Note_Text;
        public GameObject Panel_GameOver;
        public Image Image_Sprite_Blood;
        public GameObject Controller_Joystick;
        public GameObject Controller_Touchpad;
        public Text Text_Health;
        [HideInInspector]
        public bool isFlashBlueNow = false;
        [HideInInspector]
        public GameObject LastClickedArea;
        [HideInInspector]
        public NoteScript CurrentNote;
        private bool isGameOver = false;
        [HideInInspector]
        public bool isPaused = false;

        private void Awake()
        {
            Instance = this;
        }

        public void Click_BacktoMenu()
        {
            SceneManager.LoadScene("Scene_MainMenu");
        }

        public void Show_Blood_Effect()
        {
            Image_Sprite_Blood.gameObject.SetActive(true);
            Image_Sprite_Blood.GetComponent<Animation>().Play("BloodEffect");
            StartCoroutine(HideEffect());
        }

        IEnumerator HideEffect()
        {
            yield return new WaitForSeconds(1);
            Image_Sprite_Blood.gameObject.SetActive(false);
        }


        public void Click_Continue()
        {
            HeroPlayerScript.Instance.ActivatePlayerInputs();
            TouchpadFPSLook.Instance.enabled = true;
            Time.timeScale = 1;
            Panel_Pause.SetActive(false);
            Panel_GameUI.SetActive(true);
        }

        public void Click_Pause()
        {
            HeroPlayerScript.Instance.DeactivatePlayer();
            TouchpadFPSLook.Instance.enabled = false;
            Time.timeScale = 0;
            Panel_Pause.SetActive(true);
            Panel_GameUI.SetActive(false);
        }

        public void UpdateHealth()
        {
            Text_Health.text = HeroPlayerScript.Instance.Health.ToString();
        }

        void Update()
        {
            if (AdvancedGameManager.Instance.controllerType == ControllerType.PcAndConsole)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
                {
                    if(isPaused)
                    {
                        isPaused = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                        Click_Continue();
                    }
                    else
                    {
                        isPaused = true;
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                        Click_Pause();
                    }
                }
            }
            if(AdvancedGameManager.Instance.controllerType == ControllerType.Mobile)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Camera.main != null)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 2.5f, layerMaskForInteract))
                        {
                            if (hit.transform.GetComponent<ItemScript>() != null)
                            {
                                LastClickedArea = hit.transform.gameObject;
                            }
                        }
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    if (Camera.main != null)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 2.5f, layerMaskForInteract))
                        {
                            if (hit.transform.GetComponent<ItemScript>() != null && LastClickedArea == hit.transform.gameObject)
                            {
                                ItemScript item = hit.transform.GetComponent<ItemScript>();
                                item.Interact();
                            }
                        }
                    }
                }
            }
        }

        public void Show_GameOverPanel()
        {
            HeroPlayerScript.Instance.DeactivatePlayer();
            TouchpadFPSLook.Instance.enabled = false;
            isGameOver = true;
            if (AdvancedGameManager.Instance.gameType == GameType.DieWhenYouAreCaught)
            {
                StartCoroutine(WaitAndShowGameOver(3));
            }
            else
            {
                StartCoroutine(WaitAndShowGameOver(1));
            }
        }

        IEnumerator WaitAndShowGameOver(int time)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            yield return new WaitForSeconds(time);
            Time.timeScale = 0;
            Panel_GameUI.SetActive(false);
            Panel_GameOver.SetActive(true);
        }

        public void Click_Settings()
        {
            Panel_Settings.SetActive(true);
            Panel_Pause.SetActive(false);
        }

        public void Click_Close_Settings()
        {
            Panel_Settings.SetActive(false);
            Panel_Pause.SetActive(true);
        }

        public void Click_ShowNote()
        {
            Panel_GameUI.SetActive(false);
            HeroPlayerScript.Instance.DeactivatePlayer();
        }

        public void Click_Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Show_Note(string text)
        {
            Panel_GameUI.SetActive(false);
            HeroPlayerScript.Instance.DeactivatePlayer();
            Panel_Note.SetActive(true);
            Panel_Note_Text.GetComponent<Text>().text = text;
            AudioManager.Instance.Play_Note_Reading();
            if(AdvancedGameManager.Instance.controllerType == ControllerType.PcAndConsole)
            {
                Button_Close_Note_Text.text = "CLOSE (E)";
            }
        }


        public void Hide_Note()
        {
            Panel_GameUI.SetActive(true);
            HeroPlayerScript.Instance.ActivatePlayerInputs();
            if (CurrentNote != null)
            {
                CurrentNote.Unread();
                Panel_Note.SetActive(false);
                Panel_Note_Text.GetComponent<Text>().text = "";
            }
            AudioManager.Instance.Play_Item_Close();
        }


        public void Show_GameUI()
        {
            Panel_GameUI.SetActive(true);
        }

        public void Hide_GameUI()
        {
            Panel_GameUI.SetActive(false);
        }

        public void Show_Warning(String textID)
        {
            Panel_WarningPanel.SetActive(false);
            if (Panel_WarningPanel.activeInHierarchy == false)
            {
                StartCoroutine(ShowWarningPanel(textID));
            }
        }

        IEnumerator ShowWarningPanel(String text)
        {
            Panel_WarningPanel.SetActive(true);
            Panel_WarningPanel.GetComponentInChildren<Text>().text = text;
            yield return new WaitForSeconds(3);
            Panel_WarningPanel.GetComponentInChildren<Text>().text = "";
            Panel_WarningPanel.SetActive(false);
        }

        public void Hide_Warning()
        {
            Panel_WarningPanel.SetActive(false);
        }

        public void Activate_FlashLightButton()
        {
            Button_Flashlight.SetActive(true);
        }

        public void FlashLight_Click()
        {
            FlashLightScript.Instance.FlashLight_Decision(true);
            Button_Flashlight.GetComponent<Image>().color = BlueLightcolor;
            AudioManager.Instance.Play_Flashlight_Open();
        }

        public void FlashLight_BlueEffect_Down()
        {
            if (FlashLightScript.Instance.Light.enabled && !isFlashBlueNow && FlashLightScript.Instance.BlueBattery > 0)
            {
                isFlashBlueNow = true;
                FlashLightScript.Instance.Light.color = Color.blue;
                AudioManager.Instance.Play_Flashlight_Close();
            }
        }

        public void FlashLight_BlueEffect_Up()
        {
            if (FlashLightScript.Instance.Light.enabled && isFlashBlueNow)
            {
                FlashLightScript.Instance.StopAudioBlueLight();
                isFlashBlueNow = false;
                if (EnemySpawnerScript.Instance != null)
                {
                    for (int i = 0; i < EnemySpawnerScript.Instance.Demons.Count; i++)
                    {
                        if (EnemySpawnerScript.Instance.Demons[i] != null)
                        {
                            EnemySpawnerScript.Instance.Demons[i].GetComponent<DemonScript>().FinishedGetDamage();
                        }
                    }
                }
                FlashLightScript.Instance.Light.color = Color.white;
                FlashLightScript.Instance.Light.intensity = 3;
            }
        }

        public void Drop_GrabbedLadder(Transform LadderPutPoint)
        {
            HeroPlayerScript.Instance.Carrying_Ladder.SetActive(true);
            HeroPlayerScript.Instance.Carrying_Ladder.transform.parent = null;
            HeroPlayerScript.Instance.Carrying_Ladder.transform.position = LadderPutPoint.transform.position;
            HeroPlayerScript.Instance.Carrying_Ladder.transform.eulerAngles = LadderPutPoint.transform.eulerAngles;
            HeroPlayerScript.Instance.Carrying_Ladder.transform.localScale = LadderPutPoint.transform.localScale;
            HeroPlayerScript.Instance.Carrying_Ladder.GetComponent<BoxCollider>().enabled = true;
            HeroPlayerScript.Instance.Carrying_Ladder.tag = "Untagged";
            AudioManager.Instance.Play_Item_Grab();
            HeroPlayerScript.Instance.Carrying_Ladder.GetComponent<LadderScript>().isPut = true;
            HeroPlayerScript.Instance.Carrying_Ladder = null;
            Destroy(LadderPutPoint.gameObject);
        }
    }
}