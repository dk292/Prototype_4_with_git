using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefabs;
    private float randomRange = 9.0f;
    public int enemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);

    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

         if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            
            int randomPowerup = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);

        }
    }

    void SpawnEnemyWave(int enemyToSpawn)
    {
        for(int i =0; i < enemyToSpawn; i++)
        {
            int randomPrefab = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomPrefab], GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    // Update is called once per frame

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-randomRange, randomRange);
        float spawnPosZ = Random.Range(-randomRange, randomRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}