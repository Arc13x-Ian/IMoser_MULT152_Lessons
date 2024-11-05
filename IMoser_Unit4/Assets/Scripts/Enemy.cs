using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rbEnemy;
    public GameObject player;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerOrb");
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 seeker = (player.transform.position - transform.position).normalized;
        rbEnemy.AddForce(seeker * speed * Time.deltaTime);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
