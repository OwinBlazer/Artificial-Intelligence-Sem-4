using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreySearch : MonoBehaviour {
    public Cd_FieldGeneration target;
    public Cd_PreyBetas prey;
    private Cd_FieldGeneration temp;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Field")
        {
            temp = collision.GetComponent<Cd_FieldGeneration>();
            if (target)
            {
                if (temp.getGrowth() > target.getGrowth()+30 && target.getGrowth() < 50)
                {
                    target = temp;
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                target = temp;
            }
        }
    }
    public void searchFood()
    {
        if (target)
        {
            prey.newDir = target.gameObject.transform.position - transform.position;
            prey.newDir.Normalize();
            prey.direction += prey.newDir;
            prey.direction.Normalize();
            prey.rb.velocity = new Vector2(prey.direction.x, prey.direction.y) * prey.speed * Time.deltaTime;
        }
        else
        {
            transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
    }
}
