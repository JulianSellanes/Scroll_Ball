using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public float minTime;
    public float maxTime;

    public void Generate()
    {
        if (!GameController.instance.player.running)
            return;

        //Transform _spawner = spawners[Random.Range(0, spawners.Count)];
        Instantiate(blockPrefabs [Random.Range(0, blockPrefabs.Length)], transform.position, Quaternion.identity);
        Invoke("Generate", Random.Range(minTime, maxTime));
    }
}