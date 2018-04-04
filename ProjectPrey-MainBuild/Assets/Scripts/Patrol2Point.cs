using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol2Point : MonoBehaviour {

	public float speed;
	private float waitTime;
	public float startWaitTime;

	public Transform moveSpot1;
	public Transform moveSpot2;
	private bool menuju1=true;
	private bool menuju2=false;

	void Start () {
		


	}

	// Update is called once per frame
	void Update () {

		if (menuju1 == true) {	
			transform.position = Vector2.MoveTowards (transform.position, moveSpot1.position, speed * Time.deltaTime);
			if (Vector2.Distance (transform.position, moveSpot1.position) < 0.2f) 
			{
				menuju1 = false;
				menuju2 = true;
				//StartCoroutine (Waittime ());
			}
		}
		if (menuju2== true) {	
			transform.position = Vector2.MoveTowards (transform.position, moveSpot2.position, speed * Time.deltaTime);
			if (Vector2.Distance (transform.position, moveSpot2.position) < 0.2f) 
			{
				menuju1 = true;
				menuju2 = false;
				//StartCoroutine (Waittime ());
			}
		}


}
	IEnumerator Waittime()
	{
		yield return new WaitForSeconds(3);
	}
}
