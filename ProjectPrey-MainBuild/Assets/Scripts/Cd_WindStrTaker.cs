using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cd_WindStrTaker : MonoBehaviour {
    public Cd_WindDirection wind;
    private Text windStrText;
    private void Start()
    {
        windStrText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
        windStrText.text = wind.windStr.ToString("#.##");
	}
}
