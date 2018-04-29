using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreyBorder : MonoBehaviour {
    private int wallCount = 0;
    private bool isTriggered = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool getTrigger()
    {
        return isTriggered;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            wallCount++;
            if (wallCount > 0)
            {
                isTriggered = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallCount--;
            if (wallCount < 1)
            {
                isTriggered = false;
            }
        }
    }
}
