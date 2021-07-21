using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    [SerializeField] private float speed;
    public static float powerupSpeed=0;
    public GameObject PowerupHealth;
    public GameObject PowerupShotspeed;
    public GameObject PowerupEnemyslow;
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        bullet.position += Vector3.up * speed + new Vector3(0, powerupSpeed, 0);

        if (bullet.position.y >= 10)        //per ottimizzare
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (Random.value > 0.95f)               //5% prob
            {
                float val = Random.value;
                if (val < 0.33f)
                    Instantiate(PowerupHealth, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                else if (val > 0.33f && val < 0.66f)
                    Instantiate(PowerupShotspeed, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                else if (val > 0.66f)
                    Instantiate(PowerupEnemyslow, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerScore.score += 10;

        }
    }
    void Update()
    {
        
    }
}
