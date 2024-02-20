using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
	public Slider effects;
	public Slider music;
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
    //public Sounds sounds;
    public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
    private void Start() {
        if (PlayerPrefs.GetInt("Checks") == 0) {
			PlayerPrefs.SetFloat("EffectsVolume",1);
			PlayerPrefs.SetFloat("MusicVolume", 1);
			PlayerPrefs.SetInt("Checks", 1);
			//PlayerPrefs.SetInt("Coins", 100000);
		} else {
		GetEffectVolume();
		GetMusicVolume();
        }
	}
    #region PlayAudio
    // Play a single clip through the sound effects source.
    public void PlayEffect(AudioClip clip) {
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}
	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip) {
		MusicSource.clip = clip;
		MusicSource.Play();
	}
	// Play a random clip from an array, and randomize the pitch slightly.
	public void RandomSoundEffect(params AudioClip[] clips) {
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}
	#endregion PlayAudio

	#region SetVolume

	public void SetEffectVolume() {
		PlayerPrefs.SetFloat("EffectsVolume", effects.value);
		EffectsSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectsVolume");
	}
	public void GetEffectVolume() {
		EffectsSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectsVolume");
	}
	public void SetMusicVolume() {
		PlayerPrefs.SetFloat("MusicVolume", music.value);
		MusicSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}
	public void GetMusicVolume() {
	//	Debug.Log(MusicSource.GetComponent<AudioSource>().volume+"" + PlayerPrefs.GetFloat("MusicVolume"));
		MusicSource.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}
	#endregion SetVolume
	
	//#region BasicFunctions
	//public void PlayButtonClickEffect() {
	//	PlayEffect(sounds.buttonClick);
	//}
	//public void PlayBG() {
	//	PlayMusic(sounds.bg);
	//}
	//public void PlayBoosterEffect() {
	//	PlayEffect(sounds.powerUp);
	//}
	//public void PlayDaimondEffect() {
	//	PlayEffect(sounds.Daimond);
	//}
	//public void PlayLevelCompleteEffect() {
	//	PlayEffect(sounds.levelComplete);
	//}
	//public void PlayLevelFailEffect() {
	//	PlayEffect(sounds.levelFail);
	//}
	//public void PlayLoadingEffect() {
	//	PlayEffect(sounds.loading);
	//}



 //   #endregion BaseFunctions

}