using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore.score = 0;
            GameOver.isDead = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("Scene_0");
        }   
    }
}
