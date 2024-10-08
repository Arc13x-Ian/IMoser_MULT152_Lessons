using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 SpawnPoint = new Vector3(15, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnOb", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnOb()
    {
        Instantiate(obstacle, SpawnPoint, obstacle.transform.rotation);
    }
}
