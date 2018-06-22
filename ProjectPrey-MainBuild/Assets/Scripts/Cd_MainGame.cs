using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Cd_MainGame : MonoBehaviour
{
    public AudioClip endRing;
    public AudioClip ambience;
    public float score = 0;
    public Text scoregameplay;
    public Text highscoregameplay;
    public int enemyCount = 0;
    public int gametime;
    public Text timeboard;
    private void Start()
    {
        Time.timeScale = 1;
        highscoregameplay.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        InvokeRepeating("Count", 0.0f, 1.0f);
        Cd_GameMusic.instance.PlayMusic(ambience);
    }

    void Count()
    {
        if (gametime == 0)
        {
            CancelInvoke("Count");
            GameEnd();
        }
        else
        {
            gametime--;
        }
    }

    private void Update()
    {

        if (enemyCount <= 0)
        {
            GameEnd();
        }

        scoregameplay.text = score.ToString();

        timeboard.text = gametime.ToString();
    }
    private void GameEnd()
    {
        if (score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        PlayerPrefs.SetFloat("LastScore", score);
        Time.timeScale = 1;
        Cd_SFX.instance.PlayMusic(endRing);
        Cd_GameMusic.instance.StopMusic();
        SceneManager.LoadScene("Result");
    }
}
