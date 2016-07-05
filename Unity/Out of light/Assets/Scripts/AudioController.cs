using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
	public enum AudioChannel {Master, SFX, Music}; 

	float masterVolumePercent = 1F;
	float sfxVolumePercent = 1F;
	float musicVolumePercent = 1F;

	AudioSource sfx2DSource;
	AudioSource[] musicSources;
	int activeMusicIndex;

	public static AudioController instance;

	SoundLibrary library;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);

		library = GetComponent<SoundLibrary>();

		musicSources = new AudioSource[2];

		for (int i = 0; i < 2; i ++)
		{
			GameObject newAudioSource = new GameObject("Audio " + (i + 1));
			newAudioSource.transform.parent = transform;
			musicSources[i] = newAudioSource.AddComponent<AudioSource>();
		}

		GameObject sfxAudioSource = new GameObject("SFX Audio Source");
		sfxAudioSource.transform.parent = transform;
		sfx2DSource = sfxAudioSource.AddComponent<AudioSource>();
		
		masterVolumePercent = PlayerPrefs.GetFloat("Master volume", masterVolumePercent);
		musicVolumePercent = PlayerPrefs.GetFloat("Music volume", musicVolumePercent);
		sfxVolumePercent = PlayerPrefs.GetFloat("SFX volume", sfxVolumePercent);
	}

	public void SetVolume(float v, AudioChannel channel)
	{
		switch (channel)
		{
			case AudioChannel.Master:
				masterVolumePercent = v;
				break;
			case AudioChannel.SFX:
				sfxVolumePercent = v;
				break;
			case AudioChannel.Music:
				musicVolumePercent = v;
				break;
		}

		musicSources[0].volume = musicVolumePercent * masterVolumePercent;
		musicSources[1].volume = musicVolumePercent * masterVolumePercent;

		PlayerPrefs.SetFloat("Master volume", masterVolumePercent);
		PlayerPrefs.SetFloat("Music volume", musicVolumePercent);
		PlayerPrefs.SetFloat("SFX volume", sfxVolumePercent);
	}

	public void PlayMusic(AudioClip clip, float fadeDuration = 1F)
	{
		activeMusicIndex = 1 - activeMusicIndex;
		musicSources[activeMusicIndex].clip = clip;
		musicSources[activeMusicIndex].Play();

		StartCoroutine(MusicCrossFade(fadeDuration));
	}

	public void PlaySound(AudioClip clip, Vector3 pos)
	{
		if (clip != null)
			AudioSource.PlayClipAtPoint(clip, pos, sfxVolumePercent * masterVolumePercent);
	}

	public void PlaySound(string soundName, Vector3 pos)
	{
		PlaySound(library.GetSoundFromName(soundName), pos);
	}

	public void PlaySound2D(string soundName)
	{
		sfx2DSource.PlayOneShot(library.GetSoundFromName(soundName), sfxVolumePercent * masterVolumePercent);
	}

	IEnumerator MusicCrossFade(float duration)
	{
		float percent = 0F;

		while (percent < 1)
		{
			percent += Time.deltaTime * 1 / duration;
			musicSources[activeMusicIndex].volume = Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
			musicSources[1 - activeMusicIndex].volume = Mathf.Lerp(musicVolumePercent * masterVolumePercent, 0, percent);
			yield return null;
		}
	}
}