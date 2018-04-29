using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreyDetect : MonoBehaviour {
    public GameObject PreyBeta;
	// Use this for initialization

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PreyBeta.GetComponent<Cd_PreyBetas>().player = collision.gameObject;
            if (this.gameObject.name == "Prey-Sight")
            {
                PreyBeta.GetComponent<Cd_PreyBetas>().setDetectSight(true);
            }
            if (this.gameObject.name == "Prey-Smell")
            {
                PreyBeta.GetComponent<Cd_PreyBetas>().setDetectSmell(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PreyBeta.GetComponent<Cd_PreyBetas>().player = collision.gameObject;
            if (this.gameObject.name == "Prey-Sight")
            {
                PreyBeta.GetComponent<Cd_PreyBetas>().setDetectSight(false);
            }
            if (this.gameObject.name == "Prey-Smell")
            {
                PreyBeta.GetComponent<Cd_PreyBetas>().setDetectSmell(false);
            }
        }
    }
}
