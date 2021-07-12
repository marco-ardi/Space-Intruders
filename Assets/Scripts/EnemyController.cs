using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    [SerializeField] private float speed;
    [SerializeField] private GameObject shot;
    [SerializeField] private Text winText;
    [SerializeField] private float fireRate=0.9f;
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;
        foreach(Transform enemy in enemyHolder)
        {
            if(enemy.position.x <= -8.5 || enemy.position.x >= 10)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if(Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            if(enemy.position.y <= -4)
            {
                GameOver.isDead = true;
                Time.timeScale = 0;
            }

            if (enemyHolder.childCount == 1)
            {
                CancelInvoke();
                InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
            }
            if (enemyHolder.childCount == 0)
            {
                winText.enabled = true;
            }
        }
    }
}
