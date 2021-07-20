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
   // [SerializeField] private Text winText;
    [SerializeField] private float fireRate=0.9f;
    void Start()
    {
        //winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }


    void MoveEnemy()
    {
        if(speed > 0)
            speed = speed + Timer.time * 0.001f;    //la velocità aumenta progressivamente man mano che il tempo scorre
        else                                        //attenzione al segno di speed
            speed = - (Math.Abs(speed) + Timer.time * 0.001f);

        enemyHolder.position += Vector3.right * speed;
        foreach(Transform enemy in enemyHolder)
        {
            if(enemy.position.x <= -5.5 || enemy.position.x >= 7)
            {
                speed = -speed;
                //enemyHolder.position += Vector3.down * 1.3f;
                enemyHolder.position += new Vector3(0,-1.3f,0);
                return;
            }

            if(UnityEngine.Random.value > fireRate)     //10% prob
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            if(enemy.position.y <= -4)
            {
                GameOver.isDead = true;
                Time.timeScale = 0;
            }
        }
    }
}
