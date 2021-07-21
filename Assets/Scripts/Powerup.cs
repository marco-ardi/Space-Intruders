using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IPowerup
{
    public GameObject effetto;
    public float duration = 5;
    public AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAudio.PlayOneShot(myAudio.clip);
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(effetto, transform.position, transform.rotation);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag("Effect"));
        
        //in base al powerup, inizia l'effetto
        if (gameObject.tag == "PowerupHealth")
        {
            PlayerHealth.health += 20;
        }
        else if (gameObject.tag == "PowerupEnemyslow")
        {
            EnemyController.powerupSlow = -0.1f;
        }
        else if (gameObject.tag == "PowerupShotspeed")
        {
            BulletController.powerupSpeed = 0.1f;
        }

        yield return new WaitForSeconds(duration);
        //dopo duration secondi, ripristino le impostazioni e distruggo
        if (gameObject.tag == "PowerupEnemyslow")
        {
            EnemyController.powerupSlow = 0;
        }
        else if (gameObject.tag == "PowerupShotspeed")
        {
            BulletController.powerupSpeed = 0;
        }

        Destroy(gameObject);
    }
}
