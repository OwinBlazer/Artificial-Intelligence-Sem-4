using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_RotatorByWind : MonoBehaviour {
    public Cd_WindDirection wind;
    // Update is called once per frame
    private void Start()
    {
        wind = GameObject.Find("GameEventSystem").GetComponent<Cd_WindDirection>();
    }
    void Update () {
        transform.rotation = Quaternion.Euler(0,0,wind.windDir+180);
        transform.localScale = new Vector3(wind.windStr,wind.windStr,1);
        //transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up,new Vector2 (prey.direction.x, prey.direction.y)));
    }
}
