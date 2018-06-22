using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_Credits : MonoBehaviour {
    public float speed=20;
    private float scrollLimit;
    private void Start()
    {
        scrollLimit = transform.localPosition.y;
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.up * Time.deltaTime*speed);
        if (transform.localPosition.y>=-1*scrollLimit)
        {
            transform.localPosition = new Vector3(0, scrollLimit, 0);
        }
    }
}
