using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
	[SerializeField]
	private AudioSource audio;

	[SerializeField]
	private AudioClip[] sounds;

	private void Reset()
	{
		audio = GetComponent<AudioSource>();
	}

	public void Play()
	{
		if (sounds.Length == 0)
		{
			return;
		}

		audio.clip = sounds[Random.Range(0, sounds.Length)];
		audio.Play();
	}
}
