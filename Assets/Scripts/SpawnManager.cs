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
            x = Random.Range(-2.5f, 4.0f);
            pos = new Vector3(x, 3.3f, 0f); //x random, y fissata in alto
            Collider[] colliders = Physics.OverlapBox(pos, new Vector3(0.7f,0.7f,0.7f));    //verifica che non ci siano altri oggetti in pos
            if(colliders.Length==0)
                Instantiate(enemy, pos, Quaternion.identity);
           
        }
    }
}
