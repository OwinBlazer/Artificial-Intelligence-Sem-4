using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd_MainGame : MonoBehaviour {
    public float score = 0;
    public int enemyCount = 0;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (enemyCount <= 0)
        {
            Debug.Log("Game End");
        }
            
    }
}
