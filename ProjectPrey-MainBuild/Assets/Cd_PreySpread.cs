using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreySpread : MonoBehaviour {
    public Cd_PreyBetas prey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Prey")
        {
            prey.newDir = transform.position - collision.gameObject.transform.position;
            prey.newDir.Normalize();
            prey.direction += prey.newDir;
            prey.direction.Normalize();
            prey.rb.velocity += new Vector2(prey.direction.x, prey.direction.y) * prey.speed * Time.deltaTime;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prey.rb.velocity = Vector2.zero;
    }
}
