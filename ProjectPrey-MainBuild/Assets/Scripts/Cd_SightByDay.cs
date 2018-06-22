using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_SightByDay : MonoBehaviour {
    public Cd_DayCycle timeCycle;

    private void Start()
    {
        timeCycle = GameObject.Find("GameEventSystem").GetComponent<Cd_DayCycle>();
    }
    // Update is called once per frame
    void Update () {
        if (timeCycle.GameTime > 90 && timeCycle.GameTime < 270)
        {
            transform.localScale = new Vector3(getSizeFromTime(timeCycle.GameTime), getSizeFromTime(timeCycle.GameTime), 1);
        }
	}
    private float getSizeFromTime(float time)
    {
        if(time>90 && time < 180)
        {
            return (1 / 3) + (2 / 3) * (180 - time) / 90;
        }
        else if(time>=180 && time<270)
        {
            return (1 / 3) + (2 / 3) * (time - 180) / 90;
        }
        else
        {
            return 1;
        }
    }
}
