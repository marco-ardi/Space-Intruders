using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Transform bullet;
    [SerializeField] private float speed;
    void Start()
    {
        bullet = GetComponent<Transform>();   
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -10)
            Destroy(bullet.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {   //diminuisci vita
            PlayerHealth.health -= 20;
            //Destroy(collision.gameObject);
            Destroy(gameObject);
            //GameOver.isDead = true;
        }
        
    }
}
