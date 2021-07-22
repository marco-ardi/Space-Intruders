using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: Singleton<AudioManager>
{
    public AudioSource MyAudioSource;
    float musicVolume;

    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("MVolume");
        MyAudioSource.Play();
    }

    private void Update()
    {
        MyAudioSource.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("MVolume", 1f);
    }
}
