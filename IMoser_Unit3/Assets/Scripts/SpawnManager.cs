using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 SpawnPoint = new Vector3(15, 0, 0);
    private PlayerController playerctrl;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnOb", 0.0f, 3.0f);
        playerctrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnOb()
    {
        
        if (playerctrl.gameOver == false)
        {
            Instantiate(obstacle, SpawnPoint, obstacle.transform.rotation);
        }
    }
}
