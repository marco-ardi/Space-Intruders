using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isDead=false;
    public Text gameOver;
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }


    void Update()
    {
        if (isDead)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
        }
    }
}
