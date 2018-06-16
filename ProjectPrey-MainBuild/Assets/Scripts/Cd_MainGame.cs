using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cd_MainGame : MonoBehaviour {
    public float score = 0;
    public Text scoregameplay;
    public Text highscoregameplay;
    public Text highscoremainmenu;
    public Text scoreresult;
    public int enemyCount = 0;
    private void Start()
    {
        highscoregameplay.text=PlayerPrefs.GetFloat("HighScore",0).ToString();
    }
    private void Update()
    {
        
        if (enemyCount <= 0)
        {
            Debug.Log("Game End");
        }
        
        scoregameplay.text=score.ToString();
        
        if(score>PlayerPrefs.GetFloat("HighScore",0)) 
        {
            PlayerPrefs.SetFloat("HighScore",score);
            highscoregameplay.text=score.ToString();
        }   
    }
}
