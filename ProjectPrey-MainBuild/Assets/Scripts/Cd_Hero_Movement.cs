using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_Hero_Movement : MonoBehaviour {
	public GameObject sprite;
	public float speed = 1;
	private Vector3 destination = new Vector3(0,0,0);
	public static float minStop = 0.05f;
	private bool walk=false;
	private bool idle=true;
	private float distance = 0;
	//private float debug =0;
	Rigidbody2D rb;
	// Use this for initialization

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveCheck ();
	}

	public void moveHero (Vector3 newCoord){
		Vector3 direction = newCoord - this.transform.position;
		direction.Normalize ();
		destination = newCoord;
		rb.velocity = direction * speed;
		distance = Mathf.Pow (Mathf.Pow(transform.position.x - destination.x,2)+Mathf.Pow(transform.position.y - destination.y,2),0.5f);
		transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Rad2Deg*Mathf.Atan2(direction.y,direction.x)+90));
	}
	private void moveCheck(){
		//track distance, if membesar, stop
		float tempDist = Mathf.Pow (Mathf.Pow(transform.position.x - destination.x,2)+Mathf.Pow(transform.position.y - destination.y,2),0.5f);
		if (distance<tempDist) {
			rb.velocity = Vector2.zero;
			distance = 0;
            walk = false;
            idle = true;
		} else {
			distance = Mathf.Pow (Mathf.Pow(transform.position.x - destination.x,2)+Mathf.Pow(transform.position.y - destination.y,2),0.5f);
		}
	}
}
