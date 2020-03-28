using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Spawner : MonoBehaviour
{

    public float numberOfAIToSpawn = 5;
    public float minTimerSpawn = 10;
    public float maxTimerSpawn = 30;

    public GameObject spawnPoint;
    public GameObject AI_Object;

    private float internTimer = 0;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        internTimer = Random.Range(minTimerSpawn, maxTimerSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > internTimer)
        {
            SpawnOne();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void SpawnOne()
    {
        Instantiate(AI_Object, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
