using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_GameMusic : MonoBehaviour {
    public static Cd_GameMusic instance;
    public AudioSource source;
    private AudioClip currentClip;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        currentClip = clip;
        source.clip = clip;
        source.Play();
    }
    public void StopMusic()
    {
        source.Stop();
    }
    public AudioClip CheckMusic()
    {
        return currentClip;
    }
    public void SetVolume(float x)
    {
        source.volume = x;
    }

    public float GetVolume()
    {
        return source.volume;
    }



}
