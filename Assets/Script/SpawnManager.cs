using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject mousePrefab;
    private float spawnRange = 100.0f;
    private float spawnHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(mousePrefab, GenerateSpawnPosition(), mousePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, spawnHeight, spawnPosZ);

        return randomPos;
    }
}