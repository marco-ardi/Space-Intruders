using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private static Restart _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

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
