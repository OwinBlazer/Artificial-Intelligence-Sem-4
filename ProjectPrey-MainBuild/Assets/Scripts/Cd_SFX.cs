using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_SFX : MonoBehaviour
{

    public static Cd_SFX instance;
    public AudioSource source;
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
        source.clip = clip;
        source.pitch = Random.Range(0.7f,1.3f);
        source.Play();
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
