using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isDead=false;
    public Text gameOver;
    public Text ShowScoreboard;
    public Text restartText;
    public Text AddYourName;
    public GameObject inputField;
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
        ShowScoreboard.enabled = false;
        restartText.enabled = false;
        AddYourName.enabled = false;
        inputField.SetActive(false);
    }


    void Update()
    {
        if (isDead)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            ShowScoreboard.enabled = true;
            restartText.enabled = true;
            AddYourName.enabled = true;
            inputField.SetActive(true);
            //pulisce la scena quando il gioco finisce
            Destroy(GameObject.FindWithTag("Player"));
            Destroy(GameObject.FindWithTag("Enemy"));
            Destroy(GameObject.FindWithTag("Bullet"));
            Destroy(GameObject.FindWithTag("EnemyBullet"));
        }
    }
}
