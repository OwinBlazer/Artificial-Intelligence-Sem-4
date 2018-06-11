using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_PreyMateSearch : MonoBehaviour
{
    public GameObject Self;
    public GameObject nearestMate;
    private Cd_PreyBetas prey;
    private void Start()
    {
        prey = Self.GetComponent<Cd_PreyBetas>();
    }
    private void Update()
    {
        if (!nearestMate)
        {
            transform.localScale = new Vector2(transform.localScale.x + 1, transform.localScale.y + 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!nearestMate)
        {
            if (col.gameObject.tag == "Prey" && col.gameObject != Self)
            {
                nearestMate = col.gameObject;
            }
        }
        else {
            if (col.gameObject.tag == "Prey" && col.gameObject!= Self && col.gameObject.GetComponent<Cd_PreyBetas>().MateStateID==1)
            {
                if(Vector2.Distance(new Vector2(transform.position.x,transform.position.y), new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y))
                    <Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(nearestMate.transform.position.x, nearestMate.transform.position.y)))
                nearestMate = col.gameObject;
            }
        }
    }
    public void searchMate()
    {
        if (nearestMate)
        {
            prey.newDir = nearestMate.gameObject.transform.position - transform.position;
            prey.newDir.Normalize();
            prey.direction += prey.newDir;
            prey.direction.Normalize();
            prey.rb.velocity = new Vector2(prey.direction.x, prey.direction.y) * prey.speed * Time.deltaTime;
        }
        else
        {
            transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            prey.rb.velocity = prey.rb.velocity / 2;
        }
    }
}
