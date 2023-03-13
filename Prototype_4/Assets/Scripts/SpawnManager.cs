using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float randomRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave();
    }

    void SpawnEnemyWave()
    {
        for(int i =0; i < 3; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-randomRange, randomRange);
        float spawnPosZ = Random.Range(-randomRange, randomRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}