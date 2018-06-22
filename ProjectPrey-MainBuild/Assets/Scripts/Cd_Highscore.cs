using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cd_Highscore : MonoBehaviour {

	public Text highscoremainmenu;
	void Start () {
        highscoremainmenu = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		highscoremainmenu.text=PlayerPrefs.GetFloat("HighScore",0).ToString();
	}
}
