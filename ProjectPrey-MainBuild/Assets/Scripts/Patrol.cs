using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject parent;
    public Cd_PreyBetas beta;
    private float waitTime;
    public float startWaitTime;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void wander()
    {
        beta.newDir =  moveSpot.transform.position - parent.transform.position;
        beta.newDir.Normalize();
        beta.direction += beta.newDir;
        beta.direction.Normalize();
        rb.velocity = new Vector2(beta.direction.x, beta.direction.y) * beta.speed * Time.deltaTime;

        //rb.velocity = Vector2.MoveTowards(parent.transform.position, moveSpot.position, beta.speed * Time.deltaTime);
        if (Vector2.Distance(parent.transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {

                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
