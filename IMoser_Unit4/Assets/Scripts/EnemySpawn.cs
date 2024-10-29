using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 8.5f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 genPoint = GenerateSpawnPosition();

        Instantiate(enemyPrefab, genPoint, enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 SpawnPos = new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
        return SpawnPos;
    }
}
