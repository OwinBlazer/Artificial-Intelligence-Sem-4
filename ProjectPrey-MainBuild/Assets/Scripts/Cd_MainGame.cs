using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_MainGame : MonoBehaviour {

	public GameObject hero;
	public GameObject pointer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Point")){
			hero.SendMessage ("moveHero",Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,10.0f)));
			pointer.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
			pointer.SetActive (true);
		}
	}
}
