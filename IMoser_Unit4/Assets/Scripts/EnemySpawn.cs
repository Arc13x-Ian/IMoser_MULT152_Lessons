using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject itemPrefab;

    private float spawnRange = 8.5f;
    private int waveNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(waveNum);
    }

    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNum++;
            SpawnWave(waveNum);
        }
    }

    void SpawnWave(int enemyNum)
    {
        for (int x = 0; x < enemyNum; x++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        Instantiate(itemPrefab, GenerateSpawnPosition(), itemPrefab.transform.rotation);

    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 SpawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
        return SpawnPos;
    }
}
