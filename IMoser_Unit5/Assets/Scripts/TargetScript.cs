using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private const float minForce = 10;
    private const float maxForce = 17;
    private const float minTorque = -10;
    private const float maxTorque = 10;
    private const float minX = -9;
    private const float maxX = 9;
    private Rigidbody targetRB;
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();

        RandomForce();
        RandomTorque();
        RandomSpawnPos();
    }

    void RandomForce()
    {
        targetRB.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }

    void RandomTorque()
    {
        targetRB.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }

    void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), -1, 0);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
