using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    private float x;
    private Vector2 pos;
    private float spawnRate = 2f;
    private float nextSpawn = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            x = Random.Range(-6.5f, 8);
            pos = new Vector2(x, 8f); //x random, y fissata in alto
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
}
