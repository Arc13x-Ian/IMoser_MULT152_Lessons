using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    private float xPosRange = 19;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnRandomAnimal();
        }

        
    }

    void SpawnRandomAnimal()
    {
        int animalPrefabIndex = Random.Range(0, animalPrefabs.Length);
        float randXPos = Random.Range(-xPosRange, xPosRange);
        Vector3 randPos = new Vector3(randXPos, 0, 21); 
        Instantiate(animalPrefabs[animalPrefabIndex], randPos, animalPrefabs[animalPrefabIndex].transform.rotation);
    }
}
