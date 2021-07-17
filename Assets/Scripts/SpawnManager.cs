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
            x = Random.Range(-3.5f, 14.0f);
            pos = new Vector2(x, -0.1f); //x random, y fissata in alto
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
}
