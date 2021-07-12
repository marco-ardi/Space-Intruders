using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float max;
    [SerializeField] private float min;
    private float health=100;
    [SerializeField] private GameObject Shot;
    [SerializeField] private Transform shotSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] private float nextFire;


    void Start()
    {
        player = GetComponent<Transform>();   
    }


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x <= min && h < 0)
            h = 0;
        else if (player.position.x > max && h > 0)
            h = 0;

        player.position += Vector3.right * h * speed;
    }
    void Update()
    {
        if(Input.GetKey("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
        }
        //se ricevi un colpo dovresti diminuire la tua salute

        if (health <= 0)
        {
            GameOver.isDead = true;
        }
    }
}
