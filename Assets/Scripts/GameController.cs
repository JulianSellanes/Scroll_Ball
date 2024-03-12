using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;

    public List<Transform> spawners;
    public List<Spawner> spawnersScri;
    public GameObject[] blockPrefabs;
    public float minTime;
    public float maxTime;

    public static GameController instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        if (player == null)
            player = GameObject.Find("Player").GetComponent<Player>();

        if(spawners.Count == 0)
        {
            Transform spawnersParent = GameObject.Find("Spawners").transform;

            if (spawners == null)
                return;

            foreach (Transform child in spawnersParent)
            {
                spawners.Add(child);
            }
        }
    }

    /*public void Generate()
    {
        if (!player.running)
            return;

        /*
        Transform _spawner = spawners[Random.Range(0, spawners.Count)];
        Instantiate(blockPrefabs [Random.Range(0, blockPrefabs.Length)], _spawner.position, Quaternion.identity);
        Invoke("Generate", Random.Range(minTime, maxTime));
        */

        /*
        int _value = Random.Range(0, 4);

        switch (_value)
        {
            case 0:
                Instantiate(blockPrefabs[0], spawners[0].position, Quaternion.identity);
                Instantiate(blockPrefabs[1], spawners[1].position, Quaternion.identity);
                Instantiate(blockPrefabs[2], spawners[2].position, Quaternion.identity);
                break;
            case 1:
                Instantiate(blockPrefabs[0], spawners[0].position, Quaternion.identity);
                Instantiate(blockPrefabs[2], spawners[1].position, Quaternion.identity);
                Instantiate(blockPrefabs[1], spawners[2].position, Quaternion.identity);
                break;
            case 2:
                Instantiate(blockPrefabs[1], spawners[0].position, Quaternion.identity);
                Instantiate(blockPrefabs[2], spawners[1].position, Quaternion.identity);
                Instantiate(blockPrefabs[1], spawners[2].position, Quaternion.identity);
                break;
            case 3:
                Instantiate(blockPrefabs[1], spawners[0].position, Quaternion.identity);
                //Instantiate(blockPrefabs[0], spawners[1].position, Quaternion.identity);
                Instantiate(blockPrefabs[1], spawners[2].position, Quaternion.identity);
                break;
            default:
                break;
        }

        Invoke("Generate", 2f);*/
    //}

    
}