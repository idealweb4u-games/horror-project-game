using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedHorrorFPS
{
    public class SettingsScript : MonoBehaviour
    {
        public List<string> Difficulties;
        public Slider Slider_Mouse;
        public Dropdown DropDown_Difficulty;
        public Toggle Toggle_SoundFX;

        void Start()
        {
            AddDifficultyOptions();
            GetMouseSlider();
            GetMusicToggle();
        }

        public void GetMouseSlider()
        {
            Slider_Mouse.value = PlayerPrefs.GetFloat("MouseSensivity", 1);
            Slider_Mouse.onValueChanged.AddListener(delegate { ChangeMouse(Slider_Mouse); });
        }

        public void GetMusicToggle()
        {
            Toggle_SoundFX.isOn = (PlayerPrefs.GetInt("Music", 1) == 1 ? true : false);
            Toggle_SoundFX.onValueChanged.AddListener(delegate { ChangeMusic(Toggle_SoundFX); });
        }

        public void ChangeMusic(Toggle toggle)
        {
            PlayerPrefs.SetInt("Music", (toggle.isOn == true ? 1 : 0));
            if (toggle.isOn)
            {
                AudioListener.volume = 1;
            }
            else
            {
                AudioListener.volume = 0;
            }
        }

        public void ChangeMouse(Slider slider)
        {
            PlayerPrefs.SetFloat("MouseSensivity", slider.value);
        }

        public void AddDifficultyOptions()
        {
            // ?lk ?nce dropdown'a datay? doldural?m:
            for (int i = 0; i < Difficulties.Count; i++)
            {
                DropDown_Difficulty.options.Add(new Dropdown.OptionData() { text = Difficulties[i] });
            }

            DropDown_Difficulty.value = PlayerPrefs.GetInt("Difficulty", 1);
            DropDown_Difficulty.RefreshShownValue();


            // De?er De?i?irse Event'ini atal?m.
            DropDown_Difficulty.onValueChanged.AddListener(delegate { SelectDifficulty(DropDown_Difficulty); });
            DropDown_Difficulty.value = PlayerPrefs.GetInt("Difficulty", 0) == -1 ? 0 : PlayerPrefs.GetInt("Difficulty", 1);
        }

        void SelectDifficulty(Dropdown dropdown)
        {
            Debug.Log(dropdown.value);
            PlayerPrefs.SetInt("Difficulty", dropdown.value);
        }
    }
}