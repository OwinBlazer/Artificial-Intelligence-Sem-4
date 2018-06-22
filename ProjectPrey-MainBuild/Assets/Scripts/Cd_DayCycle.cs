using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cd_DayCycle : MonoBehaviour {
    public float GameTime=0;
    public GameObject dawnFilter;
    private float dawnOriAlpha;
    public GameObject nightFilter;
    private float nightOriAlpha;
    // Use this for initialization
    void Start () {
        dawnOriAlpha = dawnFilter.GetComponent<Image>().color.a;
        nightOriAlpha = nightFilter.GetComponent<Image>().color.a;
        dawnFilter.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        nightFilter.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
	// Update is called once per frame
	void Update () {
        if (GameTime<360)
        {
            GameTime += Time.deltaTime;
        }
        else
        {
            GameTime = 0;
        }
        if (GameTime % 360 >45 && GameTime %360 <= 90)
        {
            //approaching dusk/dawn
            dawnFilter.GetComponent<Image>().color = new Color(1,1,1,(GameTime-45)/45*dawnOriAlpha);
        }else if (GameTime % 360 > 90 && GameTime % 360 <= 135)
        {
            //exiting dusk/dawn
            dawnFilter.GetComponent<Image>().color = new Color(1, 1, 1, (135 - GameTime) / 45 * dawnOriAlpha);
        }
        if (GameTime % 360 > 90 && GameTime % 360 < 180)
        {
            nightFilter.GetComponent<Image>().color = new Color(1, 1, 1, (GameTime - 90) / 90 * nightOriAlpha);
        }
        else if (GameTime % 360 > 180 && GameTime % 360 < 270)
        {
            nightFilter.GetComponent<Image>().color = new Color(1, 1, 1, (270 - GameTime) / 90 * nightOriAlpha);
        }
    }
}
