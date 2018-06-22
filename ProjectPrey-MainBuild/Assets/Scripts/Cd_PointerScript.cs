using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PointerScript : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="Player"){
			this.gameObject.SetActive (false);
		}
	}

}
