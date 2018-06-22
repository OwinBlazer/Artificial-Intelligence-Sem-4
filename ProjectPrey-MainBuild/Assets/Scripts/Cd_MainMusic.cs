using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_MainMusic : MonoBehaviour {
    public AudioClip mainMusic;
	// Use this for initialization
	void Start () {
        if(Cd_GameMusic.instance.CheckMusic()!=mainMusic)
        Cd_GameMusic.instance.PlayMusic(mainMusic);
	}
}
