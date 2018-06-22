using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_WindDirection : MonoBehaviour {
    public float windDir = 0;
    public float windStr = 0;
    public float timer = 0;
    public Transform windArrow;
	// Use this for initialization
	void Start () {
        randoAll();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            randoAll();
        }
	}
    void randoTimer()
    {
        timer = Random.Range(15, 30);
    }
    void randoWindStr()
    {
        windStr = Random.Range(0f, 3f);
    }
    void randoWindDir()
    {
        windDir = Random.Range(0, 360);
        windArrow.rotation = Quaternion.Euler(0,0,windDir);
    }
    void randoAll()
    {
        randoWindDir();
        randoWindStr();
        randoTimer();
    }
}
