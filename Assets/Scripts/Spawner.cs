using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] evilCubeVariants;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 3.0f;

    private void Update()
    {
      if(timeBtwSpawn <=0)
      {
        int rand = Random.Range(0, evilCubeVariants.Length);
        Instantiate(evilCubeVariants[rand], transform.position, Quaternion.identity);
        timeBtwSpawn = startTimeBtwSpawn;
        if(startTimeBtwSpawn > minTime+0.002) 
        {
          startTimeBtwSpawn -= decreaseTime;
        }
      }
      else
        {
          timeBtwSpawn -= Time.deltaTime;
        }
    }
}
