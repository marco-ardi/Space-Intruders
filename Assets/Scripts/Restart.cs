using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : Singleton<Restart>
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore.score = 0;
            PlayerHealth.health = 100;
            GameOver.isDead = false;
            Time.timeScale = 1;
            Timer.time = 0;
            SceneManager.LoadScene("Scene_0");
        }   
    }
}
