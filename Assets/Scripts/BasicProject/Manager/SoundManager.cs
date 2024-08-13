using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	public AudioClip backgroundClip;
	public AudioClip loadingClip;
	#region PlayAudio

	void Start() // TEST DELTE LATER
	{
		EffectsSource.volume = 0.5f;
		MusicSource.volume = 0.5f;

	}
	public void PlayBackgroundMusic() {
		SoundManager.Instance.AssignMusicClip(backgroundClip);
		SoundManager.Instance.PlayMusic();
	}
	public void PlayEffect() {
		if (EffectsSource.clip != null) {
			EffectsSource.Play();
		}
	}
	public void PlayMusic() {
		if (MusicSource.clip != null) {
			MusicSource.Play();
		}
	}
	public void AssignEffectClip(AudioClip clip) {
		EffectsSource.clip = clip;
	}
	public void AssignMusicClip(AudioClip clip) {
		MusicSource.clip = clip;
	}
	#endregion PlayAudio
}