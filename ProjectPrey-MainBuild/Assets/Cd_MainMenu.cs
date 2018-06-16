using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cd_MainMenu : MonoBehaviour {
    public void LoadSceneOf(string name)
    {
        SceneManager.LoadScene(name);
    }
	
	
}
