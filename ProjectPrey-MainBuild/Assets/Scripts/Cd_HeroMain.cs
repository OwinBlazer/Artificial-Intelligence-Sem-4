using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_HeroMain : MonoBehaviour {
    public Cd_MainGame evSys;
    bool skill1 = false;
    public float skill1Duration = 0.5f;
    private float skill1CDCountdown = 0;
    public float skill1CD = 3f;
    private float countDown = 0;
    public GameObject hero;
    public GameObject pointer;
    // Use this for initialization
    void Start()
    {
        hero = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //controls skill1 Cooldown
        if (skill1CDCountdown <= skill1CD)
        {
            skill1CDCountdown += Time.deltaTime;
        }
        //Controls skill1 duration
        if (skill1)
        {
            countDown += Time.deltaTime;
            if (countDown >= skill1Duration)
            {
                skill1 = false;
                countDown = 0;
                hero.GetComponent<Cd_Hero_Movement>().speed = 1;
                hero.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        if (Input.GetButton("Point"))
        {
            if (!skill1)
            {
                hero.SendMessage("moveHero", Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)));
                pointer.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
                pointer.SetActive(true);
            }
        }
        //triggers skill1
        if (Input.GetButtonDown("Skill1"))
        {
            if (!skill1 && skill1CDCountdown >= skill1CD)
            {
                countDown = 0f;
                hero.GetComponent<Cd_Hero_Movement>().speed = 3;
                hero.SendMessage("moveHero", Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)));
                pointer.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
                pointer.SetActive(true);
                skill1 = true;
                skill1CDCountdown = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject prey = collision.gameObject;
        if (prey.tag == "Prey")
        {
            GameObject.Destroy(prey.GetComponent<Cd_PreyBetas>().All);
            evSys.score += 10;
            evSys.enemyCount--;
        }
    }

}
