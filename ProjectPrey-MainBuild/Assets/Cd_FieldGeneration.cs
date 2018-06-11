using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_FieldGeneration : MonoBehaviour {
    public float growth=0;
    float timer = 0;
    public float growthSpeed = 1;
    public SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        growth = Random.Range(0, 100);
	}
	
	// Update is called once per frame
	void Update () {
        timer = Time.deltaTime;
        if (growth + timer*growthSpeed< 100)
        {
            growth += timer * growthSpeed;
        }
        else
        {
            growth = 100;
        }
        Color newColor = new Color(1, 1, 1, growth / 100);
        sprite.color = newColor;
	}

    public void eatTile(float eaten)
    {
        growth -= eaten;
    }

    public float getGrowth()
    {
        return growth;
    }
}
