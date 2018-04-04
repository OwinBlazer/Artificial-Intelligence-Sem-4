using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreyBetas : MonoBehaviour {
    public GameObject mainBody;
    public float speed=1;
    public float hunger = 50;
    public float hungerDepletionRate=1;
    public float age = 0;
    bool detectsPlayer = false;
    public Rigidbody2D rb;
    public Vector3 direction;
    public Vector3 newDir;
    public int DetectStateID=0;
    //0 = Player is undetected
    //1 = Player is detected
    public int HungerStateID = 0;
    //0 = hunger>50
    //1 = hunger<50
    //2 = hunger<30
    public int MateStateID = 0;
    //0 = not horny
    //1 = horny
    private float duration = 0;
    private float timer = 0;
    public Cd_FieldGeneration currField;
    public Cd_PreySearch searchField;
    public Patrol wanderCode;
	// Use this for initialization
	void Start () {
        rb=mainBody.GetComponent<Rigidbody2D>();
	}
    private void Update()
    {
        switch (DetectStateID)
        {
            case 0:
                switch (HungerStateID)
                {
                    case 0:
                        switch (MateStateID)
                        {
                            case 0://checkAgeToMate();
                                wander();
                                break;
                            case 1://searchMate();
                                break;
                        }
                        break;
                    case 1:
                        searchFood();
                        break;
                    case 2://is handled in OnTriggerEnter2D down below
                        break;
                }
                break;
            case 1:
                //runAway();
                break;
        }
        hunger -= Time.deltaTime * hungerDepletionRate;
        if (hunger < 30)
        {
            HungerStateID = 2;
        }
        else if(hunger < 50)
        {
            HungerStateID = 1;
        }
        else
        {
            HungerStateID = 0;
        }
        //ageCheck here
        //hornyCheck here
        //detect check here?
    }
    
    private void wander()
    {
        wanderCode.wander();
        /*
        if (timer >= duration)
        {
            timer = 0;
            duration = Random.Range(1, 2);
            newDir = new Vector2(Random.Range(-10,10), Random.Range(-10, 10));
            newDir.Normalize();
            direction += newDir;
            direction.Normalize();
        }
        else
        {
            timer += Time.deltaTime;
        }
        rb.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;
        */
    }
    public bool getDetects()
    {
        return detectsPlayer;
    }
    public void setDetect(bool x)
    {
        detectsPlayer = x;
    }

    //eat grass
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            currField = collision.GetComponent<Cd_FieldGeneration>();
            if (HungerStateID==2&&searchField.target.getGrowth()>30&&currField==searchField.target)
            {
                currField.eatTile(30);
                hunger += 50;
                Debug.Log("FieldID is " + currField.gameObject.name);
                if (searchField.target.getGrowth() < 30)
                {
                    searchField.target = null;
                }
            }
        }
    }

    //activate food search mode
    private void searchFood()
    {
        searchField.searchFood();
    }
}
