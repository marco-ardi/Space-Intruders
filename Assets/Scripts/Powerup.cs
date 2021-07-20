using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IPowerup
{
    public GameObject effetto;
    public void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Debug.Log("Entro in triggerenter");
            Pickup(other);
        }
        else
            Debug.Log(other.gameObject.tag);
    }

    void Pickup(Collider player)
    {
        Debug.Log("toccato");
        Instantiate(effetto, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
