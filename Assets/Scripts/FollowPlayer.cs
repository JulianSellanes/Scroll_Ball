using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float distance;
    public Transform player;

    void Start()
    {
        if(player == null)
            player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + distance, transform.position.y, transform.position.z);
    }
}