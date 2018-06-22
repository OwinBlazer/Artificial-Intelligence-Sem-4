using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_RotatorByDirection : MonoBehaviour {
    public Cd_PreyBetas prey;
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, new Vector2(prey.direction.x, prey.direction.y)));
    }
}
