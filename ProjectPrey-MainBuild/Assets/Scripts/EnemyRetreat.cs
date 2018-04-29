using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRetreat : MonoBehaviour {

    public float retreatDistance;
    public float speed;
    public Transform player;
    public bool detectedsmell = false;
    public bool detectedsight = false;
	// Use this for initialization

	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (detectedsight||detectedsmell)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            
        }
                
               
		
	}
}
