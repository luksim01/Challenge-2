﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    public float spawnInterval;
    private float spawnIntervalLower = 3.0f;
    private float spawnIntervalHigher = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        int spawnIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[spawnIndex], spawnPos, ballPrefabs[spawnIndex].transform.rotation);

        // invoke method after generating random interval
        spawnInterval = Random.Range(spawnIntervalLower, spawnIntervalHigher);
        Invoke("SpawnRandomBall", spawnInterval);
    }

}
