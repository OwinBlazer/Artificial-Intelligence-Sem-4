using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreySpread : MonoBehaviour {
    public Cd_PreyBetas prey;
    private int overlapCount=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlapCount++;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Prey" && prey.MateStateID != 1)
        {
            prey.newDir = transform.position - collision.gameObject.transform.position;
            prey.newDir.Normalize();
            prey.direction += prey.newDir;
            prey.direction.Normalize();
            prey.rb.velocity = new Vector2(prey.direction.x, prey.direction.y) * prey.speed * Time.deltaTime;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        overlapCount--;
        if (overlapCount <= 0)
        {
            prey.rb.velocity = Vector2.zero;
        }
    }
}
