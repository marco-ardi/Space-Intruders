using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public AudioSource MyAudioSource;
    float musicVolume;

    private static AudioManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
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
