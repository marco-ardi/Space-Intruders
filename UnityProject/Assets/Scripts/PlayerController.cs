using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float max;
    [SerializeField] private float min;
    [SerializeField] private GameObject Shot;
    [SerializeField] private Transform shotSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] private float nextFire;
    [SerializeField] private AudioSource myAudio;


    void Start()
    {
        player = GetComponent<Transform>();
        myAudio = GetComponent<AudioSource>();
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
            myAudio.PlayOneShot(myAudio.clip);
            nextFire = Time.time + fireRate;
            Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);  
        }

        if (PlayerHealth.health <= 0)
        {
            GameOver.isDead = true;
        }
    }

    //metodi per delegate e event, se la vita scende a 20, il player si colora di rosso
    void OnEnable()
    {
        EventManager.Happened += TurnColor;
    }

    void OnDisable()
    {
        EventManager.Happened -= TurnColor;
    }

    void TurnColor()
    {
        Color col = new Color(255, 0, 0);
        GetComponent<Renderer>().material.color = col;
        player.GetChild(0).GetComponent<Renderer>().material.color = col;
    }
}
