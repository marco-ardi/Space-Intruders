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
            //pulisce la scena quando il gioco finisce
            Destroy(GameObject.FindWithTag("Player"));
            Destroy(GameObject.FindWithTag("Enemy"));
            Destroy(GameObject.FindWithTag("Bullet"));
            Destroy(GameObject.FindWithTag("EnemyBullet"));
        }
    }
}
