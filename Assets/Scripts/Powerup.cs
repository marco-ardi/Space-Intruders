using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour, IPowerup
{
    public GameObject effetto;
    public float duration = 5;
    public AudioSource myAudio;
    public Text PowerHealth;
    public Text PowerShotspeed;
    public Text PowerEnemyslow;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        PowerHealth = GameObject.Find("PowerupHealth").GetComponent<Text>();
        PowerShotspeed = GameObject.Find("PowerupShotspeed").GetComponent<Text>();
        PowerEnemyslow = GameObject.Find("PowerupEnemyslow").GetComponent<Text>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAudio.PlayOneShot(myAudio.clip);
            StartCoroutine(Pickup());
        }
    }

    IEnumerator Pickup()
    {
        Instantiate(effetto, transform.position, transform.rotation);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.FindGameObjectWithTag("Effect"));
        
        //in base al powerup, inizia l'effetto
        if (gameObject.tag == "PowerupHealth")
        {
            PowerHealth.enabled = true;
            PlayerHealth.health += 20;
        }
        else if (gameObject.tag == "PowerupEnemyslow")
        {
            PowerEnemyslow.enabled = true;
            EnemyController.powerupSlow = -0.1f;
        }
        else if (gameObject.tag == "PowerupShotspeed")
        {
            PowerShotspeed.enabled = true;
            BulletController.powerupSpeed = 0.1f;
        }

        yield return new WaitForSeconds(duration);
        //dopo duration secondi, ripristino le impostazioni e distruggo
        if(gameObject.tag== "PowerupHealth")
        {
            PowerHealth.enabled = false;
        }
        if (gameObject.tag == "PowerupEnemyslow")
        {
            PowerEnemyslow.enabled = false;
            EnemyController.powerupSlow = 0;
        }
        else if (gameObject.tag == "PowerupShotspeed")
        {
            PowerShotspeed.enabled = false;
            BulletController.powerupSpeed = 0;
        }

        Destroy(gameObject);
    }
}
