using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	#region PlayAudio
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