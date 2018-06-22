using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cd_ResultScore : MonoBehaviour
{
    public Text highscoremainmenu;
    void Start()
    {
        highscoremainmenu = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highscoremainmenu.text = PlayerPrefs.GetFloat("LastScore", 0).ToString();
    }
}
