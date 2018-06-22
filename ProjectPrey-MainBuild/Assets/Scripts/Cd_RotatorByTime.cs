using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_RotatorByTime : MonoBehaviour {
    public Cd_DayCycle cycle;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, cycle.GameTime);
    }
}
