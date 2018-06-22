using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonClick : MonoBehaviour {

    public void ChangeScene(string level)
    {
        if (level == "Quit")
        {
            Application.Quit();
            Debug.Log("App quit");
        }
        else
        {
            SceneManager.LoadScene(level);
        }
    }
    
}
