using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private Transform enemyHolder;
    [SerializeField] private float speed;
    [SerializeField] private GameObject shot;
    [SerializeField] private float fireRate=0.9f;
    public static float powerupSlow=0;
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        if(speed > 0)
            speed = speed * SettingsMenu.difficultValue + Timer.time * 0.001f + powerupSlow;    //la velocità aumenta progressivamente man mano che il tempo scorre
        else                                                                                    //e viene moltiplicato il fattore difficoltà
            speed = - (Math.Abs(speed * SettingsMenu.difficultValue) + Timer.time * 0.001f + powerupSlow);          //attenzione al segno di speed
        
        enemyHolder.position += Vector3.right * speed;
        
        if (enemyHolder.transform.position.x <= -5.5 || enemyHolder.transform.position.x >= 7)
        {
            speed = -speed;
            //enemyHolder.position += Vector3.down * 1.3f;
            enemyHolder.transform.position += new Vector3(0, -1.3f, 0);
            return;
        }
        
        if (UnityEngine.Random.value > fireRate)               //10% prob
        {
            Instantiate(shot, enemyHolder.transform.position, enemyHolder.transform.rotation);
        }

        if (enemyHolder.transform.position.y <= -4)
        {
            GameOver.isDead = true;
            Time.timeScale = 0;
        }
    }
}
