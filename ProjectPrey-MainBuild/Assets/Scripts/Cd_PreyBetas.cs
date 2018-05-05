using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreyBetas : MonoBehaviour {
    public GameObject mainBody;
    public GameObject player;
    public float speed=1;
    public float hunger = 50;
    public float hungerDepletionRate=1;
    public float age = 0;
    bool detectSmell = false;
    bool detectSight = false;
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
    public float timer = 0;
    public float runTimer = 0;
    public Cd_FieldGeneration currField;
    public Cd_PreySearch searchField;
    public Patrol wanderCode;
    public GameObject[] preyBorderList= new GameObject[4];
    //index legend:
    //0: top
    //1: left
    //2: bottom
    //3: right

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
                runAway();
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
        if (detectSight|| detectSmell){
            DetectStateID = 1;
            timer = 3f;
            //sets how long a prey stays alert
        }
        else if(timer>0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                runTimer = 0;
                DetectStateID = 0;
            }
        }
    }//Update End

    //run away script
    private void runAway()
    {
        bool anyWall = false;
        int totalWalls = 0;
        //check which wall borders are activated
        for(int i = 0; i < 4; i++)
        {
            if (preyBorderList[i].GetComponent<Cd_PreyBorder>().getTrigger())
            {
                anyWall = true;
                totalWalls++;
            }
        }

        
            if (anyWall)
            {
                //lari bila wall ter-detect
                Vector2 dirToPlayer = player.transform.position - transform.position;
                dirToPlayer.Normalize();
                if (preyBorderList[0].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    //top
                    if (dirToPlayer.x < 0)
                    {
                        newDir = rotateVect2(dirToPlayer, -90);
                    }
                    else
                    {
                        newDir = rotateVect2(dirToPlayer, 90);
                    }
                }
                if (preyBorderList[1].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    if (dirToPlayer.y < 0)
                    {
                        newDir = rotateVect2(dirToPlayer, -90);
                    }
                    else
                    {
                        newDir = rotateVect2(dirToPlayer, 90);
                    }

                }
                if (preyBorderList[2].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    //bottom
                    if (dirToPlayer.x > 0)
                    {
                        newDir = rotateVect2(dirToPlayer, -90);
                    }
                    else
                    {
                        newDir = rotateVect2(dirToPlayer, 90);
                    }
                }
                if (preyBorderList[3].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    if (dirToPlayer.y > 0)
                    {
                        newDir = rotateVect2(dirToPlayer, -90);
                    }
                    else
                    {
                        newDir = rotateVect2(dirToPlayer, 90);
                    }

                }
                //2 borders detected:
                //top left
                if (preyBorderList[0].GetComponent<Cd_PreyBorder>().getTrigger() && preyBorderList[1].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    if (Mathf.Abs(dirToPlayer.y) > Mathf.Abs(dirToPlayer.x))
                    {
                        //|y| > |x|
                        newDir = rotateVect2(dirToPlayer, -45);
                    }
                    else
                    {
                        //|x|>=|y|
                        newDir = rotateVect2(dirToPlayer, 45);
                    }
                }
                //bottom left
                if (preyBorderList[1].GetComponent<Cd_PreyBorder>().getTrigger() && preyBorderList[2].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    if (Mathf.Abs(dirToPlayer.y) > Mathf.Abs(dirToPlayer.x))
                    {
                        //|y| > |x|
                        newDir = rotateVect2(dirToPlayer, 45);
                    }
                    else
                    {
                        //|x|>=|y|
                        newDir = rotateVect2(dirToPlayer, -45);
                    }
                }
                //top right
                if (preyBorderList[3].GetComponent<Cd_PreyBorder>().getTrigger() && preyBorderList[0].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    if (Mathf.Abs(dirToPlayer.y) > Mathf.Abs(dirToPlayer.x))
                    {
                        //|y| > |x|
                        newDir = rotateVect2(dirToPlayer, 45);
                    }
                    else
                    {
                        //|x|>=|y|
                        newDir = rotateVect2(dirToPlayer, -45);
                    }
                }
                //bottom right
                if (preyBorderList[2].GetComponent<Cd_PreyBorder>().getTrigger() && preyBorderList[3].GetComponent<Cd_PreyBorder>().getTrigger())
                {
                    if (Mathf.Abs(dirToPlayer.y) > Mathf.Abs(dirToPlayer.x))
                    {
                        //|y| > |x|
                        newDir = rotateVect2(dirToPlayer, -45);
                    }
                    else
                    {
                        //|x|>=|y|
                        newDir = rotateVect2(dirToPlayer, 45);
                    }
                }
                //starts run Timer on corner run
                //ORIGINAL VALUE IS 2 TO REPRESENT 2 WALLS (CORNER)<==== DEBUGGING WITH 1
                if (totalWalls >= 1)
                {
                    //how long the prey will corner dash if cornered
                    runTimer = 3f;
                }
                newDir.Normalize();
                direction = newDir;
                direction.Normalize();
                rb.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;
            }
            else
            {
            if (runTimer > 0) { runTimer -= Time.deltaTime; rb.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime; }
            else
            {
                //script untuk lari, wall belum ter-detect
                newDir = transform.position - player.gameObject.transform.position;
                newDir.Normalize();
                direction += newDir;
                direction.Normalize();
                rb.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;
            }
            
        }
        
        
    }
    private void wander()
    {
        wanderCode.wander();
    }
    public void setDetectSight(bool x)
    {
        detectSight = x;
    }
    public void setDetectSmell(bool x)
    {
        detectSmell = x;
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

    //Vector 2 rotator function
    private Vector2 rotateVect2(Vector2 oldDir,float rotDegree)
    {
        Vector2 newDir = new Vector2
            (oldDir.x*Mathf.Cos(Mathf.Deg2Rad*-rotDegree) -
            oldDir.y*Mathf.Sin(Mathf.Deg2Rad * -rotDegree),
            oldDir.y*Mathf.Cos(Mathf.Deg2Rad * -rotDegree) +
            oldDir.x*Mathf.Sin(Mathf.Deg2Rad * -rotDegree));
        return newDir;
    }
}
