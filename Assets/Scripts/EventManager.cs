using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void myFunc();
    public static event myFunc Happened;

    private void Update()
    {
        if(PlayerHealth.health == 20)   //in PlayerController cambio il colore al player
        {
            Happened(); 
        }
    }
}