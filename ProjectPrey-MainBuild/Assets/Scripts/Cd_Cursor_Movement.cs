using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_Cursor_Movement : MonoBehaviour {
	public GameObject targetCoord;
	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,10.0f));
	}
}
